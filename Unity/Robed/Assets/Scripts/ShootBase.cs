using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBase : MonoBehaviour {

    public Rigidbody2D bul;
    public int speedMulti;
    public Transform startFrom;
    

    private Movement move;
	void Start()
    {
        move = GetComponent<Movement>();
    }
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D bulClone;
          
            bulClone = Instantiate(bul, startFrom.transform.position, startFrom.transform.rotation) as Rigidbody2D;
            if (move.FaceRight)
            {
                bulClone.velocity = transform.TransformDirection(Vector2.right * speedMulti);
                
            }
            else
            {
                bulClone.velocity = transform.TransformDirection(Vector2.left * speedMulti);
            }
            Destroy(bulClone.gameObject, 3);
        }
		
	}
}
