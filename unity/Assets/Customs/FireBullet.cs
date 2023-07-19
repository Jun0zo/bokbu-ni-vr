using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float buletSpeed = 50f;
    public GameObject bulletObject;
    public Transform frontOfGun;
    

    public void Shoot()
    {
        GetComponent<AudioSource>().Play();
        GameObject spawnedButtlet = Instantiate(bulletObject, frontOfGun.position, frontOfGun.rotation);
        spawnedButtlet.GetComponent<Rigidbody>().velocity = buletSpeed * frontOfGun.forward;
    }
}
