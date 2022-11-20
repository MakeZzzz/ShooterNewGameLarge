using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.Events;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyBehavior _enemy;
    [SerializeField] private Transform _enemyTarget;
    
    public UnityEvent DecreaseEnemiesEvent;
    public int numberOfEnemies;
    
    private List<EnemyBehavior> _Enemies = new List<EnemyBehavior>();
    
    [UsedImplicitly]
    public void Initialize(EnemyBehavior enemyBehavior)
    {
        _enemy = enemyBehavior;
    }

    public void Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            var enemy = Instantiate(_enemy);
            _enemy.Initialize(_enemyTarget); 
            _Enemies.Add(enemy);
            enemy.transform.position = new Vector3(Random.Range(6, -14), 1.05f, Random.Range(-3, -3));
            enemy.EnemyDiedEvent += DecreaseEnemiesCount;
        }
    }
    
    public void DecreaseEnemiesCount(EnemyBehavior deadEnemy)
    {
        numberOfEnemies--;
        deadEnemy.EnemyDiedEvent -= DecreaseEnemiesCount;
        DecreaseEnemiesEvent.Invoke();
    }
}
