using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private int _numberOfIterations;
    [SerializeField] BehaviourIteration[] _behavioursToRepeat;
    public void ExecuteBehaviour()
    {
        StartCoroutine(Repeat());
    }
    private IEnumerator Repeat()
    {
        for(int i = 0; i < _numberOfIterations; i++)
        {
            foreach (BehaviourIteration iteration in _behavioursToRepeat)
            {
                iteration.BehaviourContainer.GetComponent<IBehaviour>().ExecuteBehaviour();
                float _waitTime = Random.Range(_behavioursToRepeat[i].MinTime, _behavioursToRepeat[i].MaxTime);
                yield return new WaitForSeconds(_waitTime);
            }
        }
    }
    private void OnValidate()
    {
        name = "Repeat behaviour";
    }
}
[System.Serializable]
public class BehaviourIteration
{
    [SerializeField] private GameObject _behaviourContainer;
    public GameObject BehaviourContainer => _behaviourContainer;
    
    [SerializeField] private float _mintime;
    public float MinTime => _mintime;

    [SerializeField] private float _maxtime;
    public float MaxTime => _maxtime;
}
