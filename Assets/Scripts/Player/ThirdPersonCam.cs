using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        HideCursor();
    }

    private void FixedUpdate()
    {
        if (GetInput.PressedAlt)
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                ShowCursor();
                return;
            }
                
            HideCursor();
        }
            
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
    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
