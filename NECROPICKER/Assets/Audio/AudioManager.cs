using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "NewSoundEffect", menuName = "Audio/New Sound Effect")]
public class AudioManager : ScriptableObject
{
    public AudioClip[] clips;
    public Vector2 volume;
    public Vector2 pitch;
    [SerializeField] int playIndex;
    [SerializeField] private SoundClipOrder playOrder;


    private AudioClip audioClip()
    {
        //utiliza la pista de audio actual
        var clip = clips[playIndex >= clips.Length ? 0 : playIndex];

        //busca la proxima pista de audio
        switch (playOrder)
        {
            case SoundClipOrder.inOrder:
                playIndex = (playIndex + 1) % clips.Length;
                break;
            case SoundClipOrder.random:
                playIndex = Random.Range(0,clips.Length);
                break;
            case SoundClipOrder.reverse:
                playIndex = (playIndex - 1) % clips.Length;
                break;

        }


        return clip;
    }

    public AudioSource Play(AudioSource audioSourceParam = null)
    {
        if (clips.Length == 0)  //por si acaso falta una pista de audio
        {
            Debug.Log($"Falta el clip de audio {name}");
            return null;
        }

        var source = audioSourceParam;
        if (source == null)  //si la fuente de audio no es nula crea una fuente de audio
        {
            var _obj = new GameObject("sound", typeof(AudioSource));
            source = _obj.AddComponent<AudioSource>();
        }


        //configuracion del audio:
        source.clip = clips[0];
        source.volume = Random.Range(volume.x, volume.y);
        source.pitch = Random.Range(pitch.x, pitch.y);
        source.Play();


        Destroy(source.gameObject, source.clip.length / source.pitch);

        return source;

    }

    enum SoundClipOrder
    {
        random,
        inOrder,
        reverse
    }
}
