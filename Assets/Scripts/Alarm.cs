using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _recoveryRate;
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private AudioSource _alarmSound;

    private bool _isEnabled = false;

    private void Start()
    {
        _alarmSound.volume = 0;
    }

    private void Update()
    {
        if (_isEnabled == true)
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
            _isEnabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Crook>(out Crook crook))
        {
            _isEnabled = false;
        }
    }
}
