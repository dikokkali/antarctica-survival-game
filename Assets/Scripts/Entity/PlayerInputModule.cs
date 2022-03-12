using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerEntity))]
public class PlayerInputModule: MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public PlayerEntity playerEntity;


    #region Private Members

    private PlayerInventory _playerInventory;
    private InputContextData_FPS _inputContextData;

    #endregion

    private void Awake()
    {
        // TODO: Better way to do the injection
        playerInputManager = GameObject.Find("InputManager").GetComponent<PlayerInputManager>();
        playerEntity = GetComponent<PlayerEntity>();

        if (playerInputManager != null)
        {
            _inputContextData = playerInputManager.fpsInputContext;
        }
    }

    private void Start()
    {
        if (playerEntity != null)
        {
            _playerInventory = playerEntity.playerInventory;
        }
        else Debug.LogWarning("Input Manager not found. Check dependency injection.");
    }

    private void OnEnable()
    {
        _inputContextData.FPSControls.UseEquippedFireWeapon.performed += OnPrimaryActionStart;
        _inputContextData.FPSControls.UseEquippedFireWeapon.canceled += OnPrimaryActionStop;

        _inputContextData.FPSControls.AlternateAction.performed += OnAlternateActionStart;
        _inputContextData.FPSControls.AlternateAction.canceled += OnAlternateActionStop;

        _inputContextData.FPSControls.Reload.performed += OnReloadAction;

        _inputContextData.FPSControls.Interact.performed += OnInteractAction;
    }

    private void OnDisable()
    {
        _inputContextData.FPSControls.UseEquippedFireWeapon.performed -= OnPrimaryActionStart;
        _inputContextData.FPSControls.UseEquippedFireWeapon.canceled -= OnPrimaryActionStop;

        _inputContextData.FPSControls.AlternateAction.performed -= OnAlternateActionStart;
        _inputContextData.FPSControls.AlternateAction.canceled -= OnAlternateActionStop;

        _inputContextData.FPSControls.Reload.performed -= OnReloadAction;

        _inputContextData.FPSControls.Interact.performed -= OnInteractAction;
    }

    #region Action-Mapped Methods

    #region On Foot Controls

    // Equipped Item Actions
    void OnPrimaryActionStart(InputAction.CallbackContext ctx)
    {
        if (_playerInventory.equippedItemController != null)
        {
            _playerInventory.equippedItemController.StartPrimaryTriggerAction();
        }
    }

    void OnPrimaryActionStop(InputAction.CallbackContext ctx)
    {
        if (_playerInventory.equippedItemController != null)
        {
            _playerInventory.equippedItemController.StopPrimaryTriggerAction();
        }
    }

    void OnReloadAction(InputAction.CallbackContext ctx)
    {
        if (_playerInventory.equippedItemController != null)
        {
            _playerInventory.equippedItemController.ReloadAction();
        }
    }

    void OnAlternateActionStart(InputAction.CallbackContext ctx)
    {
        if (_playerInventory.equippedItemController != null)
        {
            _playerInventory.equippedItemController.StartSecondaryTriggerAction();
        }
    }

    void OnAlternateActionStop(InputAction.CallbackContext ctx)
    {
        if (_playerInventory.equippedItemController != null)
        {
            _playerInventory.equippedItemController.StopSecondaryTriggerAction();
        }
    }

    // Generic
    void OnInteractAction(InputAction.CallbackContext ctx)
    {
        playerEntity.Interact();
    }

    #endregion
    #endregion
}
