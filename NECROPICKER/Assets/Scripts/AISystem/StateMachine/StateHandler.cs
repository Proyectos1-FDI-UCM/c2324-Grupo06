using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    [SerializeField] State[] states;
    State currentState;
    [SerializeField] BehaviourPerformer[] permanentBehaviours;

    void Start()
    {
        currentState = states[0];
        currentState.OnStateEnter();
    }

    private void Update() {
        currentState.OnStateUpdate();
        
        if(currentState.exitCondition != null)
            if(currentState.exitCondition.CheckCondition()) ChangeState(currentState.nextState);
        
        if(permanentBehaviours != null) PerformPermanentBehaviours();
    }

    public void ChangeState(State newState)
    {
        currentState.OnStateExit();
        currentState = newState;
        currentState.OnStateEnter();
    }

    void PerformPermanentBehaviours()
    {
        foreach(BehaviourPerformer performer in permanentBehaviours)
        {
            performer.Perform();
        }
    }
}
