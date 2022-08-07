using QuesilloStudios.Entity.Player;
using UnityEngine;

namespace QuesilloStudios.Interactions
{
    public class SwitchDoor : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Door[] doors;
        private bool isActive;
        private static readonly int Activated = Animator.StringToHash("Activated");

        private void OnTriggerStay(Collider other) // Lo que entro
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var playerInteraction = other.gameObject.GetComponent<PlayerInteraction>();

            if (playerInteraction == null)
            {
                Debug.LogError("El personaje no contiene el componente PlayerInteraction !!!");
                return;
            }

            if (playerInteraction.IsInteracting == false) return;

            ActivateSwitch();
        }

        private void ActivateSwitch()
        {
            isActive = true;
            animator.SetBool(Activated, isActive);

            foreach (var door in doors)
            {
                door.MoveTheDoor();
            }
        }
    }
}
