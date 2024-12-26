using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int target) {
        LevelController.GetInstance().LoadSpecificLevel(target);
    }
}
