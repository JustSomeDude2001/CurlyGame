using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Attention : MonoBehaviour
{
    public float Current = 0f;
    public float Min = 0f;
    public float Max = 100f;
    public float BaseGrowth = 5f;
    public float BaseDecay = 5f;

    public float ReactionStartThreshold = 20f;
    public float ReactionEndThreshold = 10f;
    public bool isActive = false;

    protected abstract void OnActive();
    protected abstract void OnIdle();
    protected abstract void OnStateSwitch(bool nextState);

    protected Player currentPlayer;
    protected Vector3 playerLastPos;

    private void Update() {
        if (currentPlayer == null) {
            currentPlayer = FindObjectOfType<Player>();
            if (currentPlayer == null) {
                Debug.Log("No player in scene");
            } else {
                playerLastPos = currentPlayer.transform.position;
                Debug.Log("Found Player on Scene");
            }
            return;
        }

        if (playerLastPos != currentPlayer.transform.position) {
            Current += BaseGrowth * Time.deltaTime;
        } else {
            Current -= BaseDecay * Time.deltaTime;
        }
        Current = Mathf.Clamp(Current, Min, Max);
        if (isActive) {
            OnActive();
            if (Current <= ReactionEndThreshold) {
                isActive = false;
                OnStateSwitch(isActive);
            }
        } else {
            OnIdle();
            if (Current >= ReactionStartThreshold) {
                isActive = true;
                OnStateSwitch(isActive);
            }
        }

        playerLastPos = currentPlayer.transform.position;
    }
}
