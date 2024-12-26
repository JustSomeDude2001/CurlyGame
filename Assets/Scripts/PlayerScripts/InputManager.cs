using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    private PCControl _inputActions;

    private void Awake() {
        if (_instance != null) {
            throw new Exception("Attempting to create a second input manager");   
        }
        _inputActions = new PCControl();
        _instance = this;
    }

    private void OnEnable() {
        _inputActions.Enable();
    }

    private void OnDisable() {
        _inputActions.Disable();
    }

    public static InputManager GetInstance() {
        return _instance;
    }

    public Vector2 GetPlayerMovement() {
        return _inputActions.FP.Move.ReadValue<Vector2>();
    }
    
    public Vector2 GetMouseDelta() {
        return _inputActions.FP.Look.ReadValue<Vector2>();
    }
}
