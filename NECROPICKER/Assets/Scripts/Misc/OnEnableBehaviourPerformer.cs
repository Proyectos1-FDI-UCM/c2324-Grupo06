using UnityEngine;

public class OnEnableBehaviourPerformer : MonoBehaviour
{/// <summary>
/// Se encarga de ejecutar los Behaviours que le asignemos
/// </summary>
    [SerializeField] BehaviourPerformer[] behaviours;

    private void Awake() => OnEnable();

    private void OnEnable()
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.Perform();
        }
    }
}