using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public Interactive interactive;
    public TextMeshProUGUI tooltipSpace;
    public string tooltipCan = "";
    public string tooltipCannot = "";

    public float tooltipTimer = 0f;

    private void ResetTimer() {
        tooltipTimer = 0.1f;
    }

    void Update() {
        tooltipTimer -= Time.deltaTime;
        if (tooltipTimer < 0f) tooltipTimer = 0f;
        if (tooltipTimer == 0) {
            tooltipSpace.text = "";
        } else {
            if (interactive.CanInteract()) {
                tooltipSpace.text = tooltipCan;
            } else {
                tooltipSpace.text = tooltipCannot;
            }
        }
    }

    void Start() {
        interactive.OnCanInteract += ResetTimer;
        interactive.OnCannotInteract += ResetTimer;
    }

    void Destroy() {
        interactive.OnCanInteract -= ResetTimer;
        interactive.OnCannotInteract -= ResetTimer;
    }
}
