using System;
using UnityEngine;

namespace QuesilloStudios.Entity.Player
{
    public class PlayerVitality : MonoBehaviour
    {
        private float health;
        public float Health { get => health; }
        [SerializeField] private float maxHealth;
        private float energy;
        public float Energy { get => energy; }
        [SerializeField] private float maxEnergy;

        public static event Action<float, int> OnHealthChange;
        public static event Action<float, int> OnEnergyChange;

        public void ChangeHealth(float quantity)
        {
            health = Mathf.Clamp(health + quantity, 0, maxHealth);
            var healthPercent = GetPercentRange1(health, maxHealth);

            OnHealthChange?.Invoke(healthPercent, (int)health);
        }

        public void ChangeEnergy(float quantity)
        {
            energy = Mathf.Clamp(energy + quantity, 0, maxEnergy);
            var energyPercent = GetPercentRange1(energy, maxEnergy);

            OnEnergyChange?.Invoke(energyPercent, (int)energy);
        }

        // TODO: Extenderlo en un script de utilidades
        private static float GetPercentRange1(float actualValue, float maxValue)
        {
            return (actualValue * 100 / maxValue) / 100;
        }

        private void Start() 
        {
            ChangeHealth(maxHealth);
            ChangeEnergy(maxEnergy);
        }
    }
}
