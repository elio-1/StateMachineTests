using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CubeState
{
    RED,
    BLUE,
    GREEN,
    ORANGE
}
public class StateMachine : MonoBehaviour
{
    private MeshRenderer _renderer;
    private CubeState _currentState;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        TransitionToState(CubeState.RED);
    }
    private void Update()
    {
        OnStateUpdate();
    }

    void OnStateEnter()
    {
        switch (_currentState)
        {
            case CubeState.RED:
                _renderer.material.color = Color.red;    
                break;
            case CubeState.BLUE:
                _renderer.material.color = Color.blue;
                break;
            case CubeState.GREEN:
                _renderer.material.color = Color.green;
                break;
            case CubeState.ORANGE:
                _renderer.material.color = Color.cyan;
                break;
            default:
                break;
        }
    }
    void OnStateUpdate()
    {
        switch (_currentState)
        {
            case CubeState.RED:
                Jump(CubeState.BLUE);
                break;
            case CubeState.BLUE:
                Jump(CubeState.GREEN);
                break;
            case CubeState.GREEN:
                Jump(CubeState.ORANGE);
                break;
            case CubeState.ORANGE:
                Jump(CubeState.RED);
                break;
            default:
                break;
        }

    }
    void OnStateExit()
    {
        switch (_currentState)
        {
            case CubeState.RED:
                Debug.Log(_currentState + " exit");
                break;
            case CubeState.BLUE:
                Debug.Log(_currentState + " exit");
                break;
            case CubeState.GREEN:
                Debug.Log(_currentState + " exit");
                break;
            case CubeState.ORANGE:
                Debug.Log(_currentState + " exit");

                break;
            default:
                break;
        }
    }
    void TransitionToState(CubeState toState)
    {
        OnStateExit();
        _currentState = toState;
        OnStateEnter();
    }
    private void Jump(CubeState cube)
    {
        if (Input.GetButtonDown("Jump"))
        {
            TransitionToState(cube);
        }
    }
}
