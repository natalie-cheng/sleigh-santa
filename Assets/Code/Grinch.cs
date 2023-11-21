using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinch : MonoBehaviour
{
    // get player location
    private Transform player;

    // radius to disappear from the player
    private float radius = 1;

    // whether spotted by the player
    private bool seen = false;
    // how long the grinch stays after spotted
    private float spottedTime = 0.75f;

    // the gift that this grinch is attached to
    public GameObject attachedGift;

    // grinch vars
    private SpriteRenderer spriteRenderer;
    public Sprite shockedGrinch;
    private Animator animator;
    private float lifespan = 8;

    // call start
    private void Start()
    {
        player = FindObjectOfType<Santa>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        StartCoroutine(Disappear());
    }

    // frame update
    private void Update()
    {
        // if the player spots the grinch
        if (!seen && Utilities.withinRange(player.position, transform.position, radius))
        {
            seen = true;
            StartCoroutine(Spotted());
        }
        if (player.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private IEnumerator Spotted()
    {
        // disable animation and change sprite
        animator.enabled = false;
        spriteRenderer.sprite = shockedGrinch;

        // wait for a second
        yield return new WaitForSeconds(spottedTime);

        // destroy grinch
        Utilities.existsGrinch = false;
        Destroy(gameObject);
    }

    private IEnumerator Disappear()
    {
        // wait for lifespan time
        yield return new WaitForSeconds(lifespan);

        // if the grinch wasn't spotted
        if (!seen)
        {
            // remove gift from the list of gifts
            Utilities.gifts.Remove(attachedGift);
            // set the gift's house to ungifted
            if (attachedGift.GetComponent<Gift>().attachedHouse != null)
            {
                attachedGift.GetComponent<Gift>().attachedHouse.gifted = false;
            }
            // destroy gift
            if (attachedGift != null)
            {
                Destroy(attachedGift);
            }
        }

        // destroy grinch
        Utilities.existsGrinch = false;
        Destroy(gameObject);
    }
}
