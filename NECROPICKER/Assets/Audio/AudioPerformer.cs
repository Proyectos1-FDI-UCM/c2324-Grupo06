using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPerformer : MonoBehaviour
{

    AudioPlayer[] _audioPlayer;
    static private AudioPerformer _instance;
    private void Awake()
    {
        Screen.SetResolution(1280, 960, true);

        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            _audioPlayer = Resources.LoadAll<AudioPlayer>("SoundPlayers");

            for (int i = 0; i < _audioPlayer.Length; i++)
            {
                AudioSource currentSource = gameObject.AddComponent<AudioSource>();

                _audioPlayer[i].OnAudioPlay.
                AddListener((AudioClip clip, float volume, float pitch, bool loop) =>
                    {
                        currentSource.volume = volume;
                        currentSource.pitch = pitch;
                        currentSource.clip = clip;
                        currentSource.loop = loop;
                        currentSource.Play();
                    }
                );

                _audioPlayer[i].OnAudioStop.AddListener(() => currentSource.Stop());
            }
        }
    }
}
