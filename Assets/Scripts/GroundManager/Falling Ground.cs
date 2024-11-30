using System.Collections;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    [SerializeField] float fallTime = 0.5f;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    public void Fall()
    {
        StartCoroutine(FallEffect());
    }

    IEnumerator FallEffect()
    {
        anim.SetTrigger("Fall");
        yield return new WaitForSeconds(fallTime);

        Destroy(gameObject, 3f);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 1f;
    }
}
