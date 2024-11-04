using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampline : MonoBehaviour
{
    Animator anim;
    Vector3 defaultPos;
    float xPos;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        defaultPos = transform.position;
    }

    private void Start()
    {
        float yWidth = GetComponentInParent<Transform>().localScale.y - 0.1f;
        transform.position = new Vector3(transform.position.x, Random.Range(-yWidth, yWidth), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            anim.SetBool("Up", true);
            collision.GetComponent<Player>().SetVelocity(0, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().SetVelocity(0, 0);
        }
    }
}
