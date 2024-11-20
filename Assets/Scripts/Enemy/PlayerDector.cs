using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Enemy enemy = GetComponentInParent<Enemy>();

            if (enemy is Enemy_BlueBird)
            {
                Enemy_BlueBird blueBird = enemy as Enemy_BlueBird;

                blueBird.playerDetect = true;
                blueBird.player = collision.transform;
            }
            else if(enemy is Enemy_Bat) 
            {
                Enemy_Bat bat = enemy as Enemy_Bat;

                if (bat.canFollow) 
                {
                    bat.playerDetect = true;
                    bat.player = collision.transform;
                }
            }
        }
    }
}
