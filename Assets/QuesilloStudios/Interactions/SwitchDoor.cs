using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Door[] doors;
    private bool _isActive;

    private void OnTriggerStay(Collider other) // Lo que entro
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerInteraction = other.gameObject.GetComponent<PlayerInteraction>();

            if (playerInteraction == null) // Metodo de seguridad ante la busqueda del componente PlayerInterction
            {
                Debug.LogError("El personaje no contiene el componente PlayerInteraction !!!");
                return;
            }

            if (playerInteraction.IsInteracting == false) return;

            ActivateSwitch();
        }
    }

    private void ActivateSwitch()
    {
        _isActive = true;
        animator.SetBool("Actived", _isActive);

        foreach (var door in doors)
        {
            door.MoveTheDoor();
        }
    }
}
