using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    [SerializeField] State initialState;
    State currentState;
    [SerializeField] BehaviourPerformer[] permanentBehaviours;

    void Start()
    {
        currentState = initialState;
    }

    private void Update() {
        currentState.OnStateUpdate();

        if (currentState.exitCondition != null)
        {
            int randomState = Random.Range(0, currentState.nextStates.Length - 1);
            if (currentState.exitCondition.CheckCondition() != currentState.negated) ChangeState(currentState.nextStates[randomState]);
        }
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
