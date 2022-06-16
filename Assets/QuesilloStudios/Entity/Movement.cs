using System;
using System.Collections;
using UnityEngine;

namespace QuesilloStudios.Entity
{
    public class Movement : MonoBehaviour
    {
        private CharacterController _characterController;

        private float _axisX;
        private float _axisZ;
        private bool _jumpPressed;
        
        private Vector3 _direction;
        private Vector3 _gravityDirection;
        private float _rotationAngle;

        [SerializeField] private Animator bodyAnimator;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float jumpPower;
        [SerializeField] private float gravity;

        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        private bool _jumpPerformed;

        void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            Gravity();
            Jump();
            Rotate();
            Displacement();
        }
        
        void Update()
        {
            InputDetection();
        }
        
        private void LateUpdate()
        {
            if (!_characterController.isGrounded) return;
            bodyAnimator.SetBool(IsWalking, _axisZ != 0f);
        }

        private void InputDetection()
        {
            _axisX = Input.GetAxis("Horizontal");
            _axisZ = Input.GetAxis("Vertical");
            _jumpPressed = Input.GetKey(KeyCode.Space);
        }

        private void Displacement()
        {
            //_direction.x = Input.GetAxis("Horizontal") * speed;
            _direction = transform.forward * (_axisZ * movementSpeed);
            _direction += _gravityDirection;
            
            _characterController.Move(_direction * Time.deltaTime);
        }

        private void Rotate()
        {
            _rotationAngle = _axisX * rotationSpeed;
            transform.Rotate(Vector3.up * (_rotationAngle * (Time.deltaTime)));
        }

        private void Jump()
        {
            if (!_characterController.isGrounded) return;
            
            if(_jumpPressed)
                StartCoroutine(PerformingJump());
        }

        private void Gravity()
        {
            if (_jumpPerformed) return;
            _gravityDirection.y = _characterController.isGrounded ? 0f : -gravity;
        }

        private IEnumerator PerformingJump()
        {
            _jumpPerformed = true;
            
            var distanceOfJump = 0f;

            while (distanceOfJump < jumpPower)
            {
                _gravityDirection.y = distanceOfJump;
                distanceOfJump++;
                yield return new WaitForEndOfFrame();
            }

            _jumpPerformed = false;
        }
    }
}
