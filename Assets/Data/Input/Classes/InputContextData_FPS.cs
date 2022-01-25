// GENERATED AUTOMATICALLY FROM 'Assets/Data/Input/InputContextData_FPS.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputContextData_FPS : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputContextData_FPS()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputContextData_FPS"",
    ""maps"": [
        {
            ""name"": ""FPSControls"",
            ""id"": ""b7f8df30-7ea4-404d-aabb-e3f768d1ad0f"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""035e8ca1-b085-46e7-9773-489ec87b500f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""13b1faf8-e9ec-402e-88be-8bfc829020b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Equipped/Fire Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""53872622-6b36-4056-bce8-9170bc5641a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Alternate Action"",
                    ""type"": ""Button"",
                    ""id"": ""1582374f-2d3e-4172-9e03-65ffb6f3cd65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""fac939dc-d5b1-48d9-a15f-f08348a86483"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""46e9e5d0-2594-4004-a335-92a9f372b09c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""a98f6d7e-c6bc-4b1c-9cb1-710a849228ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2f498291-5d55-4c09-9b02-96a84b0f5c1f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""673ba2cb-a45f-4bfb-bde7-e73268f970b0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5a0d6eea-e1b6-438b-b006-e232d26b2c73"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9463e6b4-78a2-41bb-976e-ee8c4fddebef"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""186a1358-cb1a-41e6-9798-2291dd2214d1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dbcc2b55-09b3-4e0f-a7b5-c6ffb4e9203b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36da4436-64da-42ac-bd5f-2efd1450ba37"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Equipped/Fire Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49ff4308-9103-4324-927b-5b7a8a5c6f6e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Alternate Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""230b6f2b-a657-4b4e-989e-6b784f0663c3"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f92b507e-e4fb-4100-b601-41c86460bc8b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47c8c569-dc2b-4d0d-8162-88bfb3524f6d"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
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
        // FPSControls
        m_FPSControls = asset.FindActionMap("FPSControls", throwIfNotFound: true);
        m_FPSControls_Movement = m_FPSControls.FindAction("Movement", throwIfNotFound: true);
        m_FPSControls_Jump = m_FPSControls.FindAction("Jump", throwIfNotFound: true);
        m_FPSControls_UseEquippedFireWeapon = m_FPSControls.FindAction("Use Equipped/Fire Weapon", throwIfNotFound: true);
        m_FPSControls_AlternateAction = m_FPSControls.FindAction("Alternate Action", throwIfNotFound: true);
        m_FPSControls_Run = m_FPSControls.FindAction("Run", throwIfNotFound: true);
        m_FPSControls_Look = m_FPSControls.FindAction("Look", throwIfNotFound: true);
        m_FPSControls_Crouch = m_FPSControls.FindAction("Crouch", throwIfNotFound: true);
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

    // FPSControls
    private readonly InputActionMap m_FPSControls;
    private IFPSControlsActions m_FPSControlsActionsCallbackInterface;
    private readonly InputAction m_FPSControls_Movement;
    private readonly InputAction m_FPSControls_Jump;
    private readonly InputAction m_FPSControls_UseEquippedFireWeapon;
    private readonly InputAction m_FPSControls_AlternateAction;
    private readonly InputAction m_FPSControls_Run;
    private readonly InputAction m_FPSControls_Look;
    private readonly InputAction m_FPSControls_Crouch;
    public struct FPSControlsActions
    {
        private @InputContextData_FPS m_Wrapper;
        public FPSControlsActions(@InputContextData_FPS wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_FPSControls_Movement;
        public InputAction @Jump => m_Wrapper.m_FPSControls_Jump;
        public InputAction @UseEquippedFireWeapon => m_Wrapper.m_FPSControls_UseEquippedFireWeapon;
        public InputAction @AlternateAction => m_Wrapper.m_FPSControls_AlternateAction;
        public InputAction @Run => m_Wrapper.m_FPSControls_Run;
        public InputAction @Look => m_Wrapper.m_FPSControls_Look;
        public InputAction @Crouch => m_Wrapper.m_FPSControls_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_FPSControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPSControlsActions set) { return set.Get(); }
        public void SetCallbacks(IFPSControlsActions instance)
        {
            if (m_Wrapper.m_FPSControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnJump;
                @UseEquippedFireWeapon.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnUseEquippedFireWeapon;
                @UseEquippedFireWeapon.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnUseEquippedFireWeapon;
                @UseEquippedFireWeapon.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnUseEquippedFireWeapon;
                @AlternateAction.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnAlternateAction;
                @AlternateAction.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnAlternateAction;
                @AlternateAction.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnAlternateAction;
                @Run.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnRun;
                @Look.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnLook;
                @Crouch.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_FPSControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @UseEquippedFireWeapon.started += instance.OnUseEquippedFireWeapon;
                @UseEquippedFireWeapon.performed += instance.OnUseEquippedFireWeapon;
                @UseEquippedFireWeapon.canceled += instance.OnUseEquippedFireWeapon;
                @AlternateAction.started += instance.OnAlternateAction;
                @AlternateAction.performed += instance.OnAlternateAction;
                @AlternateAction.canceled += instance.OnAlternateAction;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public FPSControlsActions @FPSControls => new FPSControlsActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IFPSControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnUseEquippedFireWeapon(InputAction.CallbackContext context);
        void OnAlternateAction(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
}
