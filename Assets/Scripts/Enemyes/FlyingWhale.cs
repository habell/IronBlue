using System;
using System.Collections.Generic;
using Interfaces;
using Pathfinding;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class FlyingWhale : MonoBehaviour, IEnemy, IPatrollable
    {
        private AIDestinationSetter _aiDestinationSetter;

        private int _targetID;

        [SerializeField]
        private List<Transform> _positions;
        private void Awake()
        {
            _targetID = 0;
            _aiDestinationSetter.target = _positions[_targetID];
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player ply))
            {
                _aiDestinationSetter.target = ply.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player ply))
            {
                print("it is ply");
            }
        }

        public void StartHunt(Transform victim)
        {
            throw new System.NotImplementedException();
        }

        void IPatrollable.StopHunt()
        {
            throw new System.NotImplementedException();
        }

        void IPatrollable.StartPatrol()
        {
            throw new System.NotImplementedException();
        }
    }
}