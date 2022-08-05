using System;
using UnityEngine;

public class PlayerVitality : MonoBehaviour
{
    private float health;
    [SerializeField] private float maxHealth;
    private float energy;
    [SerializeField] private float maxEnergy;

    public static event Action<float, int> OnHealthChange;
    public static event Action<float, int> OnEnergyChange;

    public void ChangeHealth(float quantity)
    {
        health = Mathf.Clamp(health + quantity, 0, maxHealth);
        float porcentHealth = GetPorcentBase1(health, maxHealth);

        OnHealthChange?.Invoke(porcentHealth, (int)health);
    }

    public void ChangeEnergy(float quantity)
    {
        energy = Mathf.Clamp(energy + quantity, 0, maxEnergy);
        float porcentEnergy = GetPorcentBase1(energy, maxEnergy);

        OnEnergyChange?.Invoke(porcentEnergy, (int)energy);
    }

    // TODO: Extenderlo en un script de utilidades
    private float GetPorcentBase1(float actualValue, float maxValue)
    {
        return (actualValue * 100 / maxValue) / 100;
    }

    private void Start() 
    {
        ChangeHealth(float.MaxValue);
        ChangeEnergy(float.MaxValue);
    }
}
