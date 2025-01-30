using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Action OnLoad;

    public void LoadLevel(int target) {
        if (OnLoad != null) {
            OnLoad.Invoke();
        }
        LevelController.GetInstance().StartLevel(target);
    }

    public void RestartLevel() {
        LevelController instance = LevelController.GetInstance();
        LoadLevel(instance.currentLevelIndex);
    }
}
