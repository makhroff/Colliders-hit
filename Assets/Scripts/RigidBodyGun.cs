using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyGun : MonoBehaviour
{
    public float damage = 10;
    public float fireRate = 15f;

    public Camera fpsCam;
    public GameObject bulet;
    public Transform attackPoint;

    private float nextTimeToFire = 0f;

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.point);
            targetPoint = hit.point;
        }
        else
        {
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            targetPoint = ray.direction;
        }



        Vector3 bulletDirection = targetPoint - attackPoint.position;

        GameObject currentBullet = Instantiate(bulet, attackPoint.position, fpsCam.transform.rotation);
        //currentBullet.transform.forward = bulletDirection.normalized;
        currentBullet.GetComponent<Rigidbody>()?.AddForce(transform.forward * 30f, ForceMode.Impulse);
    }
}
