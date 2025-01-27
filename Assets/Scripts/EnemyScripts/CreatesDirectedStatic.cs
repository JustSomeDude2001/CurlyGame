using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatesDirectedStatic : MonoBehaviour
{
    public Material material;

    public float maxIntensity;
    public float effectStartRadius;

    private void UpdateIntensity(Vector3 cameraPos) {
        float fractionalDistance = 1 - Mathf.Clamp(((transform.position - cameraPos).magnitude / effectStartRadius), 0f, 1f);

        float intensity = Mathf.Clamp((fractionalDistance * maxIntensity), 0.05f, 1f);

        material.SetFloat("_Intensity", intensity);
    }

    private void UpdateDirection(Vector3 cameraPos, Vector3 cameraDirection, Vector3 cameraUp) {

        Vector3 directionToSelf = (transform.position - cameraPos).normalized;
        
        Vector3 cameraPositionTranslated = Vector3.ProjectOnPlane(directionToSelf, cameraDirection).normalized;
        cameraPositionTranslated.z = 0;
        cameraPositionTranslated.Normalize();
        cameraPositionTranslated -= Vector3.one;
        cameraPositionTranslated /= 2;

        Vector4 cameraPositionSet = new Vector4(cameraPositionTranslated.x, cameraPositionTranslated.y);

        material.SetVector("_Direction", cameraPositionSet);
    }

    void Update() {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 cameraDirection = Camera.main.transform.forward;
        Vector3 cameraUp = Camera.main.transform.up;

        UpdateIntensity(cameraPos);
        UpdateDirection(cameraPos, cameraDirection, cameraUp);
    }

    void OnDestroy() {
        material.SetFloat("_Intensity", 0.01f);
    }
}
