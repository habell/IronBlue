using System;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerParameters _playerParameters;

    private PlayerMoveController _playerMoveController;
    
    private Rigidbody2D _rigidbody2D;

    private Health _health;

    public Health Health => _health;

    public PlayerParameters PlayerParameters => _playerParameters;

    private void Awake()
    {
        if (!_playerParameters) throw new Exception("ERROR!! PLEASE ADD Player parameters scriptable obj!");
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
        _playerMoveController = new PlayerMoveController(this, _rigidbody2D);
        _health = new PlayerHealth(_playerParameters.Parameters.Health);
    }

    private void Update()
    {
        _playerMoveController.Update();
    }
}
