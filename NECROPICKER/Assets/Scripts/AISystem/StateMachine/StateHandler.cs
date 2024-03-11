using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    [SerializeField] GameObject initialStateContainer;
    IState initialState;
    IState currentState;
    [SerializeField] BehaviourPerformer[] permanentBehaviours;

    void Start()
    {
        initialState = initialStateContainer.GetComponent<IState>();
        currentState = initialState;
        currentState.OnStateEnter();
    }

    private void Update() {
        currentState.OnStateUpdate();

        if(currentState.GetNextState() != null) ChangeState(currentState.GetNextState());

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
