using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float bulletSpeed;
    public Transform bulletSpawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(BulletPrefab,bulletSpawnpoint);
        spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnpoint.forward * bulletSpeed;
        Destroy(spawnedBullet, 5);
    }

}
