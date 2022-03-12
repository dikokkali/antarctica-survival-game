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
                },
                {
                    ""name"": ""Open Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""25661312-e1cc-4024-b4ea-666ad2de34f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""fd74171f-65bd-4411-93f0-3926d23470e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quick Select 1 "",
                    ""type"": ""Button"",
                    ""id"": ""eb8e56a0-1d57-43a4-adab-2e45a05d31d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quick Select 2"",
                    ""type"": ""Button"",
                    ""id"": ""04a860ac-c4e3-43b4-b4c9-e1c12d708075"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""e87d49ef-55c0-44ad-b733-f33910365ab4"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""f7eec5b2-73b2-4d39-98ab-c2c5c683faee"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e89f5b77-d595-42ff-8c45-d8ce4629f936"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f4fa987-c001-4376-a291-e76e17831cd4"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quick Select 1 "",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""757ced10-2641-46ce-a32e-8673f57aec0b"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quick Select 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ece75e66-b74e-4a31-a837-c0d2bb6462cf"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIControls"",
            ""id"": ""efb6d58f-a670-44c2-a9f6-1dfc486688e1"",
            ""actions"": [
                {
                    ""name"": ""UIPoint"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5b479a83-285b-4472-b82e-620d24de2d9c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UILeftClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ae3ab964-c817-4376-a2b5-e6c1b56348b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UIRightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""86688a6a-5e5d-4119-bd6c-608174c9f9d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UIScroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1ff60a90-3e3d-44aa-9aa9-27cd7ebc5bc1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UISubmit"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5c6cbf9c-4991-4c89-a25e-4da0eb548bc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UICancel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3db775af-27ea-422d-907b-2579500eb2c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UINavigate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e12bfd7b-7d87-449c-aa03-028b59b1a3cf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UICloseInventory"",
                    ""type"": ""Button"",
                    ""id"": ""8b9b0b97-fddf-48bb-b85d-07c6e07e034b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2c59966c-ca58-4053-9708-38651e5dec2e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIPoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cded1b08-5f7a-48c1-8749-46ca94eb1716"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UILeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46b65e9c-5f0d-4e32-a1c6-657ff4b33c2f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIRightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd520d90-3a06-416f-bebe-1ce30f3b05aa"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""068ec169-aba7-40cc-9154-c50a0a7fc42a"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UISubmit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""126d9519-fec5-4aba-8d5a-34f818d1c197"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UICancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""857be0e6-ca83-42c5-951f-679af8c2fa0e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UINavigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""36ef8a95-3867-4927-a81c-e447734be3b1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UINavigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8c0830ad-a3ee-455d-9ab5-9f64ae3a72c6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UINavigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""91374db9-513c-4c2f-a8c2-ac9d43f4b8e3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UINavigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a80a5aa6-add2-43cd-9ce7-6d320c605d42"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UINavigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b2064e3a-0e66-4543-9fe3-0f81f258b6c5"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UICloseInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
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
        m_FPSControls_OpenInventory = m_FPSControls.FindAction("Open Inventory", throwIfNotFound: true);
        m_FPSControls_Reload = m_FPSControls.FindAction("Reload", throwIfNotFound: true);
        m_FPSControls_QuickSelect1 = m_FPSControls.FindAction("Quick Select 1 ", throwIfNotFound: true);
        m_FPSControls_QuickSelect2 = m_FPSControls.FindAction("Quick Select 2", throwIfNotFound: true);
        m_FPSControls_Interact = m_FPSControls.FindAction("Interact", throwIfNotFound: true);
        // UIControls
        m_UIControls = asset.FindActionMap("UIControls", throwIfNotFound: true);
        m_UIControls_UIPoint = m_UIControls.FindAction("UIPoint", throwIfNotFound: true);
        m_UIControls_UILeftClick = m_UIControls.FindAction("UILeftClick", throwIfNotFound: true);
        m_UIControls_UIRightClick = m_UIControls.FindAction("UIRightClick", throwIfNotFound: true);
        m_UIControls_UIScroll = m_UIControls.FindAction("UIScroll", throwIfNotFound: true);
        m_UIControls_UISubmit = m_UIControls.FindAction("UISubmit", throwIfNotFound: true);
        m_UIControls_UICancel = m_UIControls.FindAction("UICancel", throwIfNotFound: true);
        m_UIControls_UINavigate = m_UIControls.FindAction("UINavigate", throwIfNotFound: true);
        m_UIControls_UICloseInventory = m_UIControls.FindAction("UICloseInventory", throwIfNotFound: true);
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
    private readonly InputAction m_FPSControls_OpenInventory;
    private readonly InputAction m_FPSControls_Reload;
    private readonly InputAction m_FPSControls_QuickSelect1;
    private readonly InputAction m_FPSControls_QuickSelect2;
    private readonly InputAction m_FPSControls_Interact;
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
        public InputAction @OpenInventory => m_Wrapper.m_FPSControls_OpenInventory;
        public InputAction @Reload => m_Wrapper.m_FPSControls_Reload;
        public InputAction @QuickSelect1 => m_Wrapper.m_FPSControls_QuickSelect1;
        public InputAction @QuickSelect2 => m_Wrapper.m_FPSControls_QuickSelect2;
        public InputAction @Interact => m_Wrapper.m_FPSControls_Interact;
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
                @OpenInventory.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnOpenInventory;
                @Reload.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnReload;
                @QuickSelect1.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnQuickSelect1;
                @QuickSelect1.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnQuickSelect1;
                @QuickSelect1.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnQuickSelect1;
                @QuickSelect2.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnQuickSelect2;
                @QuickSelect2.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnQuickSelect2;
                @QuickSelect2.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnQuickSelect2;
                @Interact.started -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_FPSControlsActionsCallbackInterface.OnInteract;
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
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @QuickSelect1.started += instance.OnQuickSelect1;
                @QuickSelect1.performed += instance.OnQuickSelect1;
                @QuickSelect1.canceled += instance.OnQuickSelect1;
                @QuickSelect2.started += instance.OnQuickSelect2;
                @QuickSelect2.performed += instance.OnQuickSelect2;
                @QuickSelect2.canceled += instance.OnQuickSelect2;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public FPSControlsActions @FPSControls => new FPSControlsActions(this);

    // UIControls
    private readonly InputActionMap m_UIControls;
    private IUIControlsActions m_UIControlsActionsCallbackInterface;
    private readonly InputAction m_UIControls_UIPoint;
    private readonly InputAction m_UIControls_UILeftClick;
    private readonly InputAction m_UIControls_UIRightClick;
    private readonly InputAction m_UIControls_UIScroll;
    private readonly InputAction m_UIControls_UISubmit;
    private readonly InputAction m_UIControls_UICancel;
    private readonly InputAction m_UIControls_UINavigate;
    private readonly InputAction m_UIControls_UICloseInventory;
    public struct UIControlsActions
    {
        private @InputContextData_FPS m_Wrapper;
        public UIControlsActions(@InputContextData_FPS wrapper) { m_Wrapper = wrapper; }
        public InputAction @UIPoint => m_Wrapper.m_UIControls_UIPoint;
        public InputAction @UILeftClick => m_Wrapper.m_UIControls_UILeftClick;
        public InputAction @UIRightClick => m_Wrapper.m_UIControls_UIRightClick;
        public InputAction @UIScroll => m_Wrapper.m_UIControls_UIScroll;
        public InputAction @UISubmit => m_Wrapper.m_UIControls_UISubmit;
        public InputAction @UICancel => m_Wrapper.m_UIControls_UICancel;
        public InputAction @UINavigate => m_Wrapper.m_UIControls_UINavigate;
        public InputAction @UICloseInventory => m_Wrapper.m_UIControls_UICloseInventory;
        public InputActionMap Get() { return m_Wrapper.m_UIControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIControlsActions set) { return set.Get(); }
        public void SetCallbacks(IUIControlsActions instance)
        {
            if (m_Wrapper.m_UIControlsActionsCallbackInterface != null)
            {
                @UIPoint.started -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUIPoint;
                @UIPoint.performed -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUIPoint;
                @UIPoint.canceled -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUIPoint;
                @UILeftClick.started -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUILeftClick;
                @UILeftClick.performed -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUILeftClick;
                @UILeftClick.canceled -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUILeftClick;
                @UIRightClick.started -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUIRightClick;
                @UIRightClick.performed -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUIRightClick;
                @UIRightClick.canceled -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUIRightClick;
                @UIScroll.started -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUIScroll;
                @UIScroll.performed -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUIScroll;
                @UIScroll.canceled -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUIScroll;
                @UISubmit.started -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUISubmit;
                @UISubmit.performed -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUISubmit;
                @UISubmit.canceled -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUISubmit;
                @UICancel.started -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUICancel;
                @UICancel.performed -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUICancel;
                @UICancel.canceled -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUICancel;
                @UINavigate.started -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUINavigate;
                @UINavigate.performed -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUINavigate;
                @UINavigate.canceled -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUINavigate;
                @UICloseInventory.started -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUICloseInventory;
                @UICloseInventory.performed -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUICloseInventory;
                @UICloseInventory.canceled -= m_Wrapper.m_UIControlsActionsCallbackInterface.OnUICloseInventory;
            }
            m_Wrapper.m_UIControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UIPoint.started += instance.OnUIPoint;
                @UIPoint.performed += instance.OnUIPoint;
                @UIPoint.canceled += instance.OnUIPoint;
                @UILeftClick.started += instance.OnUILeftClick;
                @UILeftClick.performed += instance.OnUILeftClick;
                @UILeftClick.canceled += instance.OnUILeftClick;
                @UIRightClick.started += instance.OnUIRightClick;
                @UIRightClick.performed += instance.OnUIRightClick;
                @UIRightClick.canceled += instance.OnUIRightClick;
                @UIScroll.started += instance.OnUIScroll;
                @UIScroll.performed += instance.OnUIScroll;
                @UIScroll.canceled += instance.OnUIScroll;
                @UISubmit.started += instance.OnUISubmit;
                @UISubmit.performed += instance.OnUISubmit;
                @UISubmit.canceled += instance.OnUISubmit;
                @UICancel.started += instance.OnUICancel;
                @UICancel.performed += instance.OnUICancel;
                @UICancel.canceled += instance.OnUICancel;
                @UINavigate.started += instance.OnUINavigate;
                @UINavigate.performed += instance.OnUINavigate;
                @UINavigate.canceled += instance.OnUINavigate;
                @UICloseInventory.started += instance.OnUICloseInventory;
                @UICloseInventory.performed += instance.OnUICloseInventory;
                @UICloseInventory.canceled += instance.OnUICloseInventory;
            }
        }
    }
    public UIControlsActions @UIControls => new UIControlsActions(this);
    public interface IFPSControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnUseEquippedFireWeapon(InputAction.CallbackContext context);
        void OnAlternateAction(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnQuickSelect1(InputAction.CallbackContext context);
        void OnQuickSelect2(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IUIControlsActions
    {
        void OnUIPoint(InputAction.CallbackContext context);
        void OnUILeftClick(InputAction.CallbackContext context);
        void OnUIRightClick(InputAction.CallbackContext context);
        void OnUIScroll(InputAction.CallbackContext context);
        void OnUISubmit(InputAction.CallbackContext context);
        void OnUICancel(InputAction.CallbackContext context);
        void OnUINavigate(InputAction.CallbackContext context);
        void OnUICloseInventory(InputAction.CallbackContext context);
    }
}
