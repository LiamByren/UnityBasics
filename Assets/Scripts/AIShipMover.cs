using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipMover : MonoBehaviour {
    public float rotatespeed;
    public float speed;
    public GameObject targetimage;

    private Rigidbody2D rig;
    private GameObject target;
    private Rigidbody2D targetrig;
    private Vector2 targetposition;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        target= GameObject.Find("Player 1");
        targetrig = target.GetComponent<Rigidbody2D>();

        LockOn();
       
    }
	
	// Update is called once per frame
	void Update () {

        rig.angularVelocity = rotatespeed;

    }


    private void LockOn()
    {
        targetposition = targetrig.position;
        Vector2 moveorder = new Vector2(targetrig.position.x - rig.position.x, targetrig.position.y - rig.position.y);
        rig.AddForce(moveorder * speed);
        var newTarget =Instantiate(targetimage, targetposition,Quaternion.Euler(0,0,0));
        newTarget.name = gameObject.name + " Target";
    }


}
