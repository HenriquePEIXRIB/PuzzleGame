using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
   [SerializeField] GameObject _BulletPreFab;
   [SerializeField] Rigidbody2D _rb;
   [SerializeField] Vector2 _direction;
   [SerializeField] float _speed;
   [SerializeField] float _lifespan;

    [SerializeField] float _cooldown;
    float _cooldownRemaining;

    float _startLife;
   
    public void Start()
    {
        _rb.velocity = _direction * _speed;
        _startLife = Time.time;
    }

    public void Update()
    {
        if (Time.time > _lifespan + _startLife)
        {
            GameObject.Destroy(_BulletPreFab);
        }
    }
}
