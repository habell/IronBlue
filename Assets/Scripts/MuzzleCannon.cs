using System;
using System.Collections;
using DefaultNamespace.Interfaces;
using UnityEngine;

namespace DefaultNamespace
{
    public class MuzzleCannon
    {
        private Transform _muzzle;

        private Transform _aim;

        private readonly Cannon _cannon;

        public MuzzleCannon(Cannon cannon)
        {
            _cannon = cannon;
            _muzzle = _cannon.Muzzle;
        }

        public void SetTarget(Transform target)
        {
            _aim = target;
        }

        public void Update()
        {
            if (!_aim) return;
            var dir = _muzzle.position - _aim.position;
            _muzzle.rotation =
                Quaternion.AngleAxis(Vector2.Angle(Vector2.down, dir), Vector3.Cross(Vector2.down, dir));
        }

    }
}