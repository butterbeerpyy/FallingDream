using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera heroCamera;
    public CinemachineVirtualCamera allCamera;
    private CinemachineVirtualCamera activeCamera;
    public float switchSpeed = 0.1f;

    void Start()
    {
        // Ä¬ÈÏ¼¤»î HeroCamera
        activeCamera = heroCamera;
        heroCamera.Priority = 10;
        allCamera.Priority = 5;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCamera();
        }
        
    }
    void SwitchCamera()
    {
        if (activeCamera == heroCamera)
        {
            heroCamera.Priority = 5;
            allCamera.Priority = 10;
            activeCamera = allCamera;
        }
        else
        {
            heroCamera.Priority = 10;
            allCamera.Priority = 5;
            activeCamera = heroCamera;
        }
    }
}
