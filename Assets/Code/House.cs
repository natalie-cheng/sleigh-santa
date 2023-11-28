using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    // get player location
    private Transform player;

    // radius for santa near house
    private float radius = 1.25f;

    // track whether this house has been gifted
    public bool gifted;

    // call start
    private void Start()
    {
        if (FindObjectOfType<Santa>() != null)
        {
            player = FindObjectOfType<Santa>().transform;
        }
        gifted = false;
    }

    // frame update
    private void Update()
    {
        if (FindObjectOfType<Santa>() != null)
        {
            player = FindObjectOfType<Santa>().transform;
        }
        if (player != null)
        {
            // if santa is near this house
            if (Utilities.withinRange(player.position, transform.position, radius))
            {
                // then this house is the nearest house - the one to be gifted
                Utilities.nearestHouse = this;
                Debug.Log("Near hosue");
            }
        }
    }

    // give this house a gift
    public void GiveGift()
    {
        // this house has been gifted
        gifted = true;
    }
}
