using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBehavior : MonoBehaviour
{
    public Action <EnemyBehavior> EnemyDiedEvent;
    [SerializeField] private Animator _animator;
    
    [SerializeField] private float travelTime = 6000f;
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _agent;

    [UsedImplicitly]
    public void Initialize(Transform target)
    {
        _target = target;
    }
    
    private void Update()
    {
        _agent.destination = _target.position;
        // transform.LookAt(_target.position);
        // _currentTime += Time.deltaTime;
        // var progress = _currentTime / travelTime ;
        // transform.position = Vector3.Lerp(transform.position,  _target.transform.position, progress);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthBar>())
        {
            _animator.SetTrigger("attack");
        }
    }
    private void OnDestroy()
    {
        EnemyDiedEvent.Invoke(this);
    }
}
