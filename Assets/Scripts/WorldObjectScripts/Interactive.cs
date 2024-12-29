using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public Action OnInteract;
    public Action OnFailInteract;
    public List<Item> requiredItems = new List<Item>();
    private int _collectedRequiredItems = 0;

    public bool CanInteract() {
        return _collectedRequiredItems >= requiredItems.Count;
    }

    private void _collectRequiredItem() {
        _collectedRequiredItems += 1;
    }

    void Start() {
        for (int i = 0; i < requiredItems.Count; i++) {
            requiredItems[i].OnPickup += _collectRequiredItem;
        }
    }

    void Destroy() {
        for (int i = 0; i < requiredItems.Count; i++) {
            requiredItems[i].OnPickup -= _collectRequiredItem;
        }
    }
}