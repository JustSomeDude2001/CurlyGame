using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private static LevelController _instance;
    public List<GameObject> levels;
    private int _currentLevelIndex;

    void Start()
    {
        _instance = this;
    }

    public static LevelController GetInstance() {
        return _instance;
    }

    private void LoadLevel(int index) {
        GameObject currentLevel = FindObjectOfType<Level>().gameObject;
        if (currentLevel != null) {
            Destroy(currentLevel);
        }
        Instantiate(levels[index], Vector3.zero, Quaternion.identity);
        _currentLevelIndex = index;
    }

    IEnumerator NextLevelCoroutine(float timer, int nextLevelIndex) {
        while (timer > 0) {
            timer -= Time.deltaTime;
            yield return null;
        }
        LoadLevel(nextLevelIndex);
    }

    IEnumerator LossSequence(float timer) {
        //TODO
        Debug.Log("You lost");
        yield return null;   
    }
    
    IEnumerator WinSequence(float timer) {
        //TODO
        Debug.Log("You won");
        yield return null;
    }

    IEnumerator TransitionSequence(float timer) {
        //TODO
        Debug.Log("Loading specific level");
        yield return null;
    }

    public void RestartLevel(float timer) {
        StartCoroutine(LossSequence(timer));
        StartCoroutine(NextLevelCoroutine(timer, _currentLevelIndex));
    }

    public void LoadNextLevel(float timer) {
        StartCoroutine(WinSequence(timer));
        StartCoroutine(NextLevelCoroutine(timer, _currentLevelIndex + 1));
    }

    public void LoadSpecificLevel(int targetLevel) {
        StartCoroutine(TransitionSequence(0.3f));
        StartCoroutine(NextLevelCoroutine(0.3f, targetLevel));
    }
}
