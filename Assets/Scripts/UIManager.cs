using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   [SerializeField] private EnemiesCountView _enemiesCountView;
   [SerializeField] private BulletsCountView _bulletsCountView;
   [SerializeField] private Weapon _weapon;
   [SerializeField] private EnemySpawner _enemySpawner;

   private void Awake()
   {
      _bulletsCountView.Initialize(_weapon);
      _enemiesCountView.Initialize(_enemySpawner);
   }
}
