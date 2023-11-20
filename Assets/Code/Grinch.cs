using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinch : MonoBehaviour
{
    // get player location
    private Transform player;

    // radius to disappear from the player
    private float radius = 2;

    // whether spotted by the player
    private bool seen = false;
    // how long the grinch stays after spotted
    private float spottedTime = 1;

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
    }

    private IEnumerator Spotted()
    {
        // disable animation and change sprite
        animator.enabled = false;
        spriteRenderer.sprite = shockedGrinch;

        // wait for a second
        yield return new WaitForSeconds(spottedTime);

        // destroy grinch
        Destroy(gameObject);
    }

    private IEnumerator Disappear()
    {
        // wait for lifespan time
        yield return new WaitForSeconds(lifespan);

        // destroy gift

        // destroy grinch
        Destroy(gameObject);
    }
}
