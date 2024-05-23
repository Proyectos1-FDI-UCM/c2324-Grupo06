using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Este comportamiento se utiliza para cambiar el estado de la máquina de estados.
public class ChangeStateBehaviour : MonoBehaviour, IBehaviour
{
    StateHandler stateHandler;
    [SerializeField] State stateToChangeTo;

    private void Awake() 
    {
        stateHandler = GetComponentInParent<StateHandler>();
    }

    public void ExecuteBehaviour()
    {
        stateHandler.ChangeState(stateToChangeTo);
    }

    private void OnValidate() 
    {
        if(stateToChangeTo != null)
        {
          name = "ChangeToState => " + stateToChangeTo.name;
        }          
    }
}