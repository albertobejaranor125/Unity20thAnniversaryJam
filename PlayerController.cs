using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("Movement Settings")]
    public float MoveSpeed = 5f;
    public float JumpForce = 6f;
    public float MoveSmoothTime = 0.1f;

    [Header("Camera Settings")]
    public Transform CameraTransform;
    public Vector3 CameraOffset;
    public float LookSpeed = 0.5f;
    public float MaxLookX = 30f;
    public float MinLookX = -30f;
    public float CameraSmoothTime = 0.1f;

    [Header("DeltaTime Settings")]
    public float MultiplierDeltaTime = 10f;

    private Rigidbody _rb;
    private Vector3 _moveInput;
    private float _rotationX;
    private bool _jumpPressed;
    private Vector3 _cameraVelocity;
    private float _yVel;
    #endregion
    #region Unity Messages
    void Start()
    {
        _rotationX = 0f;
        CameraOffset = new Vector3(0, 2, -4);
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _jumpPressed = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void FixedUpdate()
    {
        Move();
        if (_jumpPressed)
        {
            Jump();
            _jumpPressed = false;
        }
    }
    private void LateUpdate()
    {
        Quaternion cameraRotation = Quaternion.Euler(_rotationX, transform.eulerAngles.y, 0f);
        Vector3 targetPosition = transform.position + cameraRotation * CameraOffset;
        CameraTransform.position = Vector3.SmoothDamp(CameraTransform.position, targetPosition, ref _cameraVelocity, CameraSmoothTime);
        Vector3 lookTarget = transform.position + Vector3.up * 1.5f;
        CameraTransform.LookAt(lookTarget);

    }
    #endregion
    #region Input Events
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        _moveInput = new Vector3(input.x, 0f, input.y);
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        _rotationX -= lookInput.y * LookSpeed * Time.deltaTime;
        _rotationX = Mathf.Clamp(_rotationX, MinLookX, MaxLookX);
        float rotationDelta = lookInput.x * LookSpeed;
        float rotationY = transform.eulerAngles.y + rotationDelta;
        float smoothRot = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationY, ref _yVel, CameraSmoothTime);
        transform.rotation = Quaternion.Euler(0f, smoothRot, 0f);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started) _jumpPressed = true;
    }
    #endregion
    #region Methods
    private void Move()
    {
        Vector3 forward = CameraTransform.forward;
        forward.y = 0f;
        forward.Normalize();
        Vector3 right = CameraTransform.right;
        right.y = 0f;
        right.Normalize();
        Vector3 move = (forward * _moveInput.z + right * _moveInput.x) * MoveSpeed;
        Vector3 velocity = new Vector3(move.x, _rb.linearVelocity.y, move.z);
        Vector3 smoothVelocity = Vector3.Lerp(_rb.linearVelocity, velocity, 0.15f);
        _rb.linearVelocity = smoothVelocity;
    }
    private void Jump()
    {
        if (IsGrounded())
        {
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, JumpForce, _rb.linearVelocity.z);
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
    #endregion
}
