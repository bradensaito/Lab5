using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound {

    public string name;
    public AudioClip clip;

    public float volume;
    public float pitch;

    private AudioSource source;

    public void SetSource(AudioSource fromSource)
    {
        source = fromSource;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
}


public class AudioManager : MonoBehaviour {

    [SerializeField]
    Sound[] sounds;

    void Start()
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string _name)
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].name == _name)
            {
                sounds[i].Play();
                Debug.LogWarning("Played sound" + _name);
                return;
            }
            return;
        }

        Debug.LogWarning("Not found");
    }
}
