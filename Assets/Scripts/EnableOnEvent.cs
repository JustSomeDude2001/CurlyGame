using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnEvent : MonoBehaviour
{
    Enemy _enemy;
    public List<MonoBehaviour> components;
    
    private void EnableFunc() {
        for (int i = 0; i < components.Count; i++) {
            components[i].enabled = true;
        }
    }

    void Start() {
        _enemy = FindObjectOfType<Enemy>();
        _enemy.OnKill += EnableFunc;
    }

    void Destroy() {
        _enemy.OnKill -= EnableFunc;
    }
}
