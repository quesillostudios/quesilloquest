using System.Collections;
using UnityEngine;

namespace QuesilloStudios.Interactions
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private float finalAngle;
        [SerializeField] private float speed;
        [SerializeField] private bool inverted;

        private bool locked;

        public void MoveTheDoor()
        {
            if(locked == true) return; // Solo este metodo funcionara 1 sola vez

            locked = true;
            StartCoroutine(DoorMovement());
        }

        private IEnumerator DoorMovement()
        {
            var direction = inverted ? Vector3.left : Vector3.right;
            speed = inverted ? speed * -1 : speed;

            while (Mathf.Abs(transform.eulerAngles.x) >= finalAngle)
            {
                transform.Rotate(direction * (speed * Time.deltaTime));
                yield return null;
            }
        }
    }
}
