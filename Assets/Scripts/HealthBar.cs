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

    public void TakeDamage(float damageValue)
    {
        _bar.fillAmount -= damageValue;
    }
}
