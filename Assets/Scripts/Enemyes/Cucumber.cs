using System;
using DefaultNamespace;
using Interfaces;
using UnityEngine;

public class Cucumber : MonoBehaviour, IEnemy
{
    [SerializeField]
    private float _damage;

    [SerializeField]
    private float _maxSpeed;

    private Collider2D _detectionZone;

    private Rigidbody2D _rigidbody2D;

    private Transform _target;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _detectionZone = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player ply))
        {
            StartMoveToEnemy(col.transform);
        }
    }

    private void StartMoveToEnemy(Transform colTransform)
    {
        _target = colTransform;
    }

    private void FixedUpdate()
    {
        if (_target)
        {
            //_rigidbody2D.AddForceAtPosition();
            _rigidbody2D.MovePosition(_target.position);
        }
    }
}
