using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _recoveryRate;
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private AudioSource _alarmSound;

    private bool _isSoundEnabled = false;

    private void Start()
    {
        _alarmSound.volume = 0;
    }

    private void Update()
    {
        if (_isSoundEnabled == true)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, 1f, _recoveryRate * Time.deltaTime);
        }
        else
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, 0f, _recoveryRate * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Crook>(out Crook crook))
        {
            _reached.Invoke();
            _isSoundEnabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Crook>(out Crook crook))
        {
            _isSoundEnabled = false;
        }
    }
}
