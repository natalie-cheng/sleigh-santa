using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    // adjustment for gift position
    private Vector3 reposition;

    // call start
    //private void Start()
    //{

    //}

    // frame update
    private void Update()
    {
        // if the gift is still attached to santa
        if (transform.parent!=null)
        {
            MoveWithPlayer();
        }
    }

    // if the gift is being carried with santa
    private void MoveWithPlayer()
    {
        // adjust pos based on santa orientation
        switch (Santa.orientation)
        {
            case "back":
                reposition = Vector3.up * 0.55f;
                break;
            case "right":
                reposition = Vector3.right * 0.4f + Vector3.down * 0.1f;
                break;
            case "front":
                reposition = Vector3.down * 0.3f + Vector3.left * 0.02f;
                break;
            case "left":
                reposition = Vector3.left * 0.4f + Vector3.down * 0.1f;
                break;
        }

        // set gift pos
        transform.position = transform.parent.position + reposition;
    }

    // place the gift
    public void PlaceGift()
    {
        // leave the gift at current pos, detach from santa
        transform.parent = null;
        // adjust if facing the house
        if (Santa.orientation == "back")
        {
            transform.position += Vector3.down * 0.5f;
        }
        else if (Santa.orientation == "front")
        {
            transform.position += Vector3.up * 0.3f;
        }
    }
}
