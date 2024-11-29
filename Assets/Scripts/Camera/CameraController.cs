using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] GameObject escMenu;
    [SerializeField] GameObject gameOverMenu;

    private void Start()
    {
        player = PlayerManager.instance.player.transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(0, player.position.y, transform.position.z) + offset;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverMenu.activeSelf)
        {
            if (escMenu.activeSelf)
            {
                escMenu.SetActive(false);
            }
            else 
            {
                escMenu.SetActive(true);
            }
        }
    }
}
