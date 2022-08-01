using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] float _circleSize;
    [SerializeField] GameObject _BulletPreFab;
    [SerializeField] float _cooldown;
     float _cooldownRemaining;





    private void Start()
    {
        _cooldownRemaining = _cooldown;
        

    }

    
    void Update()
    {


        _cooldownRemaining = _cooldownRemaining - Time.deltaTime;
        //Debug.Log(_cooldownRemaining);

        if (_cooldownRemaining < 0)
        {

            //float rx = Random.Range(_min,_max);
            // float ry = Random.Range(_min, _max);
            Vector3 rdirection = Random.insideUnitCircle * _circleSize;

            GameObject.Instantiate(_BulletPreFab, transform.position + rdirection, transform.rotation);
            _cooldownRemaining = _cooldown;
        }
    }
}
