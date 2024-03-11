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
        currentState.transform.gameObject.name = "current";
    }

    private void Update() {
        currentState.OnStateUpdate();

        IState newState = currentState.GetNextState();

        if(newState != null)
        {
            ChangeState(newState);
        }

        if(permanentBehaviours != null) PerformPermanentBehaviours();
        
    }

    public void ChangeState(IState newState)
    {
        currentState.OnStateExit();
        currentState.transform.gameObject.name = "passed";

        currentState = newState;
        
        currentState.OnStateEnter();
        currentState.transform.gameObject.name = "current";
    }

    void PerformPermanentBehaviours()
    {
        foreach(BehaviourPerformer performer in permanentBehaviours)
        {
            performer.Perform();
        }
    }
}
