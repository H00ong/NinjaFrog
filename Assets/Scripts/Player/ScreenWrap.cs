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

        // ȭ�� ��� ���
        float leftEdge = mainCamera.transform.position.x - screenHalfWidth;
        float rightEdge = mainCamera.transform.position.x + screenHalfWidth;

        // ���� ��ġ �̵�
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

