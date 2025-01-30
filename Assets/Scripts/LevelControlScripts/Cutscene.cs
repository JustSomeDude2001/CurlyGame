using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public float duration;  
    public Action OnPlay;

    public void Play() {
        SuspendControls(duration);
        if (OnPlay != null)
            OnPlay.Invoke();
    }

    IEnumerator UnsuspendControls(float duration) {
        while(duration > 0) {
            duration -= Time.deltaTime;
            yield return null;
        }
        Player.ToggleControls(true);
        PlayerVCam.ToggleControls(true);
    }

    private void SuspendControls(float duration) {
        Player.ToggleControls(false);
        PlayerVCam.ToggleControls(false);
        StartCoroutine(UnsuspendControls(duration));
    }
}
