using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using TMPro;


public class BulletsCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bulletsUI;
   
    private Weapon _weapon;
    private int _bulletsCount;

    [UsedImplicitly]
    public void Initialize(Weapon shooting)
    {
        _weapon = shooting;
        _bulletsUI.text = _weapon.BulletsCount.ToString();
    }
   
    [UsedImplicitly]
    public void OnShoot(int bulletsCount)
    {
        _bulletsUI.text = _weapon.BulletsCount.ToString();
    }
}