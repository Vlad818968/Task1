using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _recoveryRate;
    [SerializeField] private AudioSource _alarmSound;

    private Coroutine _changeVolume;

    private void Start()
    {
        _alarmSound.volume = 0;
    }

    public void StartChangeVolumeSound(float targetVolume)
    {
        if (_changeVolume!=null)
        {
            StopCoroutine(_changeVolume);
        }

        _changeVolume = StartCoroutine(ChangeVolumeSound(targetVolume));
    }

    private IEnumerator ChangeVolumeSound(float targetVolume)
    {
        while (_alarmSound.volume != targetVolume)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }

        if (_alarmSound.volume == 0)
        {
            _alarmSound.Stop();
        }
    }
}
