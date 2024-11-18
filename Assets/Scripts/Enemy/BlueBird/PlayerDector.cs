using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Enemy_BlueBird enemy = GetComponentInParent<Enemy_BlueBird>();
            
            enemy.playerDetect = true;
            enemy.player = collision.transform;
        }
    }
}
