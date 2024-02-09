using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioClip[] effects;
    public AudioSource EffectsSource;
    public AudioSource MusicSource;
    public static AudioController Instance = null;
    // Start is called before the first frame update
   
    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        //if (!audioSource.isPlaying)
        if (!MusicSource.isPlaying)
        {
            MusicSource.clip = GetRandomClip();
            MusicSource.Play();
        }
    }

    public void RandomSoundEffect(int j)
    {
        EffectsSource.clip = effects[j];
        EffectsSource.PlayOneShot(EffectsSource.clip);
    }
}
