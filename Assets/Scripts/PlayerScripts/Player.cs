using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxDisInteraction = 5;
    public List<Item> inventory = new List<Item>();

    private static Player _instance;

    public void AddItem(Item item) {
        inventory.Add(item);
        Debug.Log("Added to inventory at " + transform.name);
    }

    private void Awake() {
        _instance = this;
    }

    private void Start() {
        InputManager.GetInstance().ToggleInteractions(true);
    }

    private void Destroy() {
        InputManager.GetInstance().ToggleInteractions(false);
    }

    public static Player GetInstance() {
        return _instance;
    }

    public static void ToggleControls(bool targetState) {
        GetInstance().gameObject.SetActive(targetState);
    }
}
