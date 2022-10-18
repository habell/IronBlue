using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Cannon : MonoBehaviour
    {
        [SerializeField]
        private Bullet _bulletPrefab;
        
        [SerializeField]
        private Transform _muzzle;

        [SerializeField]
        private Transform _shotPos;
        
        private MuzzleCannon _muzzleCannon;
        
        private Collider2D _target;

        private BulletPool _bulletPool;

        public Transform Muzzle => _muzzle;

        public BulletPool BulletPool => _bulletPool;

        private void Awake()
        {
            _bulletPool = new BulletPool(_shotPos, _bulletPrefab);
            _muzzleCannon = new MuzzleCannon(this);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<Player>())
            {
                _target = col;
                _muzzleCannon.SetTarget(_target.transform);
                StartCoroutine(ShootigTimer());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other == _target)
            {
                _target = null;
                _muzzleCannon.SetTarget(null);
                StartCoroutine(ShootigTimer());
            }
        }

        private void FixedUpdate()
        {
            if (_target)
            {
                _muzzleCannon.FixedUpdate();
            }
        }
        
        private void Shot()
        {
            var bullet = _bulletPool.GetBullet();
            _bulletPool.SetActiveBullet(bullet);
            StartCoroutine(ShotBullet(bullet));
            bullet.RigidBody2D.AddForce(_shotPos.up * 100);
        }
        
        private IEnumerator ShootigTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                Shot();
                if (!_target)
                {
                    yield break;
                }
            }
        }
        
        
        private IEnumerator ShotBullet(Bullet bullet)
        {
            yield return new WaitForSeconds(3);
            _bulletPool.ReturnToPool(bullet);
            yield return null;
        }
    }
}