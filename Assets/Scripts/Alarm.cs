using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _recoveryRate;
    [SerializeField] private AudioSource _alarmSound;

    private Coroutine coroutine;
    private bool isCoroituneEnabled = false;

    private void Start()
    {
        _alarmSound.volume = 0;
    }

    public void StartChangeVolumeSound(float targetVolume)
    {
        if (isCoroituneEnabled == true)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(ChangeVolumeSound(targetVolume));
    }

    private IEnumerator ChangeVolumeSound(float targetVolume)
    {
        isCoroituneEnabled = true;

        while (_alarmSound.volume != targetVolume)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }

        if (_alarmSound.volume == 0)
        {
            _alarmSound.Stop();
        }

        isCoroituneEnabled = false;
    }
}
