using QuesilloStudios.Economy;
using UnityEngine;

namespace QuesilloStudios
{
    [CreateAssetMenu(fileName = "Store Item", menuName = "QuesilloQuest/Store/Item", order = 0)]
    public class StoreItem : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField] 
        public Sprite Image { get; private set; }
        
        [field: SerializeField] 
        public CoinType Coin { get; private set; }
        
        [field: SerializeField] 
        public int Price { get; private set; }
    }
}