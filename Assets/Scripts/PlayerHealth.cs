using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerHealth : Health
    {
        public PlayerHealth(float healthValue) : base(healthValue)
        {
        }

        protected override void Death()
        {
            Debug.Log("I am Die!");
        }
    }
}