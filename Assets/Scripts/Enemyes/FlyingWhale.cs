using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DefaultNamespace;
using Interfaces;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemyes
{
    [RequireComponent(typeof(BoxCollider2D), typeof(AIDestinationSetter),
        typeof(Seeker))]
    [RequireComponent(typeof(AIPath), typeof(Rigidbody2D))]
    public class FlyingWhale : MonoBehaviour, IEnemy, IPatrollable
    {
        private const float MIN_DISTANCE_TARGET = 1f;
        private AIDestinationSetter _aiDestinationSetter;

        private int _targetID;

        [SerializeField]
        private List<Transform> _positions;

        private void Awake()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().isKinematic = true;

            _aiDestinationSetter = GetComponent<AIDestinationSetter>();
            _targetID = 0;
            _aiDestinationSetter.target = _positions[_targetID];
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player ply))
            {
                StartHunt(ply.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player ply))
            {
                NextPatrolPosition();
            }
        }

        private void FixedUpdate()
        {
            if (Vector2.Distance(transform.position, _positions[_targetID].position) < MIN_DISTANCE_TARGET)
            {
                NextPatrolPosition();
            }
        }

        public void StartPatrol()
        {
            throw new System.NotImplementedException();
        }

        public void StartHunt(Transform victim)
        {
            _aiDestinationSetter.target = victim;
        }

        public void StopHunt()
        {
            throw new System.NotImplementedException();
        }

        public void NextPatrolPosition()
        {
            if (_targetID > 0 && _targetID % _positions.Count-1 == 0)
            {
                _targetID = 0;
            }
            else
            {
                _targetID++;
            }

            _aiDestinationSetter.target = _positions[_targetID];
        }
    }
}