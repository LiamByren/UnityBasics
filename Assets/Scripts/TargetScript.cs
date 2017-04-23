using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    public float delay = 0.2f;
    private AIShipMover amover;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale += new Vector3(-0.1f*Time.deltaTime, -0.1f*Time.deltaTime, 0);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Stop the Rotation of AIShip once it reaches target
        if(other.name.Equals(gameObject.name.Split(' ')[0]))
        {
            amover = other.GetComponent<AIShipMover>();
            amover.Cooldown();
            Destroy(gameObject);
        }
        


    }
}
