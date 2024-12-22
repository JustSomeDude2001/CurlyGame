using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    private PCControl inputActions;

    private void Awake() {
        if (instance != null) {
            throw new Exception("Attempting to create a second input manager");   
        }
        inputActions = new PCControl();
        instance = this;
    }

    private void OnEnable() {
        inputActions.Enable();
    }

    private void OnDisable() {
        inputActions.Disable();
    }

    public static InputManager GetInstance() {
        return instance;
    }

    public Vector2 GetPlayerMovement() {
        return inputActions.FP.Move.ReadValue<Vector2>();
    }
    
    public Vector2 GetMouseDelta() {
        return inputActions.FP.Look.ReadValue<Vector2>();
    }
}
