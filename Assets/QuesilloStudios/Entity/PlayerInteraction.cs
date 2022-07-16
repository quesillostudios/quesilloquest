using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey;
    private bool _isInteracting;
    public bool IsInteracting { get => _isInteracting; }

    void Update()
    {
        _isInteracting = Input.GetKey(interactionKey);
    }
}
