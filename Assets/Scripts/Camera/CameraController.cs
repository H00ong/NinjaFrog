using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;

    void LateUpdate()
    {
        transform.position = new Vector3(0, player.position.y, transform.position.z) + offset;
    }
}
