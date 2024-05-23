using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Detiene las partículas de un sistema de partículas determinado.
public class StopParticlesBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    public void ExecuteBehaviour()
    {
        _particles.Stop();
    }
}
