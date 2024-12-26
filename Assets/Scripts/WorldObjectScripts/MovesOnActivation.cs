using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactive))]
public class MovesOnActivation : MonoBehaviour
{
    Interactive _interactive;
    public Transform targetPos;
    public float speed;
    
    IEnumerator moveTo() {
        Vector3 direction = (targetPos.position - transform.position).normalized;
        while(transform.position != targetPos.position) {
            Vector3 offset = direction * speed * Time.deltaTime;
            if (offset.magnitude > (transform.position - targetPos.position).magnitude) {
                transform.position = targetPos.position;
                break;
            }
            transform.position += direction * speed * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    void StartMovement() {
        StartCoroutine(moveTo());
    }

    void Start() {
        _interactive = GetComponent<Interactive>();
        _interactive.OnInteract += StartMovement;
    }

    void Destroy() {
        _interactive.OnInteract -= StartMovement;
    }
}
