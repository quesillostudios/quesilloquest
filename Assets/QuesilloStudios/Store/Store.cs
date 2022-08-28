using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuesilloStudios
{
    public class Store : MonoBehaviour
    {
        [SerializeField] private GameObject[] storeSlots;
        [SerializeField] private TMP_Text storeTitle;

        public void PopulateStore(MerchantData merchant)
        {
            storeTitle.text = $"{merchant.Name}'s Store";
            
            for (int i = 0; i < merchant.Items.Length; i++)
            {
                storeSlots[i].SetActive(true);
            }
        }

        public void DisableStore()
        {
            storeTitle.text = "Default Store";
            
            foreach (var slot in storeSlots)
            {
                if (!slot.activeInHierarchy) continue;
                
                slot.SetActive(false);
            }
        }
    }
}
