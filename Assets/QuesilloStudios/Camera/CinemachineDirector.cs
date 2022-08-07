using Cinemachine;
using UnityEngine;

namespace QuesilloStudios.Camera
{
    public class CinemachineDirector : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCameraBase[] virtualCams;
        [SerializeField] private CinemachineVirtualCameraBase defaultVirtualCamera;

        private void Start() 
        {
            if (virtualCams.Length != 0)
            {
                defaultVirtualCamera = virtualCams[0];
            }
        }

        public void SwitchToCam(CinemachineVirtualCameraBase virtualCamera)
        {
            foreach (var virtualCam in virtualCams)
            {
                virtualCam.Priority = virtualCam == virtualCamera ? 1 : 0;
            }
        }

        public CinemachineVirtualCameraBase GetDefaultCamera()
        {
            return defaultVirtualCamera;
        }
    }
}