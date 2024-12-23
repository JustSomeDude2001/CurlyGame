using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{
    private InputManager inputManager;
    private Vector3 startingRotation;

    public float HorizontalSpeed = 10f;
    public float VerticalSpeed = 10f;
    public float ClampAngle = 80f;

    protected override void Awake()
    {
        inputManager = InputManager.GetInstance();
        startingRotation = transform.localRotation.eulerAngles;
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow) {
            if (stage == CinemachineCore.Stage.Aim) {
                Vector2 deltaInput = inputManager.GetMouseDelta();

                startingRotation.x += deltaInput.x * Time.deltaTime * HorizontalSpeed;
                startingRotation.y += deltaInput.y * Time.deltaTime * VerticalSpeed;
                
                startingRotation.y = Mathf.Clamp(startingRotation.y, -ClampAngle, +ClampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }

        }
    }
}
