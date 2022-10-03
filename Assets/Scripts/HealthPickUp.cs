using DefaultNamespace.Abstract;
using UnityEngine;

namespace DefaultNamespace
{
    public class HealthPickUp : PickUp
    {
        [SerializeField]
        private float _healValue;

        protected override void Pick(Collider2D pickuper)
        {
            if (!pickuper.gameObject.TryGetComponent(out Player player)) return;
            player.Health.Heal(_healValue);
            Destroy(gameObject);
        }
    }
}