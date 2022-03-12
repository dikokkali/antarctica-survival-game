using NaughtyAttributes;
using UnityEngine;

namespace VHS
{
    public class CameraController : MonoBehaviour
    {
        #region Variables
        #region Data
        [Space,Header("Data")]
        [SerializeField] private CameraInputData camInputData = null;

        [Space,Header("Custom Classes")]
        [SerializeField] private CameraZoom cameraZoom = null;
        [SerializeField] private CameraSwaying cameraSway = null;

        #endregion

        #region Settings
        [Space,Header("Look Settings")]
        [SerializeField] private Vector2 sensitivity = Vector2.zero;
        [SerializeField] private Vector2 smoothAmount = Vector2.zero;
        [SerializeField] [MinMaxSlider(-90f,90f)] private Vector2 lookAngleMinMax = Vector2.zero;
        #endregion

        #region Private
        private float m_yaw;
        private float m_pitch;

        private float m_desiredYaw;
        private float m_desiredPitch;

        private float mouseInputYaw;
        private float mouseInputPitch;

        private float _recoilX;
        private float _recoilY;

        private float m_recoilPitch;
        private float m_recoilYaw;

        private Vector3 targetRot;
        private Vector3 returnRot;

        public float returnFactor;
        public float snapFactor;
           

        #region Components                    
        private Transform m_pitchTranform;
        private Camera m_cam;
        #endregion
        #endregion
            
        #endregion

        #region BuiltIn Methods  

        void Awake()
        {
            GetComponents();
            InitValues();
            InitComponents();
            ChangeCursorState();
        }

        void LateUpdate()
        {
            CalculateRotation();
            CalculateRecoil();
            SmoothRotation();          
            ApplyRotation();           
            HandleZoom();           
        }

        #endregion

        #region Custom Methods

        void GetComponents()
        {
            m_pitchTranform = transform.GetChild(0).transform;
            m_cam = GetComponentInChildren<Camera>();
        }

        void InitValues()
        {
            m_yaw = transform.eulerAngles.y;
            m_desiredYaw = m_yaw;
        }

        void InitComponents()
        {
            cameraZoom.Init(m_cam, camInputData);
            cameraSway.Init(m_cam.transform);
        }

        void CalculateRotation()
        {      
            m_desiredYaw += camInputData.InputVector.x * sensitivity.x * Time.deltaTime;
            m_desiredPitch -= camInputData.InputVector.y * sensitivity.y * Time.deltaTime;

            m_desiredPitch = Mathf.Clamp(m_desiredPitch,lookAngleMinMax.x,lookAngleMinMax.y);
        }

        void SmoothRotation()
        {    
            m_yaw = Mathf.Lerp(m_yaw,m_desiredYaw + m_recoilYaw, smoothAmount.x * Time.deltaTime);
            m_pitch = Mathf.Lerp(m_pitch,m_desiredPitch + m_recoilPitch, smoothAmount.y * Time.deltaTime);
        }

        void ApplyRotation()
        {
            transform.eulerAngles = new Vector3(0f,m_yaw,0f);
            m_pitchTranform.localEulerAngles = new Vector3(m_pitch,0f,0f);
        }

        public void HandleSway(Vector3 _inputVector,float _rawXInput)
        {
            cameraSway.SwayPlayer(_inputVector,_rawXInput);
        }

        void HandleZoom()
        {
            if(camInputData.ZoomClicked || camInputData.ZoomReleased)
                cameraZoom.ChangeFOV(this);

        }

        public void ChangeRunFOV(bool _returning)
        {
            cameraZoom.ChangeRunFOV(_returning,this);
        }

        void ChangeCursorState()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        #region Recoil

        void CalculateRecoil()
        {
            targetRot = Vector3.Lerp(targetRot, Vector3.zero, returnFactor * Time.deltaTime);

            m_recoilPitch = -targetRot.x;
            m_recoilYaw = targetRot.y;
        }  

        public void AddRecoil(float verticalRecoil, float horizontalRecoil)
        {
            _recoilX = verticalRecoil;
            _recoilY = horizontalRecoil;

            targetRot += new Vector3(Random.Range(0f, _recoilX), Random.Range(-_recoilY, _recoilY), 0f);
        }  

        #endregion

        #endregion
    }
}
