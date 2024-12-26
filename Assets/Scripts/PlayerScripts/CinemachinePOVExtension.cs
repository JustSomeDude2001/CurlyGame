using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{
    private InputManager _inputManager;
    private Vector3 _startingRotation;

    public float horizontalSpeed = 10f;
    public float verticalSpeed = 10f;
    public float clampAngle = 80f;

    protected override void Awake()
    {
        _inputManager = InputManager.GetInstance();
        _startingRotation = transform.localRotation.eulerAngles;
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow) {
            if (stage == CinemachineCore.Stage.Aim) {
                Vector2 deltaInput = _inputManager.GetMouseDelta();

                _startingRotation.x += deltaInput.x * Time.deltaTime * horizontalSpeed;
                _startingRotation.y += deltaInput.y * Time.deltaTime * verticalSpeed;
                
                _startingRotation.y = Mathf.Clamp(_startingRotation.y, -clampAngle, +clampAngle);
                state.RawOrientation = Quaternion.Euler(-_startingRotation.y, _startingRotation.x, 0f);
            }

        }
    }
}
