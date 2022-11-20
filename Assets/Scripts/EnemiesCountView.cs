using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Object = UnityEngine.Object;

public class EnemiesCountView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private EnemySpawner _enemySpawner;
    
    private Stack<Image> _images = new();
    
    [UsedImplicitly]
    public void Initialize(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
    }
    private void Start()
    {
        var counter = _enemySpawner.numberOfEnemies;
        for (int i = 0; i < counter; i++)
        {
            var image = Instantiate(_image, transform);
            _images.Push(image);
        }
    }
    
    [UsedImplicitly]
    public void DestroyImage()
    {
        Destroy(_images.Pop());
    }
}
