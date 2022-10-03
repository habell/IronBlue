using DefaultNamespace.Abstract;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelEndPickUp : PickUp
    {
        protected override void Pick(Collider2D pickuper)
        {
            if (!pickuper.gameObject.TryGetComponent(out Player player)) return;
            Debug.Log("GameOver!");
        }
    }
}