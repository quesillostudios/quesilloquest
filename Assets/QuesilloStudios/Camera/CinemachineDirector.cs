using UnityEngine;
using Cinemachine;

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

    public void SwitchToCam(CinemachineVirtualCameraBase camera)
    {
        foreach (var virtualCam in virtualCams)
        {
            if(virtualCam == camera) virtualCam.Priority = 1;
            else virtualCam.Priority = 0;
        }
    }

    public CinemachineVirtualCameraBase GetDefaultCamera()
    {
        return defaultVirtualCamera;
    }
}