using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinch : MonoBehaviour
{
    // get player location
    private Transform player;

    // radius to disappear from the player
    private float radius = 1.2f;

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
    private AudioSource audioSource;
    public AudioClip grinchSpawn;
    public AudioClip grinchScare;
    private float lifespan = 5;

    // call start
    private void Start()
    {
        // initialize grinch vars
        player = FindObjectOfType<Santa>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        // begin counting down to disappear
        StartCoroutine(Disappear());
        // play sound effect
        audioSource.PlayOneShot(grinchSpawn,3);
    }

    // frame update
    private void Update()
    {
        // if the player spots the grinch
        if (!seen && Utilities.withinRange(player.position, transform.position, radius))
        {
            // mark the grinch as seen
            seen = true;
            // start the spotted routine
            StartCoroutine(Spotted());
        }
        // keep the grinch facing the direction of the player
        if (player.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        // destroy self if the game is over
        if (UI.gameOver)
        {
            Destroy(gameObject);
        }
    }

    // coroutine if grinch is spotted
    private IEnumerator Spotted()
    {
        // disable animation and change sprite
        animator.enabled = false;
        spriteRenderer.sprite = shockedGrinch;

        // play scared audio
        audioSource.PlayOneShot(grinchScare);

        // wait for a second
        yield return new WaitForSeconds(spottedTime);

        // destroy grinch
        Utilities.existsGrinch = false;
        Destroy(gameObject);
    }

    // coroutine for grinch existence
    private IEnumerator Disappear()
    {
        // wait for lifespan time
        yield return new WaitForSeconds(lifespan);

        // if the grinch wasn't spotted, take the gift
        if (!seen && attachedGift!=null)
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
