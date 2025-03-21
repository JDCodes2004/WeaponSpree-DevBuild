using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class WeaponController_AR : MonoBehaviour
{
    public int damage;
    public Camera viewCamera;
    public float fireRate;

    private float nextFire;

    [Header("VFX")]
    public GameObject hitVFX;

    // Update is called once per frame
    void Update()
    {
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
            hitVFX.SetActive(false);
        }

        if (Input.GetButton("Fire1") && nextFire <= 0)
        {
            nextFire = 1 / fireRate;
            Fire();
            hitVFX.SetActive(true);
        }
    }

    void Fire()
    {
        hitVFX.SetActive(true);

        Ray ray = new(viewCamera.transform.position, viewCamera.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f))
        {
            PhotonNetwork.Instantiate(hitVFX.name, hit.point, Quaternion.identity);

            if (hit.transform.gameObject.GetComponent<Health>())
            {
                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, damage);
                PhotonNetwork.Destroy(targetGo: hitVFX);
            }
        }
    }
}
