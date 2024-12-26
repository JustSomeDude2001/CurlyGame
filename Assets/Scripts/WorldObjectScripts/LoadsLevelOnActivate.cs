using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactive))]
public class LoadsLevelOnActivate : MonoBehaviour
{
    Interactive _interactive;

    public LevelLoader levelLoader;
    public int targetLevel;

    private void LoadNextLevel() {
        levelLoader.LoadLevel(targetLevel);
    }

    void Start() {
        _interactive = GetComponent<Interactive>();
        _interactive.OnInteract += LoadNextLevel;
    }

    void Destroy() {
        _interactive.OnInteract -= LoadNextLevel;
    }
}
