using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Probability
{
    public static bool IsEventHappened(float probability)
    {
        return Random.Range(0f, 1f) < probability;
    }
}
