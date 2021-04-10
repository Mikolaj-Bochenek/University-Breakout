using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _camera2;
    [SerializeField] private Transform _cameraZero;
    [SerializeField] private Transform _camera2Zero;

    [SerializeField] private float _cameraX = 3.0f;
    [SerializeField] private float _cameraY = 0.8f;

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _rotate_speed = 1.0f;

    [SerializeField] private Vector3 _move = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 _rotate = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 _mouseMove = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 _cameraMove = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 _cameraMove2 = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            MouseMove();
            PlayerMoveRMB();
        }   
        else if (Input.GetMouseButton(0))
        {
            CameraMove();
        }
        else
        {
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (vertical > 0)
            _move = transform.forward;
        else if (vertical < 0)
            _move = transform.forward * -1.0f;
        else
        {
            _move = Vector3.zero;
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                CameraBack();
            }
        }
        
        if (horizontal != 0)
        {
            _rotate.y = horizontal;
            Quaternion rotateQuaternion = Quaternion.Euler(_rotate * _rotate_speed);
            _rigidbody.MoveRotation(_rigidbody.rotation * rotateQuaternion);
        }

        _rigidbody.MovePosition(transform.localPosition + _move * _speed * Time.deltaTime);
    }

    private void MouseMove()
    {
        Cursor.visible = false;
        _mouseMove.y = Input.GetAxis("Mouse X");
        Quaternion rotateQuaternion = Quaternion.Euler(_mouseMove * _speed);
        _rigidbody.MoveRotation(_rigidbody.rotation * rotateQuaternion);
    }

    private void PlayerMoveRMB()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if ((vertical > 0) && (horizontal > 0)) _move = transform.forward + transform.right;
        else if ((vertical > 0) && (horizontal < 0)) _move = transform.forward + transform.right * -1.0f;
        else if ((vertical < 0) && (horizontal > 0)) _move = transform.forward * -1.0f + transform.right;
        else if ((vertical < 0) && (horizontal < 0)) _move = transform.forward * -1.0f + transform.right * -1.0f;
        else if (vertical > 0) _move = transform.forward;
        else if (vertical < 0) _move = transform.forward * -.8f;
        else if (horizontal > 0) _move = transform.right;
        else if (horizontal < 0) _move = transform.right * -1.0f;
        else _move = Vector3.zero;

        _rigidbody.MovePosition(transform.localPosition + _move * _speed * Time.deltaTime);
    }

    private void CameraMove()
    {
        Cursor.visible = false;
        _cameraMove.y = Input.GetAxis("Mouse X");
        _camera.Rotate(_cameraMove, _cameraX);

        _cameraMove2.x = Input.GetAxis("Mouse Y") * -1.0f;
        _camera2.Rotate(_cameraMove2, _cameraY);
    }

    private void CameraBack()
    {
        _camera.rotation = Quaternion.Lerp(_camera.rotation, _cameraZero.rotation, Time.deltaTime * _speed);
        _camera2.rotation = Quaternion.Lerp(_camera2.rotation, _camera2Zero.rotation, Time.deltaTime * _speed);
    }
}
