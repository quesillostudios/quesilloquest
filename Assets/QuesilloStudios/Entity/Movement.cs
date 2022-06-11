using System;
using System.Collections;
using UnityEngine;

namespace QuesilloStudios.Entity
{
    public class Movement : MonoBehaviour
    {
        private CharacterController _characterController;
        private Vector3 _direction;

        [SerializeField] private Animator bodyAnimator;
        [SerializeField] private float speed;
        [SerializeField] private float jumpPower;
        [SerializeField] private float gravity;
        
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        private bool _jumpPerformed;

        void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
        
        void Update()
        {
            Gravity();
            Jump();
            Displacement();
        }

        private void Displacement()
        {
            _direction.x = Input.GetAxis("Horizontal") * speed;
            _direction.z = Input.GetAxis("Vertical") * speed;

            _characterController.Move(_direction * Time.deltaTime);
        }

        private void Jump()
        {
            if (!Input.GetKey(KeyCode.Space) || !_characterController.isGrounded) return;
            //_direction.y += jumpPower;
            StartCoroutine(PerformingJump());
        }

        private void Gravity()
        {
            if (_jumpPerformed) return;
            
            _direction.y = _characterController.isGrounded ? 0f : -gravity;
        }

        private void LateUpdate()
        {
            if (!_characterController.isGrounded) return;
            bodyAnimator.SetBool(IsWalking, (_direction.x != 0f || _direction.z != 0f));
        }

        private IEnumerator PerformingJump()
        {
            _jumpPerformed = true;
            
            var distanceOfJump = 1f;

            while (distanceOfJump < jumpPower)
            {
                _direction.y = distanceOfJump;
                distanceOfJump++;
                yield return new WaitForEndOfFrame();
            }

            _jumpPerformed = false;
        }
    }
}
