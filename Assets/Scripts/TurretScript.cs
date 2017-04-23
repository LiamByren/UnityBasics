using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {

    public GameObject Player1;
    private float lockontime;
	// Use this for initialization
	void Start () {
		Player1= GameObject.Find("Player 1");
    }
	
	// Update is called once per frame
	void Update () {
        if (Player1.transform.position.x >= 0)
        {
            float angle = Mathf.Atan2(Player1.transform.position.x - transform.position.x, Player1.transform.position.y - transform.position.y) / Mathf.PI * 180;
            transform.rotation = Quaternion.Euler(0, 0, 180- angle);
            
        }
	}
}
