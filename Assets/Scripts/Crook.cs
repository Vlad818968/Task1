using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crook : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

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
        _animator.SetBool("IsRun", true);
    }

    public void Idle()
    {
        _state = MoveState.Idle;
        _animator.SetBool("IsRun", false);
    }

    private IEnumerator Wait(float waitingTime)
    {
        while (waitingTime > 0)
        {
            waitingTime -= Time.deltaTime;

            if (waitingTime <= 0)
            {
                Run();
            }

            yield return null;
        }
    }

    enum MoveState
    {
        Idle,
        Run,
    }
}
