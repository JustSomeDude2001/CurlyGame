using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelLoader))]
public class Enemy : MonoBehaviour
{
    Player _player;
    LevelLoader _levelLoader;
    public int onKillLevel = 0;
    public float killDistance = 1.5f;

    public Action OnKill;

    void Start() {
        _player = FindObjectOfType<Player>();
        _levelLoader = GetComponent<LevelLoader>();
    }

    void Update() {
        if ((_player.transform.position - transform.position).magnitude <= killDistance) {
            OnKill.Invoke();
            Cursor.visible = true;
        }
    }
}
