using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;
    private int currHealth;
   

	// Use this for initialization
	void Start () {
        currHealth = maxHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TakeDamage(int damage)
    {
        
        if(currHealth > damage)
        {
            currHealth -= damage;
        }
        else// if(currHealth <= damage)
        {
            //Die script
        }
    }
}
