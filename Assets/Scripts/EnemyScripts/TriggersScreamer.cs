using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TriggersScreamer : MonoBehaviour
{
    private CinemachinePOVExtension _cinemachinePOVExtension;
    public CinemachineVirtualCamera originalVCam;
    public CinemachineVirtualCamera newVCam;

    public Enemy enemy;
    public Attention attention;

    public Transform newPOV;
    public Transform newLookAt;

    public List<AudioSource> audioSources;
    public List<Animator> animators;

    void Start() {
        _cinemachinePOVExtension = FindObjectOfType<CinemachinePOVExtension>();
        enemy.OnKill += LockPOV;
        enemy.OnKill += TriggerScreamer;
    }

    private void LockPOV() {
        _cinemachinePOVExtension.enabled = false;
        originalVCam.enabled = false;
        newVCam.enabled = true;
    }

    private void TriggerScreamer() {
        attention.enabled = false;
        for (int i = 0; i < audioSources.Count; i++) {
            audioSources[i].Play();
        }
        for (int i = 0; i < animators.Count; i++) {
            animators[i].SetTrigger("Screamer");
        }
    }

    void Destroy() {
        enemy.OnKill -= LockPOV;
        enemy.OnKill -= TriggerScreamer;
    }
}
