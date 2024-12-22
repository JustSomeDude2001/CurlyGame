//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PCControl.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PCControl: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PCControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PCControl"",
    ""maps"": [
        {
            ""name"": ""FP"",
            ""id"": ""5240ed8f-1f0a-4fd2-8a5f-ad17a21794d8"",
            ""actions"": [
                {
                    ""name"": ""CameraZoom"",
                    ""type"": ""Button"",
                    ""id"": ""fa4ea6dc-bcd3-453d-858a-3190aaf59552"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""c2a384bb-15a0-4750-be89-8d6a179a66c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6f1441e1-b607-4656-ad62-d78629e23c98"",
                    ""expectedControlType"": ""Delta"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""179eb5b2-8323-46f5-9e74-ac6ea4dd2b3a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c91d014b-36e4-4a04-9b90-5a41f9c9a0b1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1829a0f6-bfbe-4e07-8f54-3de8dd0c3746"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41488335-326f-427b-95c6-02da3c6bc9d8"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""7bec9b44-1a14-45b7-959b-c2e9d64b38d1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c76204b5-2d7e-41c2-9edb-0554ca63d958"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a4d6550f-62c5-48ce-a2c3-785afc46eb2e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2f945fda-db02-4346-8e5e-7505ccf1c7b2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6d9c5666-a61f-4455-88fa-7e27b11db58e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FP
        m_FP = asset.FindActionMap("FP", throwIfNotFound: true);
        m_FP_CameraZoom = m_FP.FindAction("CameraZoom", throwIfNotFound: true);
        m_FP_Interact = m_FP.FindAction("Interact", throwIfNotFound: true);
        m_FP_Look = m_FP.FindAction("Look", throwIfNotFound: true);
        m_FP_Move = m_FP.FindAction("Move", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // FP
    private readonly InputActionMap m_FP;
    private List<IFPActions> m_FPActionsCallbackInterfaces = new List<IFPActions>();
    private readonly InputAction m_FP_CameraZoom;
    private readonly InputAction m_FP_Interact;
    private readonly InputAction m_FP_Look;
    private readonly InputAction m_FP_Move;
    public struct FPActions
    {
        private @PCControl m_Wrapper;
        public FPActions(@PCControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraZoom => m_Wrapper.m_FP_CameraZoom;
        public InputAction @Interact => m_Wrapper.m_FP_Interact;
        public InputAction @Look => m_Wrapper.m_FP_Look;
        public InputAction @Move => m_Wrapper.m_FP_Move;
        public InputActionMap Get() { return m_Wrapper.m_FP; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPActions set) { return set.Get(); }
        public void AddCallbacks(IFPActions instance)
        {
            if (instance == null || m_Wrapper.m_FPActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FPActionsCallbackInterfaces.Add(instance);
            @CameraZoom.started += instance.OnCameraZoom;
            @CameraZoom.performed += instance.OnCameraZoom;
            @CameraZoom.canceled += instance.OnCameraZoom;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IFPActions instance)
        {
            @CameraZoom.started -= instance.OnCameraZoom;
            @CameraZoom.performed -= instance.OnCameraZoom;
            @CameraZoom.canceled -= instance.OnCameraZoom;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IFPActions instance)
        {
            if (m_Wrapper.m_FPActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFPActions instance)
        {
            foreach (var item in m_Wrapper.m_FPActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FPActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FPActions @FP => new FPActions(this);
    public interface IFPActions
    {
        void OnCameraZoom(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}