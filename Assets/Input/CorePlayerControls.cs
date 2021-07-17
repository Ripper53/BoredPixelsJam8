// GENERATED AUTOMATICALLY FROM 'Assets/Input/CorePlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CorePlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CorePlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CorePlayerControls"",
    ""maps"": [
        {
            ""name"": ""Action"",
            ""id"": ""80c7aee0-a174-4c33-8bf2-a930bbff34a9"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""155b519f-98b3-4138-b61c-cde171af3cef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ac81cc71-5143-4224-9ae9-efdcb6fc39a9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Action
        m_Action = asset.FindActionMap("Action", throwIfNotFound: true);
        m_Action_Interact = m_Action.FindAction("Interact", throwIfNotFound: true);
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

    // Action
    private readonly InputActionMap m_Action;
    private IActionActions m_ActionActionsCallbackInterface;
    private readonly InputAction m_Action_Interact;
    public struct ActionActions
    {
        private @CorePlayerControls m_Wrapper;
        public ActionActions(@CorePlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Action_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Action; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionActions set) { return set.Get(); }
        public void SetCallbacks(IActionActions instance)
        {
            if (m_Wrapper.m_ActionActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_ActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public ActionActions @Action => new ActionActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IActionActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
}
