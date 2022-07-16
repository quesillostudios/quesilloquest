using System.Collections;
using UnityEngine;

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
        Vector3 directon = inverted ? Vector3.left : Vector3.right;
        speed = inverted ? speed * -1 : speed;

        while (Mathf.Abs(transform.eulerAngles.x) >= finalAngle)
        {
            transform.Rotate(directon * (speed * Time.deltaTime));
            yield return null;
        }
    }
}
