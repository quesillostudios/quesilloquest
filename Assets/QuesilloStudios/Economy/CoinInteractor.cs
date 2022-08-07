using System;
using UnityEngine;

namespace QuesilloStudios.Economy
{
    [CreateAssetMenu(fileName = "Coin Interactor", menuName = "QuesilloQuest/Economy/Coin Interactor")]
    public class CoinInteractor : ScriptableObject
    {
        public Action<CoinType, int> OnCoinInteracts;
    }
}