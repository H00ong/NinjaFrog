using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonAnimationTrigger : MonoBehaviour
{
    [SerializeField] private Enemy_Chameleon enemyChameleon;
    [SerializeField] private Transform attackTrigger;

    public void SetScale(float _xScale) 
    {
        attackTrigger.localScale = new Vector3(_xScale, 1, 1);
    }

    public void SetAttackOff()
    {
        attackTrigger.GetComponent<Collider2D>().enabled = false;
        enemyChameleon.animationTrigger = true;
    }

    public void SetAttackOn()
    {
        attackTrigger.GetComponent<Collider2D>().enabled = true;
    }
}
