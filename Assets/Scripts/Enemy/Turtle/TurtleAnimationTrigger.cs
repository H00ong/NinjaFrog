using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleAnimationTrigger : MonoBehaviour
{
    [SerializeField] private GameObject spikes;

    public void ActivateSpikes()
    {
        spikes.SetActive(true);
    }

    public void DeactivateSpikes() 
    {
        spikes.SetActive(false);
    }
}
