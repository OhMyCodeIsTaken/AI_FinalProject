using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseStateHandler : MonoBehaviour
{
    [SerializeField] private List<CoroutineState> states = new List<CoroutineState>();
    //[SerializeField] private Enemy refEnemy;
    private CoroutineState activeState;
    private Coroutine _runningRoutine;
    private Coroutine _runningState;

    [SerializeField] public Spaceship Spaceship;

    //public Enemy RefEnemy { get => refEnemy; }

    private void Start()
    {
        SortStates();
        SubscribeHandler();
        _runningRoutine = StartCoroutine(RunStateMachine());
    }


    private IEnumerator RunStateMachine(CoroutineState givenState = null)
    {
        while (gameObject.activeInHierarchy)
        {
            if (!ReferenceEquals(activeState, null))
            {
                StopCoroutine(activeState.RunState());
                activeState.OnStateExit();
            }

            if(!ReferenceEquals(givenState, null))
            {
                if(_runningState != null)
                {
                    StopCoroutine(_runningState);
                }
                activeState = givenState;
                givenState = null;
            }
            else
            {
                activeState = GetNextState();
            }       
            
            activeState.OnStateEnter();
            _runningState = StartCoroutine(activeState.RunState());
            yield return _runningState;
        }
    }
    private void SortStates()
    {
        states.Sort((p1, p2) => p1.Priority.CompareTo(p2.Priority));
    }
    private void SubscribeHandler()
    {
        foreach (var item in states)
        {
            item.CacheHandler(this);
        }
    }

    private CoroutineState GetNextState()
    {
        foreach (var item in states)
        {
            if (item.IsLegal())
            {
                return item;
            }
        }
        return null;
    }

    public void Interrupt(CoroutineState givenState)
    {
        if(_runningRoutine != null)
        {
            StopCoroutine(_runningRoutine);
        }
        _runningRoutine = StartCoroutine(RunStateMachine(givenState));

    }



}
