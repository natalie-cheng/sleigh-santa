using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static House nearestHouse;
    public static bool existsGrinch;
    public static List<GameObject> gifts;


    static Utilities()
    {
        gifts = new List<GameObject>();
        existsGrinch = false;
    }

    public static bool withinRange(Vector3 pos1, Vector3 pos2, float radius)
    {
        // distance to player
        Vector3 distance = pos1 - pos2;

        // return whether it's within radius
        return distance.magnitude <= radius;
    }
}
