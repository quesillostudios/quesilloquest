using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIVitality : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider energySlider;
    [SerializeField] private TMP_Text energyText;

    private void ModifyHealthSlider(float porcent, int actualValue)
    {
        healthSlider.value = porcent;
        healthText.text = actualValue.ToString();
    }

    private void ModifyEnergySlider(float porcent, int actualValue)
    {
        energySlider.value = porcent;
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
