using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    [SerializeField] float xOffset;
    private Camera mainCamera;
    private float screenHalfWidth;

    private void OnEnable()
    {
        mainCamera = Camera.main;
        screenHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
    }

    private void Update()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        Vector3 playerPosition = transform.position;

        // 화면 경계 계산
        float leftEdge = mainCamera.transform.position.x - screenHalfWidth;
        float rightEdge = mainCamera.transform.position.x + screenHalfWidth;

        // 원래 위치 이동
        if (playerPosition.x < leftEdge)
        {
            playerPosition.x = rightEdge - xOffset;
        }
        else if (playerPosition.x > rightEdge)
        {
            playerPosition.x = leftEdge + xOffset;
        }

        transform.position = playerPosition;
    }
}

