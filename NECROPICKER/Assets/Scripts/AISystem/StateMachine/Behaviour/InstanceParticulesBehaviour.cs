using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reproduce las partículas de un sistema de partículas.
public class InstanceParticulesBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    public void ExecuteBehaviour() => _particles.Play();
}
