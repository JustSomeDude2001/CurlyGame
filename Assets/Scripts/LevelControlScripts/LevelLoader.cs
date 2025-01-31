using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LevelLoader : MonoBehaviour
{
    public Action OnLoad;
    private bool _startedLoading = false;

    IEnumerator LoadAfterAd(int target) {
        while(true) {
            yield return null;
            if (YG2.nowInterAdv) {
                continue;
            }
            break;
        }
        if (OnLoad != null) {
            OnLoad.Invoke();
        }
        LevelController.GetInstance().StartLevel(target);
    }

    public void LoadLevel(int target) {
        if (_startedLoading) {
            return;
        }
        _startedLoading = true;  
        StartCoroutine(LoadAfterAd(target));
    }

    public void RestartLevel() {
        LevelController instance = LevelController.GetInstance();
        int target = instance.currentLevelIndex;
        if (_startedLoading) {
            return;
        }
        _startedLoading = true;  
        StartCoroutine(LoadAfterAd(target));
    }
}
