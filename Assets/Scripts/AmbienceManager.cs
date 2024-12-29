using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> clips;

    void Start() {
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        if(!audioSource.isPlaying) {
            audioSource.clip = clips[(int)(Random.Range(0, clips.Count - 1))];
            audioSource.Play();
        }
    }
}
