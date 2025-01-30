using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private static LevelController _instance;
    public List<GameObject> levels;
    public List<GameObject> cutscenes;
    public int currentLevelIndex;
    public int currentCutsceneIndex;

    void Start()
    {
        _instance = this;
    }

    public static LevelController GetInstance() {
        return _instance;
    }

    private void LoadLevel(int index) {
        GameObject oldLevel = FindObjectOfType<Level>().gameObject;
        if (oldLevel != null) {
            Destroy(oldLevel);
        }
        Instantiate(levels[index], Vector3.zero, Quaternion.identity);
        currentLevelIndex = index;
    }

    private void LoadCutscene(int index) {
        Cutscene oldCutscene = FindObjectOfType<Cutscene>();
        if (oldCutscene != null) {
            Destroy(oldCutscene.gameObject);
        }
        if (cutscenes[index] != null) {
            GameObject newCutscene = Instantiate(cutscenes[index], Vector3.zero, Quaternion.identity);
            if (newCutscene.TryGetComponent<Cutscene>(out Cutscene cutsceneComponent)) {
                cutsceneComponent.Play();
            }
        }
        currentCutsceneIndex = index;
    }

    public void StartLevel(int index) {
        LoadLevel(index);
        LoadCutscene(index);
    }
}
