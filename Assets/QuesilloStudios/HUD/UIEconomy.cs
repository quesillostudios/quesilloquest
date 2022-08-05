using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIEconomy : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText; 
    [SerializeField] private TMP_Text silverText; 
    [SerializeField] private TMP_Text bronzeText;

    private void ModifyCoinText(PlayerEconomy.PlayerPocket pocket)
    {
        goldText.text = pocket.Gold.ToString();
        silverText.text = pocket.Silver.ToString();
        bronzeText.text = pocket.Bronze.ToString();
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