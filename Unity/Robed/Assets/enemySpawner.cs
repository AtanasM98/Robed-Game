using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject spawner;
    public float timerTick;
    private float ticker;
    void Start()
    {
        ticker = timerTick;
    }
	// Update is called once per frame
	void Update () {
        ticker -= Time.deltaTime;
        

        if(ticker <= 0)
        {
            GameObject enemyClone;

            enemyClone = Instantiate(enemy, spawner.transform.position, spawner.transform.rotation) as GameObject;

            ticker = timerTick;
        }
	}
}
