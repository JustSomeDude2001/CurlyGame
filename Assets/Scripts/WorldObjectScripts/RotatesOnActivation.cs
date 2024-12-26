using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactive))]
public class RotatesOnActivation : MonoBehaviour
{
    public Quaternion targetRotation;
    public float rotationSpeed;

    IEnumerator incrementalRotate() {
        //TODO;
        yield return null;
    }

    public void StartRotation() {

    }
}
