using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceParticulesBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    public void ExecuteBehaviour()
    {
        _particles.Play();
    }
}
