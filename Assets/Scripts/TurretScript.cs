using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {

    public GameObject Player;
    private float lockontime;
	// Use this for initialization
	void Start () {

        if(gameObject.name.Equals("SentryGun 1"))
        {

            Player = GameObject.Find("Player 1");
        }

        if (gameObject.name.Equals("SentryGun 2"))
        {
            Player = GameObject.Find("Player 2");
        }

    }
	
	// Update is called once per frame
	void Update () {

        //If Player 1 moves across half way line, begin to lock on
        if (Player.name.Equals("Player 1"))
        {
            if (Player.transform.position.x >= 0)
            {
                float angle = Mathf.Atan2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y) / Mathf.PI * 180;
                transform.rotation = Quaternion.Euler(0, 0, 180 - angle);

            }
        }

        if (Player.name.Equals("Player 2"))
        {
            if (Player.transform.position.x <= 0)
            {
                float angle = Mathf.Atan2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y) / Mathf.PI * 180;
                transform.rotation = Quaternion.Euler(0, 0, 180 - angle);

            }
        }


    }
}
