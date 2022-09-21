using UnityEngine;

public class PlayerMoveController
{
    private float _horizontalInput;
    private float _verticalInput;
    private Player _player;
    private Rigidbody2D _rigidbody2D;

    public PlayerMoveController(Player player, Rigidbody2D rigidbody2D)
    {
        _player = player;
    }
    
    public void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if (_horizontalInput != 0)
        {
            //_rigidbody2D.AddForce();
        }
    }
}