using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Player Target;

    public bool needToTransit { get; protected set; }
    public State TargetState => _targetState;

    public void Initialize(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        needToTransit = false;
    }
}