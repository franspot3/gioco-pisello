//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem.inputactions
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

public partial class @InputSystem: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Combat"",
            ""id"": ""20247efc-a205-4ead-8fc3-3c65e538bdd8"",
            ""actions"": [
                {
                    ""name"": ""ChangeTarget(right)"",
                    ""type"": ""Button"",
                    ""id"": ""ad1b1189-06ff-45ba-8311-ff5820b2feeb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeTarget(left)"",
                    ""type"": ""Button"",
                    ""id"": ""db26de8a-2f68-453a-81dd-accb8329d500"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""38839f65-e42a-4644-a360-e0d4e614051a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeTarget(right)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18f26e7e-0edf-4360-8529-8b1b41065a73"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeTarget(left)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_ChangeTargetright = m_Combat.FindAction("ChangeTarget(right)", throwIfNotFound: true);
        m_Combat_ChangeTargetleft = m_Combat.FindAction("ChangeTarget(left)", throwIfNotFound: true);
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

    // Combat
    private readonly InputActionMap m_Combat;
    private List<ICombatActions> m_CombatActionsCallbackInterfaces = new List<ICombatActions>();
    private readonly InputAction m_Combat_ChangeTargetright;
    private readonly InputAction m_Combat_ChangeTargetleft;
    public struct CombatActions
    {
        private @InputSystem m_Wrapper;
        public CombatActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChangeTargetright => m_Wrapper.m_Combat_ChangeTargetright;
        public InputAction @ChangeTargetleft => m_Wrapper.m_Combat_ChangeTargetleft;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void AddCallbacks(ICombatActions instance)
        {
            if (instance == null || m_Wrapper.m_CombatActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CombatActionsCallbackInterfaces.Add(instance);
            @ChangeTargetright.started += instance.OnChangeTargetright;
            @ChangeTargetright.performed += instance.OnChangeTargetright;
            @ChangeTargetright.canceled += instance.OnChangeTargetright;
            @ChangeTargetleft.started += instance.OnChangeTargetleft;
            @ChangeTargetleft.performed += instance.OnChangeTargetleft;
            @ChangeTargetleft.canceled += instance.OnChangeTargetleft;
        }

        private void UnregisterCallbacks(ICombatActions instance)
        {
            @ChangeTargetright.started -= instance.OnChangeTargetright;
            @ChangeTargetright.performed -= instance.OnChangeTargetright;
            @ChangeTargetright.canceled -= instance.OnChangeTargetright;
            @ChangeTargetleft.started -= instance.OnChangeTargetleft;
            @ChangeTargetleft.performed -= instance.OnChangeTargetleft;
            @ChangeTargetleft.canceled -= instance.OnChangeTargetleft;
        }

        public void RemoveCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICombatActions instance)
        {
            foreach (var item in m_Wrapper.m_CombatActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CombatActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    public interface ICombatActions
    {
        void OnChangeTargetright(InputAction.CallbackContext context);
        void OnChangeTargetleft(InputAction.CallbackContext context);
    }
}
