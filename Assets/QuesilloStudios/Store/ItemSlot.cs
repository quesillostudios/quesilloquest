using System;
using System.Collections;
using System.Collections.Generic;
using QuesilloStudios.Economy;
using QuesilloStudios.Entity.Player;
using UnityEngine;
using UnityEngine.UI;

namespace QuesilloStudios
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Button itemButton;
        private MerchantData _merchantData;
        private StoreItem _storeItem;
        private PlayerEconomy _playerEconomy;
        private CoinInteractor _coinInteractor;

        private void OnEnable()
        {
            itemButton.onClick.AddListener(SellItem);
        }

        private void OnDisable()
        {
            itemButton.onClick.RemoveListener(SellItem);
        }

        public void PopulateSlot(MerchantData merchantData, StoreItem storeItem, PlayerEconomy playerEconomy, CoinInteractor coinInteractor)
        {
            _storeItem = storeItem;
            _merchantData = merchantData;
            _playerEconomy = playerEconomy;
            _coinInteractor = coinInteractor;
        }

        private void SellItem()
        {
            if (_playerEconomy.GetCoinBalance(_storeItem.Coin) < _storeItem.Price) return;
            
            _merchantData.SellItem(_storeItem);
            _coinInteractor.OnCoinInteracts(_storeItem.Coin, -_storeItem.Price);
            
            gameObject.SetActive(false);
        }
    }
}
