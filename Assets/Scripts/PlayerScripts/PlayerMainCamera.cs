using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerMainCamera : MonoBehaviour
{
    public CinemachineBrain cinemachineBrain;

    private static PlayerMainCamera _instance;
    void Awake()
    {
        _instance = this;
    }

    public static PlayerMainCamera GetInstance() {
        return _instance;   
    }

    public static void ToggleControls(bool state) {
        GetInstance().cinemachineBrain.enabled = state;
    } 
}
