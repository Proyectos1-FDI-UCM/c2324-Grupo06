using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPerformer : MonoBehaviour
{

    [SerializeField] AudioPlayer[] _audioPlayer;

    private void Awake()
    {
        for (int i = 0; i < _audioPlayer.Length; i++)
        {
            AudioSource currentSource = gameObject.AddComponent<AudioSource>();

            _audioPlayer[i].OnAudioPlay.
            AddListener((AudioClip clip, float volume, float pitch) =>
                {
                    currentSource.volume = volume;
                    currentSource.pitch = pitch;
                    currentSource.clip = clip;
                    currentSource.Play();
                }
            );
        }

    }
}
