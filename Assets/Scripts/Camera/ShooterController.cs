using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public GameObject Bullet_ProjectilePrefab;
    public Transform spawnPoint;
    public bool fireInputHeldDown;

    // Gun Sound effect
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire 1"))
        {
            fireInputHeldDown = true;
            GameObject newBullet = Instantiate(Bullet_ProjectilePrefab, null);
            newBullet.transform.position = spawnPoint.position;
            newBullet.transform.rotation = spawnPoint.rotation;
        }
        else
        {
            if (!Input.GetButton("Fire 1"))
            {
                fireInputHeldDown=false;
            }
        }
    }
}
