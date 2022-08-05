using System;
using UnityEngine;

public class PlayerEconomy : MonoBehaviour
{
    [Serializable]
    public struct PlayerPocket
    {
        public int Gold;
        public int Silver;
        public int Bronze;
    }

    [SerializeField] private PlayerPocket pocket;
    [SerializeField] private CoinInteractor coinInteractor;

    public static event Action<PlayerPocket> OnCoinModified;

    private void ModifyCoins(CoinType coinType, int quantity)
    {
        switch (coinType)
        {
            case CoinType.Bronze:
                pocket.Bronze += quantity;
                break;
            case CoinType.Silver:
                pocket.Silver += quantity;
                break;     
            case CoinType.Gold:
                pocket.Gold += quantity;
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