using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // ! VARIABLES PUBLICAS SE PUEDEN VER EN EL INSPECTOR DE UNITY
    public Animator animator;
    public float speed;
    public float runningSpeed;
    public float rotationSpeed;
    public float gravityForce;
    // ! <--->

    private Vector3 _direction;
    private Vector3 _gravityDirection;
    private float _rotationAngle;

    private float _axisX;
    private float _axisZ;
    private bool _jumpPressed;
    private bool _runningPressed;

    private CharacterController _characterController;


    // ! FLUJO DE UNITY
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInputs();

        Gravity();
        Rotate();
        Movement();
    }

    private void LateUpdate()
    {
        animator.SetBool("IsRunning", _direction.z != 0 && _runningPressed);
        animator.SetBool("IsWalking", _direction.z != 0 && !_runningPressed);
    }
    // ! FIN DE FLUJO DE UNITY

    private void ReadInputs()
    {
        _axisX = Input.GetAxis("Horizontal");           // A - D o <- - ->
        _axisZ = Input.GetAxis("Vertical");             // W - S o abajo y arriba
        _jumpPressed = Input.GetKeyDown(KeyCode.Space);     // TRUE cuando presionemos espacio
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
        _gravityDirection.y = _characterController.isGrounded == true ? 0f : -gravityForce;
        // ! Azucar sintactico para una pregunta de SI o NO
    }
}