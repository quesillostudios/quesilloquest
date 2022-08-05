using UnityEngine;
public class Coin : MonoBehaviour
{
    [SerializeField] private CoinType coinType;
    public CoinType CoinTypeProperty { get => coinType; }
    [SerializeField] private int quantity;
    public int QuantityProperty { get => quantity; }

    [SerializeField] private CoinInteractor coinInteractor;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            coinInteractor.OnCoinInteracts.Invoke(CoinTypeProperty, QuantityProperty);
            gameObject.SetActive(false); // Destroy(this);
        }
    }
}

public enum CoinType
{
    Bronze,
    Silver,
    Gold
}