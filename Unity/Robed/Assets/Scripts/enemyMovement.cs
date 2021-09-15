using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    public float runMulti;

    public float jumpMulti;
    private float moveHor;
    public int distanceStartFollow;
    public GameObject playerToFollow;
    private Rigidbody2D rigB;
    public bool FaceRight
    {
        get { return faceRight; }
    }
    private bool faceRight = true;
    

    private bool grounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool hitLeftWall;
    public Transform leftWallCheck;
    private bool hitRightWall;
    public Transform rightWallCheck;
    public float wallRadii;
    public LayerMask whatIsWall;

    // Use this for initialization
    void Start () {
        rigB = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {




        FollowPlayer();
        if (!faceRight && moveHor > 0)
        {
            Flip();
        }
        else if (faceRight && moveHor < 0)
        {
            Flip();
        }
        hitLeftWall = Physics2D.OverlapCircle(leftWallCheck.position, wallRadii, whatIsWall);
        hitRightWall = Physics2D.OverlapCircle(rightWallCheck.position, wallRadii, whatIsWall);
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
    void Update()
    {
        
        WhereIsPlayerHor();
        /* if (grounded)
         {
             jumpCounter = numJumps - 1;
         }*/
        if (hitLeftWall || hitRightWall && grounded)
        {
            rigB.velocity = Vector2.up * jumpMulti;
            
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void FollowPlayer()
    {
        if(Vector2.Distance(rigB.transform.position,playerToFollow.transform.position) < distanceStartFollow && grounded)
        {
            rigB.velocity = new Vector2(moveHor * runMulti, rigB.velocity.y);
        }
    }

    void WhereIsPlayerHor()
    {
        if (rigB.transform.position.x < playerToFollow.transform.position.x)
        {
            moveHor = 1;
        }
        else if (playerToFollow.transform.position.x < rigB.transform.position.x)
        {
            moveHor = -1;
        }
    }
}
