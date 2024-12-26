using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactive))]
public class Item : MonoBehaviour
{
    Interactive _interactive;

    public Action OnPickup;

    public List<Renderer> renderers;
    public List<Collider> colliders;

    private void Pickup() {
        for (int i = 0; i < renderers.Count; i++) {
            renderers[i].enabled = false;
        }
        for (int i = 0; i < colliders.Count; i++) {
            colliders[i].enabled = false;
        }
        Player.GetInstance().AddItem(this);
        Debug.Log("picked up " + gameObject);
        OnPickup.Invoke();
    }

    private void Start() {
        _interactive = GetComponent<Interactive>();
        _interactive.OnInteract += Pickup;
    }

    private void Destroy() {
        _interactive.OnInteract -= Pickup;
    }
}
