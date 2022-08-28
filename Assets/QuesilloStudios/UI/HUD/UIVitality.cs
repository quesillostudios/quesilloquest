using QuesilloStudios.Entity.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuesilloStudios.UI.HUD
{
    public class UIVitality : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private Slider energySlider;
        [SerializeField] private TMP_Text energyText;

        private void ModifyHealthSlider(float percent, int actualValue)
        {
            healthSlider.value = percent;
            healthText.text = actualValue.ToString();
        }

        private void ModifyEnergySlider(float percent, int actualValue)
        {
            energySlider.value = percent;
            energyText.text = actualValue.ToString();
        }

        private void OnEnable() 
        {
            PlayerVitality.OnHealthChange += ModifyHealthSlider;
            PlayerVitality.OnEnergyChange += ModifyEnergySlider;
        }

        private void OnDisable() 
        {
            PlayerVitality.OnHealthChange -= ModifyHealthSlider;
            PlayerVitality.OnEnergyChange -= ModifyEnergySlider;
        }
    }
}
