using UnityEngine;

namespace QuesilloStudios
{
    [CreateAssetMenu(fileName = "Merchant", menuName = "QuesilloQuest/Store/Merchant", order = 0)]
    public class MerchantData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }
        
        [field: SerializeField]
        public StoreItem[] Items { get; private set; }
    }
}