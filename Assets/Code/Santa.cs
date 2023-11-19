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

    // santa vars
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // call start
    private void Start()
    {
        // initialize santa vars
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // frame update
    private void Update()
    {
        Move();
    }

    // move and update sprite
    private void Move()
    {
        // horizontal and vertical input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // set the direction, increase by speed
        Vector2 vec = new Vector2(horizontal, vertical);

        rb.velocity = vec * 2;

        // if moving directly up or downwards
        if (rb.velocity.x == 0)
        {
            // if moving upwards, back santa
            if (rb.velocity.y > 0)
            {
                spriteRenderer.sprite = backSanta;
            }
            // if moving downwards, front santa
            else if (rb.velocity.y < 0)
            {
                spriteRenderer.sprite = frontSanta;
            }
        }

        // otherwise moving sideways
        else
        {
            // if moving right, right santa
            if (rb.velocity.x > 0)
            {
                spriteRenderer.sprite = rightSanta;
            }
            // if moving left, left santa
            else if (rb.velocity.x < 0)
            {
                spriteRenderer.sprite = leftSanta;
            }
        }
    }
}
