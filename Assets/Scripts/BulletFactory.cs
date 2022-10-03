using UnityEngine;

namespace DefaultNamespace
{
    public class BulletFactory
    {
        private Bullet _bullet;

        public void SetFactoryBulletPrefab(Bullet bullet)
        {
            _bullet = bullet;
        }

        public Bullet Create()
        {
            return Object.Instantiate(_bullet);
        }
    }
}