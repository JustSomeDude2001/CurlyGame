using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public Cutscene cutscene;
    public Material material;
    public float duration;

    IEnumerator FadeInTIme(float duration) {
        float remainingDuration = duration;
        while(remainingDuration > 0) {
            remainingDuration -= Time.deltaTime;
            float currentVisibility = Mathf.InverseLerp(duration, 0, remainingDuration);
            material.SetFloat("_Visibility", currentVisibility);
            yield return null;
        }
    }

    public void StartFading() {
        StartCoroutine(FadeInTIme(duration));
    }

    void Awake() {
        cutscene.OnPlay += StartFading;
    }

    void OnDestroy() {
        cutscene.OnPlay -= StartFading;
    }
    
}
