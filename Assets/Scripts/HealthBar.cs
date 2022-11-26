using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _bar;
    
    private float _fill = 1f;
    void Start()
    {
        _bar.fillAmount = _fill;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        _bar.fillAmount -= 0.1f;
    }
}
