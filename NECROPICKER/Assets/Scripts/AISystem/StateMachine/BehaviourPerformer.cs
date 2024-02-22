using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BehaviourPerformer
{
    [SerializeField] GameObject conditionContainer;
    ICondition condition;

    [SerializeField] GameObject behaviourContainers;
    IBehaviour[] behaviours;

    bool initialized = false;

    public bool Perform()
    {
        if(!initialized)
        {
            CheckNulls();
            condition = conditionContainer.GetComponent<ICondition>();
            behaviours = behaviourContainers.GetComponents<IBehaviour>();
            initialized = true;
        }

        if(condition.CheckCondition())
        {
            foreach(IBehaviour behaviour in behaviours)
            {
                behaviour.ExecuteBehaviour();
            }
        }
        
        return condition.CheckCondition();
    }

    void CheckNulls()
    {
        if(conditionContainer == null) Debug.LogError("Behaviour Performer is missing a condition container");
        if(behaviourContainers == null) Debug.LogError("Behaviour Performer is missing a behaviour container");
    }
}
