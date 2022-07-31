using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crook : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private MoveState _state=MoveState.Idle;
    private bool _isReached;
    private float _waitingTime = 7;

    private void Start()
    {
        Run();
    }

    private void Update()
    {
        if (_state == MoveState.Run)
        {
            transform.Translate(_speed*Time.deltaTime,0,0);
        }

        if (_isReached == true)
        {
            _waitingTime -= Time.deltaTime;

            if (_waitingTime <= 0)
            {
                Run();
                _isReached = false;
            }
        }
    }

    public void Reachet()
    {
        _isReached = true;
    }

    public void Run()
    {
        _state= MoveState.Run;
        _animator.SetBool("IsRun", true);
    }

    public void Idle()
    {
        _state = MoveState.Idle;
        _animator.SetBool("IsRun", false);
    }

    enum MoveState
    {
        Idle,
        Run,
    }
}
