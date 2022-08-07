using Cinemachine;
using UnityEngine;

namespace QuesilloStudios.Camera
{
    public class CameraCollisionSwitch : MonoBehaviour
    {
        [SerializeField] private CinemachineDirector cinemachineDirector;
        [SerializeField] private CinemachineVirtualCameraBase cameraTrigger;

        private static int areaMultiply;
        private static bool isInArea;

        private void OnTriggerEnter(Collider other) 
        {
            isInArea = true;
            areaMultiply++;
            cinemachineDirector.SwitchToCam(cameraTrigger);
        }

        private void OnTriggerExit(Collider other) 
        {
            if (isInArea == false || areaMultiply <= 1)
            {
                areaMultiply = 0;
                cinemachineDirector.SwitchToCam(cinemachineDirector.GetDefaultCamera());
            }

            isInArea = false;
        }
    }
}