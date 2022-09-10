using System.Collections.Generic;
using UnityEngine;

namespace QuesilloStudios
{
    [CreateAssetMenu(fileName = "Merchant", menuName = "QuesilloQuest/Store/Merchant", order = 0)]
    public class MerchantData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [SerializeField] 
        private StoreItem[] items;

        public List<StoreItem> ItemsToSold { get; } = new List<StoreItem>();

        public void Initialize()
        {
            foreach (var item in items)
            {
                ItemsToSold.Add(Instantiate(item));
            }
        }
        
        public void SellItem(StoreItem item)
        {
            ItemsToSold.Remove(item);

            foreach (var itemAvailable in ItemsToSold)
            {
                Debug.Log(itemAvailable.Name);
            }
        }
    }
}