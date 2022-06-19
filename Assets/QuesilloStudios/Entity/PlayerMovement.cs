using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float rotationSpeed;

    private Vector3 _direction;
    private float _rotationAngle;

    private float _axisX;
    private float _axisZ;
    private bool _jumpPressed;

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

        Rotate();
        Movement();
    }

    private void LateUpdate()
    {
        animator.SetBool("IsWalking", _direction.z != 0);
    }
    // ! FIN DE FLUJO DE UNITY

    private void ReadInputs()
    {
        _axisX = Input.GetAxis("Horizontal");           // A - D o <- - ->
        _axisZ = Input.GetAxis("Vertical");             // W - S o abajo y arriba
        _jumpPressed = Input.GetKey(KeyCode.Space);     // TRUE cuando presionemos espacio
    }

    private void Movement()
    {
        _direction = transform.forward * (_axisZ * speed);
        _characterController.Move(_direction * Time.deltaTime);
    }

    private void Rotate()
    {
        _rotationAngle = _axisX * rotationSpeed;
        transform.Rotate(Vector3.up * (_rotationAngle * Time.deltaTime));
    }
}