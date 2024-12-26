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

    private void Start() {
        _instance = this;
        InputManager.GetInstance().ToggleInteractions(true);
    }

    private void Destroy() {
        InputManager.GetInstance().ToggleInteractions(false);
    }

    public static Player GetInstance() {
        return _instance;
    }
}
