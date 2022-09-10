using System;
using System.Collections;
using System.Collections.Generic;
using QuesilloStudios.Economy;
using QuesilloStudios.Entity.Player;
using TMPro;
using UnityEngine;

namespace QuesilloStudios
{
    public class Store : MonoBehaviour
    {
        [SerializeField] private ItemSlot[] itemSlots;
        [SerializeField] private TMP_Text storeTitle;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private CoinInteractor coinInteractor;

        public bool IsStoreOpen { get; private set; }

        private void Start()
        {
            ToggleStore(false);
        }

        public void PopulateStore(MerchantData merchant, PlayerEconomy playerEconomy)
        {
            ToggleStore(true);
            
            storeTitle.text = $"{merchant.Name}'s Store";
            
            for (var i = 0; i < merchant.ItemsToSold.Count; i++)
            {
                itemSlots[i].gameObject.SetActive(true);
                itemSlots[i].PopulateSlot(merchant, merchant.ItemsToSold[i], playerEconomy, coinInteractor);
            }
        }

        public void DisableStore()
        {
            ToggleStore(false);
            
            storeTitle.text = "Casual Store";
            
            foreach (var slot in itemSlots)
            {
                if (!slot.gameObject.activeInHierarchy) continue;
                slot.gameObject.SetActive(false);
            }
        }

        private void ToggleStore(bool status)
        {
            canvasGroup.alpha = status ? 1 : 0;
            canvasGroup.interactable = status;
            canvasGroup.blocksRaycasts = status;
            IsStoreOpen = status;
        }
    }
}
