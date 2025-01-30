using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWithSound : MonoBehaviour
{
    public Cutscene cutscene;

    public List<Behaviour> components;

    public AudioSource audioSource;

    public float delay; 

    IEnumerator DoOnDelay(float delay) {
        while(delay > 0) {
            delay -= Time.deltaTime;
            yield return null;
        }
        audioSource.Play();
        for(int i = 0; i < components.Count; i++) {
            components[i].enabled = false;
        }
    }

    private void DoOnPlay() {
        StartCoroutine(DoOnDelay(delay));
    }

    void Start() {
        cutscene.OnPlay += DoOnPlay;
    }

    void Destroy() {
        cutscene.OnPlay -= DoOnPlay;
    }
}
