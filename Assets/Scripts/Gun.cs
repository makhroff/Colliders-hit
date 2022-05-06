using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10;
    public float fireRate = 15f;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;

    private void FixedUpdate()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Target target = Utils.FindParent(hit.collider.gameObject).GetComponent<Target>();

            if(target)
            {
                string hitTag = hit.collider.tag;
                target.Damage(damage, hitTag);
            }
            else if(hit.collider.tag == "MovebleObject")
            {
                print("hit");
                hit.rigidbody.AddForce(Camera.main.transform.forward * 30f, ForceMode.Impulse);
            }
        }
    }
}
