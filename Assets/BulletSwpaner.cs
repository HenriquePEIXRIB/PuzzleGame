using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwpaner : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _spawnCooldown;

    //[SerializeField] Vector2 _minMax;


    [SerializeField] float _min;
    [SerializeField] float _max;


    float _lastShoot;

    private void Update() 
    {
        //Random. 

        float rx = Random.Range(_min, _max);
        float ry = Random.Range(_min, _max);
        Vector3 randomDirection = new Vector3(rx, ry);

        if(Time.time > _lastShoot + _spawnCooldown)
        {

            _lastShoot = Time.time;
            GameObject.Instantiate(_bulletPrefab, transform.position + randomDirection, transform.rotation);
        }
    }
}
