using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] 
    private float _damageValue = 0.1f;

    private void OnTriggerEnter(Collider collider)
    {
        var healthController = collider.gameObject.GetComponent<HealthBar>();
        
        if (healthController)
        {
            healthController.TakeDamage(_damageValue);
        }
    }
}
