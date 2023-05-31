using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using PDollarGestureRecognizer;
using System.IO;

public class MovementRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    
    public float inputThreshold = 0.1f;

    public InputActionProperty castingAction;

    private bool isMoving = false;

    public Transform movementSource;
    private List<Vector3> positionsList = new List<Vector3>();

    public float newPositionThresholdDistance = 0.05f;

    public GameObject debugCubePrefab;

    private List<Gesture> trainingSet = new List<Gesture>();
    public bool creationMode = true;
    public string newGestureName;

    // Start is called before the first frame update
    void Start()
    {
        string[] gestureFiles = Directory.GetFiles(Application.persistentDataPath, "*.xml");
        foreach(var item in gestureFiles)
        {
            trainingSet.Add(GestureIO.ReadGestureFromFile(item));
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isPressed = false;
        if(castingAction.action.ReadValue<float>() >= inputThreshold)
        {
            isPressed = true;
        }

        //Start the Movement
        if(!isMoving && isPressed)
        {
            StartMovement();
        }
        //Ending Movement
        else if(isMoving && !isPressed)
        {
            EndMovement();
        }
        //Updating Movement
        else if (isMoving && isPressed)
        {
            UpdateMovement();
        }

    }

    void StartMovement()
    {
        isMoving = true;
        positionsList.Clear();
        positionsList.Add(movementSource.position);

        if (debugCubePrefab)
        {
            Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity),3);
        }

    }

    void EndMovement()
    {
        isMoving = false;


        Point[] pointArray = new Point[positionsList.Count];

        for(int i = 0; i < positionsList.Count; i++)
        {
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionsList[i]);
            pointArray[i] = new Point(screenPoint.x, screenPoint.y, 0);
        }

        Gesture newGesture = new Gesture(pointArray);

        if (creationMode)
        {
            newGesture.Name = newGestureName;
            trainingSet.Add(newGesture);

            string fileName = Application.persistentDataPath + "/" + newGestureName + ".xml";
            GestureIO.WriteGesture(pointArray, newGestureName, fileName);


        }
        else
        {
            Result result = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());
            Debug.Log(result.GestureClass + result.Score);
        }

    }

    void UpdateMovement()
    {
        Vector3 lastPosition = positionsList[positionsList.Count - 1];
        if(Vector3.Distance(movementSource.position,lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position);

            if (debugCubePrefab)
            {
                Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
            }

        }



    }

}
