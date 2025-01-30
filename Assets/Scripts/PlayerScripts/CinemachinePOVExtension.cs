using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachinePOVExtension : CinemachineExtension
{
    private InputManager _inputManager;
    private Vector3 _currentRotation;

    public float yRotation;
    public float xRotation;

    public float horizontalSpeed = 10f;
    public float verticalSpeed = 10f;
    public float clampAngle = 80f;

    private bool _isFirstProcessedFrame = true;

    protected override void Awake()
    {
        _inputManager = InputManager.GetInstance();
        _currentRotation = new Vector3(xRotation, yRotation, 0f);
        Debug.Log("Camera Starting Rotation:" + _currentRotation);
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow) {
            if (stage == CinemachineCore.Stage.Aim) {
                if (_inputManager == null) {
                    _inputManager = InputManager.GetInstance();
                    if (_inputManager == null) {
                        return;
                    }
                }

                _currentRotation.y = yRotation;
                _currentRotation.x = xRotation;

                Vector2 deltaInput = _inputManager.GetMouseDelta();

                _currentRotation.x += deltaInput.x * Time.deltaTime * horizontalSpeed;
                _currentRotation.y += deltaInput.y * Time.deltaTime * verticalSpeed;

                _currentRotation.y = Mathf.Clamp(_currentRotation.y, -clampAngle, +clampAngle);

                xRotation = _currentRotation.x;
                yRotation = _currentRotation.y;     

                if (_isFirstProcessedFrame) {
                    _isFirstProcessedFrame = false;
                    Debug.Log("First frame state: " + state.RawOrientation.eulerAngles);
                    Debug.Log("First frame target state:" + _currentRotation);
                }

                state.RawOrientation = Quaternion.Euler(-_currentRotation.y, _currentRotation.x, 0f);
            }
        }
    }
}
