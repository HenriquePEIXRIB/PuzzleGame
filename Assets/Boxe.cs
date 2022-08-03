using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boxe : MonoBehaviour
{
    [SerializeField] int _maxBullets;
    [SerializeField] int _idleDuration;
    [SerializeField] Color _onSprite;
    [SerializeField] Color _offSprite;
    [SerializeField] SpriteRenderer[] _gauge;
    [SerializeField] float _réductionSpeedInSeconds;
    [SerializeField] AudioSource _audio;
    [SerializeField] UnityEvent _onBulletReceived;
    [SerializeField] UnityEvent _onObjectComplete;
    [SerializeField] UnityEvent _onLevelFinished;


    float _lastShootReceived;
    float _currentScore;
    private object _onObjectifComplete;

    void Start()
    {
        _currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dateActuelle = Time.time;

        //Si la date actuelle dépasse la date de la derniere bullet + duration


        if (dateActuelle > _lastShootReceived + _idleDuration)
        {
            _currentScore = Mathf.Max(_currentScore - (_réductionSpeedInSeconds + Time.deltaTime),0);
            Debug.Log($"Points perdu {_currentScore}");
        }

        if (Time.time > _lastShootReceived + _idleDuration)
        {
            _currentScore = Mathf.Max(_currentScore - 1, 0);
            Debug.Log($" Current score {_currentScore}");
        }

        for (int i = 0; i < _gauge.Length; i++)
        {
            _gauge[i].color = _offSprite;
            Debug.Log($"Sprite Actuel : {_gauge[i]}");

            float percent = (float)_currentScore / (float)_maxBullets;
            float gaugeCompletion = percent * _gauge.Length;
            Debug.Log(gaugeCompletion);


            if (i < gaugeCompletion)
            {
                _gauge[i].color = _onSprite;
            }

            else
            {
                _gauge[i].color = _offSprite;
            }
            _audio.volume = percent;

        }

       



        /// Si la date actuelle + le temps du dernier tir dépasse le Idle Duration
        /// Alors le score va réduire.
        /// 


        /// Il faut que j'allume les boxes lorsques les bullets travers les boxes.

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
            _onBulletReceived.Invoke();
            {
                _currentScore = Mathf.Min(_currentScore + 1, _maxBullets);
            }
        }
    }
    public bool IsValidated()
    {
        if (_currentScore >= _maxBullets)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
