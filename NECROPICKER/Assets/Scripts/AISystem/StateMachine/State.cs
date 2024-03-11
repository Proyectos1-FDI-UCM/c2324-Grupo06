using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class State : MonoBehaviour, IState
{
    AnimationPlayer animationPlayer;
    [SerializeField] string stateAnimation = "";

    [Header("PERFORMERS")]

    [SerializeField] BehaviourPerformer[] onEnterPerformers;
    [SerializeField] BehaviourPerformer[] onUpdatePerformers;
    [SerializeField] BehaviourPerformer[] onExitPerformers;

    [Header("EXIT")]
    [SerializeField] NextStatePerformer[] nextStates;
    public NextStatePerformer[] NextStates => nextStates;

    private void Awake()
    {
        animationPlayer = GetComponentInParent<AnimationPlayer>();
        NextStatePerformer.InitializeAll(nextStates);

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

    public IState GetNextState() => NextStatePerformer.GetNextState(nextStates);
}

[System.Serializable]
public class NextStatePerformer
{
    [SerializeField] Condition[] conditions;
    public bool value => Condition.CheckAllConditions(conditions);
    [SerializeField] GameObject stateContainer;
    IState state;

    public static IState GetNextState(NextStatePerformer[] nextStates)
    {
        foreach(NextStatePerformer nextState in nextStates)
        {
            if(nextState.value) return nextState.state;
        }
        return null;
    }

    public void Initialize()
    {
        state = stateContainer.GetComponent<IState>();
    }

    public static void InitializeAll(NextStatePerformer[] nextStates)
    {
        foreach(NextStatePerformer nextState in nextStates)
        {
            nextState.Initialize();
        }
    }
}



// // [System.Serializable]
// // public class NextStatePerformerNestingConditional
// {
//     [SerializeField] Condition[] conditions;
//     public bool value => Condition.CheckAllConditions(conditions);
//     [SerializeField] NextStatePerformer[] nextStates;

//     public static IState GetNextState(NextStatePerformerNestingConditional[] nextStates)
//     {
//         foreach(NextStatePerformerNestingConditional nextState in nextStates)
//         {
//             if(nextState.value) return NextStatePerformer.GetNextState(nextState.nextStates);
//         }
//         return null;
//     }

//     public void Initialize()
//     {
//         foreach(NextStatePerformer nextState in nextStates)
//         {
//             nextState.Initialize();
//         }
//     }
// }