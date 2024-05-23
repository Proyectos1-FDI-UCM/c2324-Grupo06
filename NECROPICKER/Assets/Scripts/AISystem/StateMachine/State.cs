using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
Se encarga de la ejecución de los estados de la IA.
Además contiene un parámetro que guarda el nombre de la animación que se reproduce al entrar en el estado y
*/
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

//Guarda los estados a los que puede transicionar el estado actual y sus respectivas condiciones.
//Posse un método que devuelve el siguiente estado a ejecutar que en caso de que no se cumpla
//ninguna condición de salida, devuelve null.

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
        Condition.InitializeAll(conditions);
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