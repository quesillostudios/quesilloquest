using UnityEngine;

namespace QuesilloStudios
{
    [CreateAssetMenu(fileName = "Mechant", menuName = "QuesilloQuest/Store/Merchant", order = 0)]
    public class MerchantData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }
        
        [field: SerializeField]
        public StoreItem[] Items { get; private set; }
    }
}