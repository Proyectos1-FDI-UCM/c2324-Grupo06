using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFeedBack : MonoBehaviour, IFeedBack
{
    public ParticleSystem particle;
    public void PlayFeedBack() => particle.Play();
}