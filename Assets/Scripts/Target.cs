using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 200;

    public void Damage(float damage, string tag)
    {
        float modifier = tag switch
        {
            "Body" => 1,
            "Head" => 3,
            "Arm" => 0.67f,
            "Leg" => 0.5f,
            _ => 1
        };

        damage *= modifier;

        Debug.Log($"Body part hit: {tag}\nDamage: {damage}");

        health -= damage;

        if(health <= 0)
            Destroy(gameObject);
    }
}
