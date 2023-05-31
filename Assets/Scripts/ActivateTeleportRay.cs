using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportRay : MonoBehaviour
{

    public GameObject leftTeleportation;

    public InputActionProperty leftActivity;

    public InputActionProperty leftCancel;
    //public InputActionProperty rightCancel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftTeleportation.SetActive(leftCancel.action.ReadValue<float>() == 0 && leftActivity.action.ReadValue<float>() > 0.1f);
    }
}
