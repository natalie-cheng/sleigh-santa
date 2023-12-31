using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleigh : MonoBehaviour
{
    // get player location
    private Transform player;

    // if santa is near sleigh
    public static bool nearSleigh;

    // radius for what is considered near sleigh
    private float radius = 1.45f;

    // call start
    private void Start()
    {
        player = FindObjectOfType<Santa>().transform;
        nearSleigh = false;
    }

    // frame update
    private void Update()
    {
        if (Utilities.withinRange(player.position, transform.position, radius))
        {
            nearSleigh = true;
        }
        else
        {
            nearSleigh = false;
        }
    }
}
