using System;
using UnityEngine;

namespace Abstract
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class KillerZone : MonoBehaviour
    {
        protected abstract void KillFunction(Player ply);
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player ply))
            {
                KillFunction(ply);
            }
        }
    }
}