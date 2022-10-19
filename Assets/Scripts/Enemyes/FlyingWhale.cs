using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Abstract;
using DefaultNamespace;
using Interfaces;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemyes
{

    public class FlyingWhale : Patrollable, IEnemy
    {
        private const float MIN_DISTANCE_TARGET = 1f;
        private void Awake()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().isKinematic = true;
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
    }
}