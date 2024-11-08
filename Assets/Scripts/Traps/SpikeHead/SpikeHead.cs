using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : Trap
{
    [SerializeField] Transform defaultPos;
    [SerializeField] Transform targetGround;
    [SerializeField] float upSpeed = 1f;
    [SerializeField] float upTimeDelay = 1.5f;
    
    Rigidbody2D rb;
    bool isUp = false;
    float defaultGravityScale;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        transform.position = defaultPos.position;
        defaultGravityScale = rb.gravityScale;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, defaultPos.position);
        if (isUp && distance > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, defaultPos.position, upSpeed * Time.deltaTime);
        }
        else if (isUp && distance <= 0.1f)
        {
            isUp = false;
            rb.gravityScale = defaultGravityScale;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    IEnumerator Up() 
    {
        yield return new WaitForSeconds(upTimeDelay);
        isUp = true;
    }
}
