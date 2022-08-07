using QuesilloStudios.Entity.Player;
using TMPro;
using UnityEngine;

namespace QuesilloStudios.HUD
{
    public class UIEconomy : MonoBehaviour
    {
        [SerializeField] private TMP_Text goldText; 
        [SerializeField] private TMP_Text silverText; 
        [SerializeField] private TMP_Text bronzeText;

        private void ModifyCoinText(PlayerEconomy.PlayerPocket pocket)
        {
            goldText.text = pocket.gold.ToString();
            silverText.text = pocket.silver.ToString();
            bronzeText.text = pocket.bronze.ToString();
        }

        private void OnEnable()
        {
            PlayerEconomy.OnCoinModified += ModifyCoinText;
        }

        private void OnDisable()
        {
            PlayerEconomy.OnCoinModified -= ModifyCoinText;
        }
    }
}