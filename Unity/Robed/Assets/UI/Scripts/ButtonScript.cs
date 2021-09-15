using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public float runMulti;
    public float jumpMulti;

    private float inputHor;
    //private float inputVer;
    private Rigidbody2D rigB;

    private bool faceRight = true;

    private bool grounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int numJumps;
    private int jumpCounter;
    // Use this for initialization
    void Start()
    {
        rigB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if(touch.phase == TouchPhase.Began)
            {
                
            }
        }
	}
}
