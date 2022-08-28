using System;
using System.Collections;
using System.Collections.Generic;
using QuesilloStudios.Entity.Player;
using UnityEngine;

namespace QuesilloStudios
{
    public class Merchant : MonoBehaviour
    {
        [SerializeField] private MerchantData merchantData;
        [SerializeField] private Store windowStore;
        private bool _isStoreOpen;
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.GetComponent<PlayerInteraction>().IsInteracting)
                {
                    _isStoreOpen = windowStore.gameObject.activeInHierarchy;

                    if (!_isStoreOpen) OpenStore();
                }
            }
        }

        private void OpenStore()
        {
            windowStore.gameObject.SetActive(true);
            windowStore.PopulateStore(merchantData);
        }
    }
}
