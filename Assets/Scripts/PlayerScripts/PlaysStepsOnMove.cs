using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaysStepsOnMove : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> clips;
    private PlayerController _playerController;

    private void TryPlayStep() {
        if(!audioSource.isPlaying) {
            audioSource.clip = clips[Random.Range(0, clips.Count - 1)];
            audioSource.Play();
        }
    }

    void Start() {
        _playerController = GetComponent<PlayerController>();
        _playerController.OnMove += TryPlayStep;
    }

    void Destroy() {
        _playerController.OnMove -= TryPlayStep;
    }
}
