using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private PlayerMoveController _playerMoveController;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
        _playerMoveController = new PlayerMoveController(this, _rigidbody2D);
    }

    private void Update()
    {
        _playerMoveController.Update();
    }
}
