using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxe : MonoBehaviour
{
    [SerializeField] int _maxBullets;
    [SerializeField] int _idleDuration;

    float _lastShootReceived;
    int _currentScore;

    void Start()
    {
        _currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dateActuelle = Time.time;

        if(dateActuelle > _lastShootReceived + _idleDuration)
        {
            _currentScore--;
            Debug.Log($"Points perdu poto {_currentScore}");
        }

        /// Si la date actuelle + le temps du dernier tir dépasse le Idle Duration
        /// Alors le score va réduire.
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletMovement bullet = collision.GetComponentInParent<BulletMovement>();

        if (bullet != null)
        {
            _currentScore = _currentScore + 1;
            _lastShootReceived = Time.time;
            //_currentScore++;
            //_currentScore+=2;
            Debug.Log($"Current score {_currentScore}");
            {
                _currentScore = Mathf.Min(_currentScore + 1, _maxBullets);
            }
        } 


    }
}
