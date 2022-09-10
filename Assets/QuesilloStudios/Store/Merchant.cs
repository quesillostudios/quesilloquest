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

        private void Start()
        {
            merchantData.Initialize();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.GetComponent<PlayerInteraction>().IsInteracting)
                {
                    var playerEconomy = other.GetComponent<PlayerEconomy>();
                    if (!windowStore.IsStoreOpen) OpenStore(playerEconomy);
                }
            }
        }

        private void OpenStore(PlayerEconomy playerEconomy)
        {
            windowStore.PopulateStore(merchantData, playerEconomy);
        }
    }
}
