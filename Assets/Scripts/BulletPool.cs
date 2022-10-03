using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class BulletPool
    {
        private const byte DEFAULT_BULLET_POOL = 5;
        private List<Bullet> _bullets = new();
        private Transform _poolParent;
        private BulletFactory _bulletFactory;

        public Transform PoolParent => _poolParent;

        public BulletPool(Transform poolParent, Bullet bullet)
        {
            _poolParent = new GameObject(NameManager.POOL_AMMO_NAME).transform;
            _poolParent.SetParent(poolParent);
            _poolParent.transform.position = poolParent.position;

            _bulletFactory = new BulletFactory();
            _bulletFactory.SetFactoryBulletPrefab(bullet);

            for (int i = 0; i < DEFAULT_BULLET_POOL; i++)
            {
                CreateBullet();
            }
        }

        public List<Bullet> GetPool()
        {
            return _bullets;
        }

        public Bullet GetBullet()
        {
            foreach (var bullet in _bullets)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    return bullet;
                }
            }

            return CreateBullet();
        }

        public void SetActiveBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.SetParent(null);
        }

        public void ReturnToPool(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            bullet.transform.SetParent(_poolParent);
            bullet.transform.position = _poolParent.position;
        }

        private Bullet CreateBullet()
        {
            var bullet = _bulletFactory.Create();
            bullet.gameObject.SetActive(false);
            bullet.transform.SetParent(_poolParent);
            bullet.transform.position = _poolParent.position;
            _bullets.Add(bullet);
            return bullet;
        }
    }
}