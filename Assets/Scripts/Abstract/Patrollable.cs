using System.Collections.Generic;
using DefaultNamespace;
using Pathfinding;
using UnityEngine;

namespace Abstract
{
    [RequireComponent(typeof(BoxCollider2D), typeof(AIDestinationSetter),
        typeof(Seeker))]
    [RequireComponent(typeof(AIPath), typeof(Rigidbody2D))]
    public abstract class Patrollable : MonoBehaviour, IPatrollable
    {
        private AIDestinationSetter _aiDestinationSetter;

        protected int _targetID;

        [SerializeField]
        protected List<Transform> _positions;


        private void Awake()
        {
            _aiDestinationSetter = GetComponent<AIDestinationSetter>();
            _targetID = 0;
            _aiDestinationSetter.target = _positions[_targetID];
        }

        public void StartPatrol()
        {
            NextPatrolPosition();
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
            if (_targetID > 0 && _targetID % _positions.Count - 1 == 0)
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