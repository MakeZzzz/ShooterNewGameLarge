using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.Events;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Action <EnemyBehavior> EnemyDiedEvent;
    
    [SerializeField] private float travelTime = 6000f;
    [SerializeField] private Transform _target;
    private float _currentTime;
   
    [UsedImplicitly]
    public void Initialize(Transform target)
    {
        _target = target;
    }
    
    private void Update()
    {
        transform.LookAt(_target.position);
        _currentTime += Time.deltaTime;
        var progress = _currentTime / travelTime ;
        transform.position = Vector3.Lerp(transform.position,  _target.position, progress);
    }
    private void OnDestroy()
    {
        EnemyDiedEvent.Invoke(this);
    }
}