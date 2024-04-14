using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] string animation;
    
    public void ExecuteBehaviour()
    {
        if (TryGetComponent<Animator>(out Animator animator)) animator.Play(animation); //Está mal hecho, hay que repasarlo si queremos implementarlo finalmente
    }

    private void OnValidate()
    {
        name = "Play " + animation + " animation";
    }
}
