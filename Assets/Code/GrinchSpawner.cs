
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinchSpawner : MonoBehaviour
{
    // grinch object
    public GameObject grinchPrefab;

    // probability of grinch spawn every frame update
    private float probability = 0.00028f;
    //private float probability = 0.0025f;

    // radius around gift
    private float radius = 1.1f;

    // gift reference
    private GameObject gift;

    // frame update
    private void Update()
    {
        // if there are gifts, and there is no grinch, and probability
        if (Utilities.gifts.Count > 0 && !Utilities.existsGrinch && Random.value<probability)
        {
            SpawnGrinch();
        }
    }

    // spawn grinch
    private void SpawnGrinch()
    {
        // find a free point near a gift
        Vector2 position = FreePointNearGift();
        // instantiate a grinch at that point
        GameObject grinch = Instantiate(grinchPrefab, position, Quaternion.identity);
        // a grinch now exists
        Utilities.existsGrinch = true;
        // attach the grinch to the gift
        grinch.GetComponent<Grinch>().attachedGift = gift;
    }

    // find a free point near a gift at a house
    private Vector2 FreePointNearGift()
    {
        // find a random index of the existing gifts
        // 0 inclusive for indexing list
        int giftIndex = (int)Random.Range(0, Utilities.gifts.Count);
        // get the random gift and its position
        gift = Utilities.gifts[giftIndex];
        // get the gift position
        Vector2 giftPosition = (Vector2)gift.transform.position;

        // random position within the spawn radius relative to gift
        Vector2 pos = giftPosition + Random.insideUnitCircle * radius;

        // check if collision
        bool free = Physics2D.OverlapCircle(pos, radius);

        // while there is a collision, generate a new point
        while (!free)
        {
            // new random pos
            pos = giftPosition + Random.insideUnitCircle * radius; ;
            // check if free
            free = Physics2D.OverlapCircle(pos, radius);
        }
        // return the free point
        return pos;
    }
}
