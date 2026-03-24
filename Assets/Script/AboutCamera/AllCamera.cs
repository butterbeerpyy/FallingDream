using UnityEngine;
using Cinemachine;

public class DynamicCamera : MonoBehaviour
{
    public Transform player;
    public Transform aim;
    public CinemachineVirtualCamera virtualCamera;

    public float sizeFactor = 0.5f; // 缩放比例
    public float smoothSpeed = 5f; // 平滑速度

    private Transform midPoint; // 中间点对象

    private void Start()
    {
        // 创建一个新的空对象来作为相机的追踪目标
        GameObject midPointObject = new GameObject("CameraMidPoint");
        midPoint = midPointObject.transform;

        // 将相机的 Follow 目标设置为 midPoint
        virtualCamera.Follow = midPoint;
    }

    private void LateUpdate()
    {
        if (player != null && aim != null)
        {
            // 计算 player 和 aim 之间的中间点
            Vector3 targetPosition = (player.position + aim.position) / 2;
            midPoint.position = Vector3.Lerp(midPoint.position, targetPosition, smoothSpeed * Time.deltaTime);

            // 计算 player 和 aim 之间的距离
            float distance = Vector3.Distance(player.position, aim.position);
            float targetSize = distance * sizeFactor;

            // 平滑调整镜头大小
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetSize, smoothSpeed * Time.deltaTime);
        }
    }
}
