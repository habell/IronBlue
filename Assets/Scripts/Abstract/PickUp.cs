﻿using System;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace.Abstract
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class PickUp : MonoBehaviour, IPickUp
    {
        private BoxCollider2D _boxCollider2D;

        protected BoxCollider2D BoxCollider2D => _boxCollider2D;

        protected abstract void Pick(IPickUpable pickuper);
        
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (TryGetComponent(out IPickUpable pickuper))
            {
                Pick(pickuper);
            }
        }
    }
}