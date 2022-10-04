using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Health
    {
        private readonly float _maxHealth;
        
        private float _healthValue;

        protected Health(float healthValue)
        {
            _maxHealth = healthValue;
            _healthValue = _maxHealth;
        }

        public float HealthValue => _healthValue;

        public void Hit(float damage)
        {
            var healthValue = _healthValue - damage;
            if (healthValue <= 0)
            {
                Death();
            }
        }

        public void Heal(float healingValue)
        {
            var resultHealth = _healthValue += healingValue;
            _healthValue = resultHealth <= _maxHealth ? resultHealth : _maxHealth;
        }

        protected abstract void Death();
    }
}