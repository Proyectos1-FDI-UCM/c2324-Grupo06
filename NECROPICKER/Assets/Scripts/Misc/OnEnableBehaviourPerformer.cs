using UnityEngine;

public class OnEnableBehaviourPerformer : MonoBehaviour
{
    [SerializeField] BehaviourPerformer[] behaviours;

    private void OnEnable()
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.Perform();
        }
    }
}