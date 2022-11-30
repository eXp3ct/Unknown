using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public static bool Busy = false;
    private enum PlayerState
    {
        Grounded,
        Groundless
    }
    private PlayerState _playerState;
    [Header("Movement")]
    [SerializeField] private Transform _orientation;
    [SerializeField, Range(0f, 10f)] private float _groundDrag;
    [SerializeField, Range(0f, 10f)] private float _walkSpeed;
    [SerializeField, Range(0f, 10f)] private float _runSpeed;
    private float _speed;

    [Header("Ground Check")]
    [SerializeField, Range(0f, 10f)] private float _playerHeight;
    [SerializeField] private LayerMask _whatIsGround;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _movementDirection;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody= GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;
        _speed = _walkSpeed;
    }
    private void Update()
    {
        PlayerDrag();

        _horizontalInput = GetInput.GetHorizontalAxis;
        _verticalInput= GetInput.GetVerticalAxis;

        SpeedControl();
    }
    private void FixedUpdate()
    {
        if (Busy)
            return;
        MovePlayer();
    }
    private void PlayerDrag()
    {
        // ground check
        _playerState = Physics.Raycast(transform.position, Vector3.down, _playerHeight * .5f + .2f, _whatIsGround) ? PlayerState.Grounded : PlayerState.Groundless;

        //Handle drag
        if (_playerState == PlayerState.Grounded)
            _rigidBody.drag = _groundDrag;
        else
            _rigidBody.drag = 0;
    }
    private void MovePlayer()
    {
        //Calculate movement direction
        _movementDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;

        _rigidBody.AddForce(_movementDirection.normalized * _speed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        ShiftSpeed();

        Vector3 flatVeloctity = new Vector3(_rigidBody.velocity.x, 0f, _rigidBody.velocity.z);

        //Limit velocity if nedded

        if (flatVeloctity.magnitude > _speed)
        {
            Vector3 limitedVelocity = flatVeloctity.normalized * _speed;
            _rigidBody.velocity = new Vector3(limitedVelocity.x, _rigidBody.velocity.y, limitedVelocity.z);
        }
    }

    private void ShiftSpeed()
    {
        if (GetInput.PressedShift)
        {
            if (_speed == _runSpeed)
            {
                _speed = _walkSpeed;
                return;
            }
            _speed = _runSpeed;
        }
    }
}
