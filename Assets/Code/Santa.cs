using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    // santa sprites
    public Sprite frontSanta;
    public Sprite backSanta;
    public Sprite rightSanta;
    public Sprite leftSanta;

    // gifts
    public GameObject gift1Prefab;
    public GameObject gift2Prefab;
    private GameObject gift;

    // santa vars
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool hasGift;
    public static string orientation;
    public float speed = 2;

    // call start
    private void Start()
    {
        // initialize santa vars
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hasGift = false;
        orientation = "front";
        animator.SetBool("Front", true);
        //currentTime = Time.time;
    }

    // frame update
    private void Update()
    {
        Move();

        // if santa doesn't have gift and is near sleigh
        if (Input.GetButtonDown("Gift"))
        {
            // if santa doesn't have a gift and is near sleigh
            if (!hasGift && Sleigh.nearSleigh)
            {
                // get santa a gift
                GetGift();
            }
            // otherwise if he has a gift, is near a house, and that house doesn't have a gift
            else if (hasGift && gift != null && Utilities.nearestHouse!=null && !Utilities.nearestHouse.gifted)
            {
                // place the gift
                gift.GetComponent<Gift>().PlaceGift(Utilities.nearestHouse);
                // add it to the list of gifts
                Utilities.gifts.Add(gift);
                // santa doesn't have a gift anymore
                hasGift = false;
                // mark that house as gifted
                Utilities.nearestHouse.GiveGift();
            }
        }
    }

    // move and update sprite
    private void Move()
    {
        // horizontal and vertical input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // set the direction, increase by speed
        Vector2 vec = new Vector2(horizontal, vertical);;
        rb.velocity = vec * speed;

        // update animation
        if (vec.magnitude > 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        // if moving directly up or downwards
        if (rb.velocity.x == 0)
        {
            // if moving upwards, back santa
            if (rb.velocity.y > 0)
            {
                //spriteRenderer.sprite = backSanta;
                orientation = "back";
                animator.SetBool("Back", true);
                animator.SetBool("Right", false);
                animator.SetBool("Front", false);
                animator.SetBool("Left", false);
            }
            // if moving downwards, front santa
            else if (rb.velocity.y < 0)
            {
                //spriteRenderer.sprite = frontSanta;
                orientation = "front";
                animator.SetBool("Back", false);
                animator.SetBool("Right", false);
                animator.SetBool("Front", true);
                animator.SetBool("Left", false);
            }
        }
        // otherwise moving sideways
        else
        {
            // if moving right, right santa
            if (rb.velocity.x > 0)
            {
                //spriteRenderer.sprite = rightSanta;
                orientation = "right";
                animator.SetBool("Back", false);
                animator.SetBool("Right", true);
                animator.SetBool("Front", false);
                animator.SetBool("Left", false);
            }
            // if moving left, left santa
            else if (rb.velocity.x < 0)
            {
                //spriteRenderer.sprite = leftSanta;
                orientation = "left";
                animator.SetBool("Back", false);
                animator.SetBool("Right", false);
                animator.SetBool("Front", false);
                animator.SetBool("Left", true);
            }
        }
    }

    // generate the gift
    private void GetGift()
    {
        // create gift
        if (Random.value < 0.5f)
        {
            gift = Instantiate(gift1Prefab, transform.position, Quaternion.identity);
        }
        else
        {
            gift = Instantiate(gift2Prefab, transform.position, Quaternion.identity);
        }
        // set it to a child of santa
        gift.transform.parent = transform;
        // santa now has a gift
        hasGift = true;
    }
}
