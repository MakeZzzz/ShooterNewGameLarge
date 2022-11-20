using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] 
    private float _mouseSensivity = 150f;

    public Transform _player;
    
    private float _xRotation = 0f;
    
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90);
        _player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
}
