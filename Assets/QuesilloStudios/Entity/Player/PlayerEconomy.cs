using System;
using UnityEngine;

namespace QuesilloStudios.Entity.Player
{
    public class PlayerEconomy : MonoBehaviour
    {
        [Serializable]
        public struct PlayerPocket
        {
            public int gold;
            public int silver;
            public int bronze;
        }

        [SerializeField] private PlayerPocket pocket;
        [SerializeField] private CoinInteractor coinInteractor;

        public static event Action<PlayerPocket> OnCoinModified;

        private void ModifyCoins(CoinType coinType, int quantity)
        {
            switch (coinType)
            {
                case CoinType.Bronze:
                    pocket.bronze += quantity;
                    break;
                case CoinType.Silver:
                    pocket.silver += quantity;
                    break;     
                case CoinType.Gold:
                    pocket.gold += quantity;
                    break;
            }

            OnCoinModified?.Invoke(pocket);
        }

        private void Start()
        {
            OnCoinModified?.Invoke(pocket);
        }

        private void OnEnable() 
        {
            coinInteractor.OnCoinInteracts += ModifyCoins;
        }

        private void OnDisable() 
        {
            coinInteractor.OnCoinInteracts -= ModifyCoins;
        }
    }
}