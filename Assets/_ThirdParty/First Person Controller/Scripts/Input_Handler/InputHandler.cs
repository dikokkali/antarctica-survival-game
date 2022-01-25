using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;

namespace VHS
{    
    public class InputHandler : MonoBehaviour
    {
        #region Data
        [Space,Header("Input Data")]
        [SerializeField] private CameraInputData cameraInputData = null;
        [SerializeField] private MovementInputData movementInputData = null;
            
        InputContextData_FPS fpsContextData;

        InputAction movementAction;
        InputAction lookAction;
        InputAction runAction;
        InputAction jumpAction;
        InputAction crouchAction;
        #endregion

        #region BuiltIn Methods
        void Awake()
        {
            cameraInputData.ResetInput();
            movementInputData.ResetInput();

            fpsContextData = new InputContextData_FPS();

            movementAction = fpsContextData.FPSControls.Movement;
            lookAction = fpsContextData.FPSControls.Look;
            runAction = fpsContextData.FPSControls.Run;
            jumpAction = fpsContextData.FPSControls.Jump;
        }

        private void OnEnable()
        {
            fpsContextData.FPSControls.Enable();

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

            crouchAction.performed += e => movementInputData.CrouchClicked = true;
            crouchAction.canceled += e => movementInputData.CrouchClicked = false;
        }

        private void OnDisable()
        {
            fpsContextData.FPSControls.Disable();

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
        }

        void Update()
        {
            GetCameraInput();
            GetMovementInputData();
        }
        #endregion

        #region Custom Methods
        void GetCameraInput()
        {
            Vector2 inputVector = lookAction.ReadValue<Vector2>() * 0.5f * 0.1f;
            cameraInputData.InputVectorX = Mouse.current.delta.x.ReadValue();
            cameraInputData.InputVectorY = Mouse.current.delta.y.ReadValue();

            //cameraInputData.ZoomClicked = Input.GetMouseButtonDown(1);
            //cameraInputData.ZoomReleased = Input.GetMouseButtonUp(1);
        }

        void GetMovementInputData()
        {
            movementInputData.InputVectorX = movementAction.ReadValue<Vector2>().x;
            movementInputData.InputVectorY = movementAction.ReadValue<Vector2>().y;

            if (movementInputData.RunClicked)
                movementInputData.IsRunning = true;

            if (movementInputData.RunReleased)
                movementInputData.IsRunning = false;

            //movementInputData.CrouchClicked = Input.GetKeyDown(KeyCode.LeftControl);
        }
        #endregion

        #region Input System Callbacks    


        #endregion
    }
}