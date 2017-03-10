using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // used because i resized the turtle from the pixel sheet individually and these are 
    // used to pass to the transform below so that he does not resize when he turns
    public double xScale = -0.8771954;
    public float xScaleF;
    public double yScale = 0.6588759;
    public float yScaleF;

    public float moveSpeed;
    public bool moveRight;
    

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform edgeCheck;

    // Use this for initialization
    void Start ()
    {
        xScaleF = (float) xScale;
        yScaleF = (float)yScale;

    }

    // Update is called once per frame
    void Update () {

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !notAtEdge)
	    {
	        moveRight = !moveRight;
	    }

        if (moveRight)
	    {
            transform.localScale = new Vector3(xScaleF, yScaleF, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
	    }
	    else
	    {
            transform.localScale = new Vector3(-xScaleF, yScaleF, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.x);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && (other.transform.position.y > gameObject.transform.position.y))
            Destroy(gameObject);

    }
}
