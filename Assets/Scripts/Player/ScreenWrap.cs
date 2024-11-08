using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    [SerializeField] float xOffset;
    private Camera mainCamera;
    private float screenHalfWidth;

    private void Start()
    {
        mainCamera = Camera.main;
        screenHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
    }

    private void Update()
    {
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

