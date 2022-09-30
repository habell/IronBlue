using DefaultNamespace;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerMoveController
{
    private float _horizontalInput;
    private Player _player;
    private Rigidbody2D _rigidbody2D;
    private bool _jumped;
    private PlayerData _parameters;

    public PlayerMoveController(Player player, Rigidbody2D rigidbody2D)
    {
        _player = player;
        _rigidbody2D = rigidbody2D;
        _rigidbody2D.freezeRotation = true;
        _jumped = false;
        _parameters = _player.PlayerParameters.Parameters;
    }
    
    public void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if (_horizontalInput != 0)
        {
            if (_rigidbody2D.velocity.x < _parameters.MaxSpeed & _rigidbody2D.velocity.x > -_parameters.MaxSpeed)
            {
                _rigidbody2D.AddForce(Vector2.right * (_horizontalInput * 10));
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_rigidbody2D.velocity.y < 0.001 & _rigidbody2D.velocity.y > -0.001 & _jumped)
            {
                _jumped = false;
            }
            if (!_jumped)
            {
                _jumped = true;
                _rigidbody2D.AddForce(Vector2.up * _parameters.MaxJumpValue);   
            }
        }
        
        
    }
}