using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class State : MonoBehaviour, IState
{
    AnimationPlayer animationPlayer;
    [SerializeField] string stateAnimation = "";

    [SerializeField] BehaviourPerformer[] onEnterPerformers;
    [SerializeField] BehaviourPerformer[] onUpdatePerformers;
    [SerializeField] BehaviourPerformer[] onExitPerformers;

    [SerializeField] bool _negated;
    public bool negated => _negated;

    [SerializeField] GameObject exitConditionContainer;
    ICondition _exitCondition;
    public ICondition exitCondition => _exitCondition;
    [SerializeField] State[] _nextStates = new State[1];
    public State[] nextStates => _nextStates;


    private void Awake()
    {
        if(exitConditionContainer != null) _exitCondition = exitConditionContainer.GetComponent<ICondition>();
        animationPlayer = GetComponentInParent<AnimationPlayer>();
    }


    public void OnStateEnter()
    {
        if(animationPlayer != null) animationPlayer.PlayAnimation(stateAnimation);
        if(onEnterPerformers != null) Perform(onEnterPerformers);
    }

    public void OnStateUpdate()
    {
        if(onUpdatePerformers != null) Perform(onUpdatePerformers);
    }

    public void OnStateExit()
    {
        if(onExitPerformers != null) Perform(onExitPerformers);
    }

    void Perform(BehaviourPerformer[] performers)
    {
        foreach(BehaviourPerformer performer in performers)
        {
            performer.Perform();
        }
    }

    public State GetNextState()
    {
        if(exitCondition.CheckCondition() == !_negated) return _nextStates[Random.Range(0, _nextStates.Length)];
        else return null;
    }
}