using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class State : MonoBehaviour
{
    AnimationPlayer animationPlayer;
    [SerializeField] string stateAnimation = "";

    [SerializeField] BehaviourPerformer[] onEnterPerformers;
    [SerializeField] BehaviourPerformer[] onUpdatePerformers;
    [SerializeField] BehaviourPerformer[] onExitPerformers;

    [SerializeField] GameObject exitConditionContainer;
    ICondition _exitCondition;
    public ICondition exitCondition => _exitCondition;


    private void Awake()
    {
        if(exitConditionContainer != null) _exitCondition = exitConditionContainer.GetComponent<ICondition>();
        animationPlayer = GetComponentInParent<AnimationPlayer>();
    }

    [SerializeField] State _nextState;
    public State nextState => _nextState;

    public void OnStateEnter()
    {
        if(animationPlayer != null) animationPlayer.PlayAnimation(stateAnimation); Debug.Log("Mal, no hace cosas");
        if(onEnterPerformers != null) Perform(onEnterPerformers); Debug.Log("Mal, no lo pilla bien");
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
}
