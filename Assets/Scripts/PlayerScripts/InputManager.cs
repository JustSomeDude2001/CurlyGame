using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Player _player;
    private static InputManager _instance;
    private PCControl _inputActions;


    private void Awake() {
        _inputActions = new PCControl();
        _instance = this;
    }

    private void OnEnable() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _inputActions.Enable();
    }

    private void OnDisable() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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

    public bool GetSprintingState() {
        return _inputActions.FP.Sprint.IsPressed();
    }

    public GameObject TryGetRaycastItem() {
        if (_player == null) {
            _player = FindObjectOfType<Player>();
        }
        if (_player == null) {
            return null;
        }
        Vector3 camPos = Camera.main.transform.position;
        Vector3 camDir = Camera.main.transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(camPos, camDir, out hit, _player.maxDisInteraction)) {
            if (hit.collider.GetComponent<Interactive>()) {
                return hit.collider.gameObject;
            } else {
                return null;
            }
        }    
        return null;
    }

    private void Interact(InputAction.CallbackContext context) {
        GameObject result = TryGetRaycastItem();
        if (result == null) {
            return;
        }
        Interactive comp = result.GetComponent<Interactive>();
        if (comp != null) {
            if (comp.CanInteract()) {
                if (comp.OnInteract != null)
                    comp.OnInteract.Invoke();
            } else {
                if (comp.OnFailInteract != null)
                    comp.OnFailInteract.Invoke();
            }
        }
    }

    public void ToggleInteractions(bool state) {
        if (state) {
            _inputActions.FP.Interact.performed += Interact;
        } else {
            _inputActions.FP.Interact.performed -= Interact;
        }
    }

    private void TrackInteractiveItem() {
        GameObject target = TryGetRaycastItem();
        if(target == null) {
            return;
        }
        Interactive interactive = target.GetComponent<Interactive>();
        if (interactive.CanInteract()) {
            if (interactive.OnCanInteract != null)
                interactive.OnCanInteract.Invoke();
        } else {
            if (interactive.OnCannotInteract != null)
                interactive.OnCannotInteract.Invoke();
        }
    }

    void Update() {
        TrackInteractiveItem();
    }
}
