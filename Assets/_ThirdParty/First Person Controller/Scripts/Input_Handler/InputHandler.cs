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

        #endregion

        #region BuiltIn Methods
        void Awake()
        {
            cameraInputData.ResetInput();
            movementInputData.ResetInput();

            fpsContextData = new InputContextData_FPS();
            movementAction = fpsContextData.FPSControls.Movement;
        }

        private void OnEnable()
        {
            fpsContextData.FPSControls.Enable();
        }

        private void OnDisable()
        {
            fpsContextData.FPSControls.Disable();

        }

        void Update()
        {
            //GetCameraInput();
            GetMovementInputData();
        }
        #endregion

        #region Custom Methods
        void GetCameraInput()
        {
            cameraInputData.InputVectorX = Input.GetAxis("Mouse X");
            cameraInputData.InputVectorY = Input.GetAxis("Mouse Y");

            cameraInputData.ZoomClicked = Input.GetMouseButtonDown(1);
            cameraInputData.ZoomReleased = Input.GetMouseButtonUp(1);
        }

        void GetMovementInputData()
        {
            movementInputData.InputVectorX = movementAction.ReadValue<Vector2>().x;
            movementInputData.InputVectorY = movementAction.ReadValue<Vector2>().y;

            //movementInputData.RunClicked = Input.GetKeyDown(KeyCode.LeftShift);
            //movementInputData.RunReleased = Input.GetKeyUp(KeyCode.LeftShift);

            //if(movementInputData.RunClicked)
            //    movementInputData.IsRunning = true;

            //if(movementInputData.RunReleased)
            //    movementInputData.IsRunning = false;

            //movementInputData.JumpClicked = Input.GetKeyDown(KeyCode.Space);
            //movementInputData.CrouchClicked = Input.GetKeyDown(KeyCode.LeftControl);
        }
        #endregion

        #region Input System Callbacks    


        #endregion
    }
}