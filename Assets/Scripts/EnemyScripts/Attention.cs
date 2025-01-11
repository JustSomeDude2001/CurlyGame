using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Attention : MonoBehaviour
{
    public float current = 0f;
    public float min = 0f;
    public float max = 100f;
    public float baseGrowth = 5f;
    public float baseDecay = 5f;

    public float reactionStartThreshold = 20f;
    public float reactionEndThreshold = 10f;
    public bool isActive = false;

    protected abstract void OnActive();
    protected abstract void OnIdle();
    protected abstract void OnStateSwitch(bool nextState);

    protected Player _currentPlayer;
    protected Vector3 _playerLastPos;

    private void Update() {
        Debug.Log(current);
        if (_currentPlayer == null) {
            _currentPlayer = FindObjectOfType<Player>();
            if (_currentPlayer == null) {
                Debug.Log("No player in scene");
            } else {
                _playerLastPos = _currentPlayer.transform.position;
                Debug.Log("Found Player on Scene");
            }
            return;
        }

        if (_playerLastPos != _currentPlayer.transform.position) {
            current += baseGrowth * Time.deltaTime;
        } else {
            current -= baseDecay * Time.deltaTime;
        }
        current = Mathf.Clamp(current, min, max);
        if (isActive) {
            OnActive();
            if (current <= reactionEndThreshold) {
                isActive = false;
                OnStateSwitch(isActive);
            }
        } else {
            OnIdle();
            if (current >= reactionStartThreshold) {
                isActive = true;
                OnStateSwitch(isActive);
            }
        }

        _playerLastPos = _currentPlayer.transform.position;
    }
}
