using QuesilloStudios.Economy;
using QuesilloStudios.Entity.Player;
using UnityEngine;
using System.Collections;
using TMPro;

namespace QuesilloStudios.Interactions
{
    public class Gather : MonoBehaviour
    {
        [SerializeField] private CoinInteractor coinInteractor;
        [SerializeField] private int maxCapacity;
        [SerializeField] private int gatheringSubstract;
        private int actualCapacity;
        [SerializeField] private int quantityOfCoin;
        [SerializeField] private CoinType coinType;
        [SerializeField] private int secondsToGather;
        [SerializeField] private float energyToConsume;

        [SerializeField] private TMP_Text capacityText;
        private bool isGathering;

        private void OnTriggerStay(Collider other) 
        {
            if(other.gameObject.CompareTag("Player"))
            {
                if (other.GetComponent<PlayerInteraction>().IsInteracting)
                {
                    DoGathering(other.GetComponent<PlayerVitality>());
                }
            }
        }

        private void DoGathering(PlayerVitality playerVitality)
        {
            if (isGathering || actualCapacity <= 0 || playerVitality.Energy < energyToConsume) return;

            isGathering = true;
            playerVitality.ChangeEnergy(-energyToConsume);

            StartCoroutine(Gathering());
        }

        private IEnumerator Gathering()
        {
            int count = default;

            while(count < secondsToGather)
            {
                count++;
                yield return new WaitForSeconds(1f);
            }

            coinInteractor.OnCoinInteracts?.Invoke(coinType, quantityOfCoin);
            SetActualCapacity(-gatheringSubstract);

            isGathering = false;
        }

        private void SetActualCapacity(int quantity)
        {
            actualCapacity = Mathf.Clamp(actualCapacity + quantity, default, maxCapacity);
            capacityText.text = $"{actualCapacity.ToString()} / {maxCapacity.ToString()}";

            if (actualCapacity <= 0) gameObject.SetActive(false);
        }

        private void Start() 
        {
            SetActualCapacity(maxCapacity);
        }
    }
}
