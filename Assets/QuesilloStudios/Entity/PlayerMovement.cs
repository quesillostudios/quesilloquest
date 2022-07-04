using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float runningSpeed;
    public float rotationSpeed;
    public float jumpMaxForce;
    public float gravityForce;

    private Vector3 _direction;
    private Vector3 _gravityDirection;
    private float _rotationAngle;

    private float _axisX;
    private float _axisZ;
    private bool _jumpPressed;
    private bool _runningPressed;

    private bool _isJumping;

    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        ReadInputs();

        Gravity();
        Jump();
        Rotate();
        Movement();
    }

    private void LateUpdate()
    {
        animator.SetBool("IsRunning", _direction.z != 0 && _runningPressed);
        animator.SetBool("IsWalking", _direction.z != 0 && !_runningPressed);
    }

    private void ReadInputs()
    {
        _axisX = Input.GetAxis("Horizontal");           // A - D o <- - ->
        _axisZ = Input.GetAxis("Vertical");             // W - S o abajo y arriba
        _jumpPressed = Input.GetKey(KeyCode.Space);     // TRUE cuando presionemos espacio
        _runningPressed = Input.GetKey(KeyCode.LeftShift);
    }

    private void Movement()
    {
        _direction = transform.forward * (_axisZ * (_runningPressed == true ? runningSpeed : speed));
        _direction += _gravityDirection; // Ejerciendo la gravedad al movimiento
        _characterController.Move(_direction * Time.deltaTime);
    }

    private void Rotate()
    {
        _rotationAngle = _axisX * rotationSpeed;
        transform.Rotate(Vector3.up * (_rotationAngle * Time.deltaTime));
    }

    private void Gravity()
    {
        if(_isJumping) return;

         _gravityDirection.y = _characterController.isGrounded == true ? 0f : -gravityForce;
    }

    private void Jump()
    {
        if(_characterController.isGrounded == false || _isJumping == true) return;

        if(_jumpPressed)
        {
            _isJumping = true;
            StartCoroutine(CalculateJumpDistance());
        }  
    }

    private IEnumerator CalculateJumpDistance()
    {
        float actualJumpDistance = 0f;

        while(actualJumpDistance < jumpMaxForce)
        {
            _gravityDirection.y = actualJumpDistance;
            actualJumpDistance++;
            yield return new WaitForFixedUpdate();
        }

        _isJumping = false;
    }
}