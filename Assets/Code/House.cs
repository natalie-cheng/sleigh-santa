using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    // get player location
    private Transform player;

    // whether santa is near the house
    public bool nearHouse;

    // radius for santa near house
    private float radius = 1.2f;

    // track whether this house has been gifted
    public bool gifted;

    // call start
    void Start()
    {
        player = FindObjectOfType<Santa>().transform;
        nearHouse = false;
        gifted = false;
    }

    // physics update
    private void Update()
    {
        // if santa is near this house
        if (Utilities.withinRange(player.position, transform.position, radius))
        {
            // then this house is the nearest house - the one to be gifted
            Utilities.nearestHouse = this;
            nearHouse = true;
        }
        else
        {
            nearHouse = false;
        }
    }

    // give this house a gift
    public void GiveGift()
    {
        // this house has been gifted
        gifted = true;
    }
}
