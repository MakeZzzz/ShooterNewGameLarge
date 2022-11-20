using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.Events;
using UnityEngine;

public class BulletsBehavior : MonoBehaviour
{
    private const string ENEMY_TAG = "Enemy";
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(ENEMY_TAG))
        {
            Destroy(collision.gameObject);
            Debug.Log("hit");
        }
        Destroy(gameObject);
    }
}
