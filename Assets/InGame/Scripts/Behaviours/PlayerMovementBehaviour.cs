using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    public float _speed, _rotateSpeed;
    public FloatingJoystick _joystick;
    public Rigidbody _rb;
    private Vector3 _direction, _rotateDirection;

    private void Start()
    {
        _joystick = FindObjectOfType<FloatingJoystick>();
        if (_rb == null) _rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        _direction = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
        _rb.velocity = (_direction * _speed * Time.fixedDeltaTime);
        _rotateDirection = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_rotateDirection), _rotateSpeed * Time.deltaTime);
    }

}