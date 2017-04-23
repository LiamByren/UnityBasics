using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    public float delay = 0.2f;
    private float delaytimer = 0;
    private bool collision = false;
    private Rigidbody2D otherrig;
    private AIShipMover amover;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Delays collision to allow ship to move completely onto targer
        if (collision == true)
        {
            delaytimer = delaytimer + Time.deltaTime;
            if (delaytimer > delay)
            {
                amover.LockedOn = false;
                otherrig.velocity = Vector2.zero;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.name.Equals(gameObject.name.Split(' ')[0]))
        {
            otherrig = other.GetComponent<Rigidbody2D>();
            amover = other.GetComponent<AIShipMover>();
            collision = true;
        }
        


    }
}
