using UnityEngine;

namespace QuesilloStudios.Entity.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private KeyCode interactionKey;
        public bool IsInteracting { get; private set; }

        private void Update()
        {
            IsInteracting = Input.GetKey(interactionKey);
        }
    }
}
