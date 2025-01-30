using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int target) {
        LevelController.GetInstance().StartLevel(target);
    }

    public void RestartLevel() {
        LevelController instance = LevelController.GetInstance();
        instance.StartLevel(instance.currentLevelIndex);
    }
}
