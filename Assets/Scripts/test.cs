using UnityEngine;

public class test : MonoBehaviour
{
    private Transform _player;
    public Transform Enemy;
    private Vector3 _relativePos;
    private Quaternion _rotation;

    [SerializeField]
    private float _speed = 1;
    private void Awake()
    {
        _player = gameObject.transform;
    }

    // Update is called once per frame  
    private void Update()
    {
        _relativePos = Enemy.position - _player.position;

        Vector3 dir = Vector3.RotateTowards(_player.forward, _relativePos, 0.03f, 10f);
        Debug.DrawRay(_player.position, dir, Color.yellow);
        Debug.DrawLine(_player.position, Enemy.position, Color.cyan);
        _rotation = Quaternion.LookRotation(dir);
        //_rotation = Quaternion.LookRotation(_relativePos);
        //Debug.DrawRay(_player.position, _relativePos, Color.magenta);
        //_rotation = Quaternion.Slerp(_player.rotation,_rotation, 0.05f);
        _player.rotation = _rotation;
        
        _player.position = Vector3.MoveTowards(_player.position, Enemy.position, _speed);   
        
        //print(Quaternion.Angle(Enemy.rotation, _player.rotation));
    }
}
