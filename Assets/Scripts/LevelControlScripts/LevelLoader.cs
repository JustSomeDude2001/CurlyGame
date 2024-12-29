using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int target) {
        LevelController.GetInstance().LoadSpecificLevel(target);
    }

    public void RestartLevel() {
        LevelController instance = LevelController.GetInstance();
        instance.LoadSpecificLevel(instance.currentLevelIndex);
    }
}
