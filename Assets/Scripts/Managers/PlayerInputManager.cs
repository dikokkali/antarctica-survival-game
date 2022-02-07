using GoonRaccoon.Utils.DebugUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using VHS;

public class PlayerInputManager : MonoBehaviour
{ 
    public InputActionAsset contextData;
    public InputContextData_FPS fpsInputContext;

    // References
    public UI_DisplayController uiDisplayController;

    // Shared movement data 
    [SerializeField] private CameraInputData cameraInputData = null;
    [SerializeField] private MovementInputData movementInputData = null;

    // Action maps    
    private InputActionMap fpsActionMap;
    private InputActionMap uiActionMap;

    // Input Actions
    InputAction movementAction;
    InputAction lookAction;
    InputAction runAction;
    InputAction jumpAction;
    InputAction crouchAction;

    InputAction UIInventoryClose;

    #region Built-in Methods

    private void Awake()
    {
        InitInputContexts();
        InitPlayerMovementData();  
    }

    private void OnEnable()
    {
        SubscribeActions();
    }

    private void OnDisable()
    {     
        UnsubscribeActions();
    }

    private void Update()
    {
        GetCameraInput();
        GetMovementInputData();
    }

    #endregion

    #region Setup

    private void InitInputContexts()
    {
        // TODO: Make this a singleton somewhere
        fpsInputContext = new InputContextData_FPS();

        fpsInputContext.Enable();
        fpsInputContext.FPSControls.Enable();
        fpsInputContext.UIControls.Disable();

        // TODO: Find better way that doesn't use strings
        fpsActionMap = contextData.FindActionMap("FPSControls");
        uiActionMap = contextData.FindActionMap("UIControls");
    }

    private void InitPlayerMovementData()
    {
        cameraInputData.ResetInput();
        movementInputData.ResetInput();

        movementAction = fpsInputContext.FPSControls.Movement;
        lookAction = fpsInputContext.FPSControls.Look;
        runAction = fpsInputContext.FPSControls.Run;
        jumpAction = fpsInputContext.FPSControls.Jump;
        crouchAction = fpsInputContext.FPSControls.Crouch;
    }

    private void SubscribeActions()
    {
        runAction.started += e =>
        {
            movementInputData.RunClicked = true;
            movementInputData.RunReleased = false;
        };

        runAction.canceled += e =>
        {
            movementInputData.RunClicked = false;
            movementInputData.RunReleased = true;
        };

        jumpAction.performed += e => movementInputData.JumpClicked = true;
        jumpAction.canceled += e => movementInputData.JumpClicked = false;

        jumpAction.performed += e => movementInputData.JumpClicked = true;
        jumpAction.canceled += e => movementInputData.JumpClicked = false;

        // Inventory       
        fpsInputContext.FPSControls.OpenInventory.performed += e => ChangeActiveActionMap(uiActionMap);
        fpsInputContext.UIControls.UICloseInventory.performed += e => ChangeActiveActionMap(fpsActionMap);
    }

    // TODO: Lambda expression unsubscribes don't work!
    private void UnsubscribeActions()
    {
        fpsInputContext.FPSControls.Disable();

        runAction.started -= e =>
        {
            movementInputData.RunClicked = true;
            movementInputData.RunReleased = false;
        };

        runAction.canceled -= e =>
        {
            movementInputData.RunClicked = false;
            movementInputData.RunReleased = true;
        };

        jumpAction.performed -= e => movementInputData.JumpClicked = true;
        jumpAction.canceled -= e => movementInputData.JumpClicked = false;

        crouchAction.performed -= e => movementInputData.CrouchClicked = true;
        crouchAction.canceled += e => movementInputData.CrouchClicked = false;

        // Inventory
        fpsInputContext.FPSControls.OpenInventory.performed -= e => ChangeActiveActionMap(uiActionMap);
        fpsInputContext.UIControls.UICloseInventory.performed -= e => ChangeActiveActionMap(fpsActionMap);

    }


    #endregion

    #region Control Methods

    //private void ExecuteInventoryOpenCommand(InputAction.CallbackContext context)
    //{             
    //    ChangeActiveActionMap(uiActionMap);    

    //    uiDisplayController.OnInventoryButtonPressed();
    //}

    //private void ExecuteInventoryCloseCommand(InputAction.CallbackContext context)
    //{
    //    ChangeActiveActionMap(fpsActionMap);           

    //    uiDisplayController.OnInventoryButtonPressed();
    //}

    #endregion

    #region Action Map Methods    

    private void ChangeActiveActionMap(InputActionMap actionMapToActivate)
    {
        foreach (var map in fpsInputContext.asset.actionMaps)
        {
            if (map.name == actionMapToActivate.name)
            {
                map.Enable();
                Debug.Log(map.name + " enabled");
            }
            else
            {
                map.Disable();
                Debug.Log(map.name + " Disabled");
            }
        }
    }
    #endregion

    #region Movement Methods

    void GetCameraInput()
    {
        Vector2 inputVector = lookAction.ReadValue<Vector2>() * 0.5f * 0.1f;
        cameraInputData.InputVectorX = fpsInputContext.FPSControls.Look.ReadValue<Vector2>().x; //Mouse.current.delta.x.ReadValue();
        cameraInputData.InputVectorY = fpsInputContext.FPSControls.Look.ReadValue<Vector2>().y; //Mouse.current.delta.y.ReadValue();
    }

    void GetMovementInputData()
    {
        movementInputData.InputVectorX = movementAction.ReadValue<Vector2>().x;
        movementInputData.InputVectorY = movementAction.ReadValue<Vector2>().y;

        if (movementInputData.RunClicked)
            movementInputData.IsRunning = true;

        if (movementInputData.RunReleased)
            movementInputData.IsRunning = false;
    }

    #endregion
}
