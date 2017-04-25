using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {

    public GameObject Player;
    public GameObject shot;
    public float lockontime;
    private float lockontimer;
    public ObjectSpawner gc;
	// Use this for initialization
	void Start () {
        gc = GameObject.Find("Game Controller").GetComponent<ObjectSpawner>();
        lockontimer = 0;
        if(gameObject.name.Contains("SentryGun 1"))
        {

            Player = GameObject.Find("Player 1");
        }

        if (gameObject.name.Contains("SentryGun 2"))
        {
            Player = GameObject.Find("Player 2");
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (gc.gameover)
        {
            return;
        }

        if (Player == null)
        {
           return;
        }

        //If Player 1 moves across half way line, begin to lock on
        if (Player.name.Equals("Player 1"))
        {
            if (Player.transform.position.x >= 0)
            {
                float angle = Mathf.Atan2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y) / Mathf.PI * 180;
                transform.rotation = Quaternion.Euler(0, 0, 180 - angle);
                lockontimer = lockontimer + Time.deltaTime;
                if (lockontimer > lockontime)
                {
                   var newShot = Instantiate(shot, transform.position, Quaternion.Euler(0, 0, 0));
                    newShot.GetComponent<TurrentShotMover>().parent = gameObject;
                    newShot.GetComponent<TurrentShotMover>().target = Player;
                    lockontimer = -5;
                }
            }
        }

        if (Player.name.Equals("Player 2"))
        {
            if (Player.transform.position.x <= 0)
            {
                float angle = Mathf.Atan2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y) / Mathf.PI * 180;
                transform.rotation = Quaternion.Euler(0, 0, 180 - angle);
                lockontimer = lockontimer + Time.deltaTime;

                if (lockontimer > lockontime)
                {
                   var newShot= Instantiate(shot, transform.position, Quaternion.Euler(0, 0, 0));
                    newShot.GetComponent<TurrentShotMover>().parent = gameObject;
                    newShot.GetComponent<TurrentShotMover>().target = Player;
                    lockontimer = -5;
                }

            }
        }


    }
}
