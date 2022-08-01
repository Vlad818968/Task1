using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crook : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    private HashAnimationNames _animationHashes = new HashAnimationNames();
    private MoveState _state = MoveState.Idle;
    private float _waitingTime = 7;

    private void Start()
    {
        Run();
    }

    private void Update()
    {
        if (_state == MoveState.Run)
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
    }

    public void StartWait()
    {
        StartCoroutine(Wait(_waitingTime));
    }

    public void Run()
    {
        _state = MoveState.Run;
        _animator.SetBool(_animationHashes.Run, true);
    }

    public void Idle()
    {
        _state = MoveState.Idle;
        _animator.SetBool(_animationHashes.Run, false);
    }

    private IEnumerator Wait(float waitingTime)
    {
        var waitForSeconds = new WaitForSeconds(waitingTime);
        yield return waitForSeconds;
        Run();
    }

    enum MoveState
    {
        Idle,
        Run,
    }
}
