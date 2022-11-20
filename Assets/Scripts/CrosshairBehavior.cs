using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairBehavior : MonoBehaviour
{
    public RectTransform crosshair;
    [SerializeField] private float _sizeState;
    [SerializeField] private float _sizeMove;
    [SerializeField] private float _sizeCurrent;
    [SerializeField] private float _speedSize;
    void Update()
    {
        if (IsMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _sizeCurrent = Mathf.Lerp(_sizeCurrent, 1500f, Time.deltaTime * _speedSize);
            }
            else
            {
                _sizeCurrent = Mathf.Lerp(_sizeCurrent, _sizeMove, Time.deltaTime * _speedSize);
            }
        }
        else
        {
            _sizeCurrent = Mathf.Lerp(_sizeCurrent, _sizeState, Time.deltaTime * _speedSize);
        }
        crosshair.sizeDelta = new Vector2(_sizeCurrent, _sizeCurrent);
    }

    private bool IsMoving
    {
        get
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetMouseButtonDown(0))
            {
                return true;
            }

            return false;
        }
    
    }
}
