using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnKill : MonoBehaviour
{
    private Enemy _enemy;
    public List<GameObject> gameObjects;
    public List<bool> targetStates;
    public float delay;

    void Start() {
        _enemy = GetComponent<Enemy>();
        _enemy.OnKill += ToggleStatesDelayed;
    }

    IEnumerator ToggleStatesDelayedCoroutine(float delay) {
        yield return new WaitForSeconds(delay);
        ToggleStates();
    }

    private void ToggleStatesDelayed() {
        StartCoroutine(ToggleStatesDelayedCoroutine(delay));
    }

    private void ToggleStates() {
        for (int i = 0; i < gameObjects.Count; i++) {
            gameObjects[i].SetActive(targetStates[i]);
        }
    }

    void Destroy() {
        _enemy.OnKill -= ToggleStatesDelayed;
    }
}
