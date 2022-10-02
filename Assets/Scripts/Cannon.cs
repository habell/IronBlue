using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Cannon : MonoBehaviour
    {
        [SerializeField]
        private Transform _muzzle;
        
        private MuzzleCannon _muzzleCannon;
        
        private Collider2D _target;

        private void Awake()
        {
            _muzzleCannon = new(_muzzle);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<Player>())
            {
                _target = col;
                _muzzleCannon.SetTarget(_target.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other == _target)
            {
                _target = null;
                _muzzleCannon.SetTarget(null);
            }
        }

        private void FixedUpdate()
        {
            if (_target)
            {
                _muzzleCannon.Update();
            }
        }
    }
}