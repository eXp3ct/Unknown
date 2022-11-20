using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("Referrences")]
    [SerializeField] private Transform _orientaion;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _playerObj;
    [SerializeField, Range(0f, 10f)] private float _rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        //Rotate orientation
        Vector3 viewDirection = _playerTransform.position - new Vector3(transform.position.x, _playerTransform.position.y, transform.position.z);
        _orientaion.forward = viewDirection.normalized;

        //Rotate player obj
        float horizontalInput = Input.GetAxis(Axis.Horizontal);
        float verticalInput = Input.GetAxis(Axis.Vertical);
        Vector3 inputDirection = _orientaion.forward * verticalInput + _orientaion.right * horizontalInput;

        if (inputDirection != Vector3.zero)
            _playerObj.forward = Vector3.Slerp(_playerObj.forward, inputDirection.normalized, Time.deltaTime * _rotationSpeed);

    }
}
