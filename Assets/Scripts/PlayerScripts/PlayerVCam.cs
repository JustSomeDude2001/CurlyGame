using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVCam : MonoBehaviour
{
    private static PlayerVCam _instance;
    void Awake()
    {
        _instance = this;
    }

    public static PlayerVCam GetInstance() {
        return _instance;
    }

    public static void ToggleControls(bool state) {
        if (GetInstance() != null)
            GetInstance().gameObject.SetActive(state);
    } 
}
