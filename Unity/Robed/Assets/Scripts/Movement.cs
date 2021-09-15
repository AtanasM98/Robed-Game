using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    
    public float runMulti;
    public float jumpMulti;

    private float inputHor;
    
    private Rigidbody2D rigB;
    public bool FaceRight {
        get { return faceRight; }
    }
    private bool faceRight = true;

    private bool grounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int numJumps;
    private int jumpCounter;
	// Use this for initialization
	void Start () {
        rigB = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        inputHor = Input.GetAxis("Horizontal");
        
        rigB.velocity = new Vector2(inputHor * runMulti, rigB.velocity.y);

      //  inputVer = Input.GetAxis("Jump");
      //  rigB.velocity = new Vector2(rigB.velocity.x, inputVer * jumpMulti);

        if(!faceRight && inputHor > 0)
        {
            Flip();
        }else if (faceRight && inputHor < 0)
        {
            Flip();
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void Update()
    {
        if (grounded)
        {
            jumpCounter = numJumps - 1;
        }
        if(Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0)
        {
            rigB.velocity = Vector2.up * jumpMulti;
            jumpCounter--;
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}
