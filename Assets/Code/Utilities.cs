using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    // track the house that santa is nearest to
    public static House nearestHouse;

    // track whether a grinch exists
    public static bool existsGrinch;

    // track a list of all the placed gifts
    public static List<GameObject> gifts;

    // initialize utilities
    static Utilities()
    {
        // create the gifts list
        gifts = new List<GameObject>();
        // a grinch does not exist to start
        existsGrinch = false;
    }

    // whether two objects are within radius of each other
    public static bool withinRange(Vector3 pos1, Vector3 pos2, float radius)
    {
        // distance
        Vector3 distance = pos1 - pos2;

        // return whether it's within radius
        return distance.magnitude <= radius;
    }
}
