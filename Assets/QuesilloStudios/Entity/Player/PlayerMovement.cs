using System.Collections;
using UnityEngine;

namespace QuesilloStudios.Entity.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float speed;
        [SerializeField] private float runningSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float jumpMaxForce;
        [SerializeField] private float gravityForce;

        private Vector3 direction;
        private Vector3 gravityDirection;
        private float rotationAngle;

        private float axisX;
        private float axisZ;
        private bool jumpPressed;
        private bool isJumping;
        private bool runningPressed;

        private CharacterController characterController;
        
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            ReadInputs();

            Gravity();
            Jump();
            Rotate();
            Movement();
        }

        private void LateUpdate()
        {
            animator.SetBool(IsRunning, direction.z != 0 && runningPressed);
            animator.SetBool(IsWalking, direction.z != 0 && !runningPressed);
        }

        private void ReadInputs()
        {
            axisX = Input.GetAxis("Horizontal");
            axisZ = Input.GetAxis("Vertical");
            jumpPressed = Input.GetKey(KeyCode.Space);
            runningPressed = Input.GetKey(KeyCode.LeftShift);
        }

        private void Movement()
        {
            direction = transform.forward * (axisZ * (runningPressed == true ? runningSpeed : speed));
            direction += gravityDirection;
            characterController.Move(direction * Time.deltaTime);
        }

        private void Rotate()
        {
            rotationAngle = axisX * rotationSpeed;
            transform.Rotate(Vector3.up * (rotationAngle * Time.deltaTime));
        }

        private void Gravity()
        {
            if(isJumping) return;

            gravityDirection.y = characterController.isGrounded == true ? 0f : -gravityForce;
        }

        private void Jump()
        {
            if(characterController.isGrounded == false || isJumping == true) return;

            if (!jumpPressed) return;
            isJumping = true;
            StartCoroutine(CalculateJumpDistance());
        }

        private IEnumerator CalculateJumpDistance()
        {
            var actualJumpDistance = 0f;

            while(actualJumpDistance < jumpMaxForce)
            {
                gravityDirection.y = actualJumpDistance;
                actualJumpDistance++;
                yield return new WaitForFixedUpdate();
            }

            isJumping = false;
        }
    }
}