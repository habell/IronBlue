using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private float _damage;

        public Rigidbody2D RigidBody2D => _rigidbody2D;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (TryGetComponent(out IHealth obj))
            {
                obj.Hit(_damage);
            }
            gameObject.SetActive(false);
        }
    }
}