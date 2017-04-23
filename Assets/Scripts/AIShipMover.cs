using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipMover : MonoBehaviour {
    public float rotatespeed;
    public float speed;
    public GameObject targetimage;
    public float LockTime;
    public bool LockedOn;
 

    private Rigidbody2D rig;
    private GameObject target;
    private Rigidbody2D targetrig;
    private Vector2 targetposition;
    private float LockTimeCounter;
    private Vector2 moveorder;
    private bool CoolingDown;
    private float CoolDownTimer = 0;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        target= GameObject.Find("Player 1");
        targetrig = target.GetComponent<Rigidbody2D>();
        LockedOn = false;
        LockOn();
       
    }
	
	// Update is called once per frame
	void Update () {

      

        //If Locked On, start spinning
        //If LockTime>LockTimeCounter move towards target
        //If reached the target stop and wait for Cooldown
        //If cooled down, aquire new lock

        if(LockedOn==true && LockTimeCounter<LockTime)
        {
            LockTimeCounter = LockTimeCounter + Time.deltaTime;
            rig.AddTorque(rotatespeed * Time.deltaTime);
        }

        if(LockedOn==true && LockTimeCounter > LockTime)
        {
          
            rig.AddForce(moveorder.normalized*speed);

        }
        if (CoolingDown==true)
        {
            CoolDownTimer = CoolDownTimer + Time.deltaTime;

            if (CoolDownTimer > 1)
            {
                CoolingDown = false;
                LockOn();
            }
        }
    }

    //Stop upon reaching the target
    public void Cooldown()
    {
        
        LockedOn = false;
        rig.velocity = Vector2.zero;
        rig.angularVelocity = 0;
        
        transform.position = new Vector2(targetposition.x,targetposition.y);
        CoolingDown = true;
    }


    //Locks on to players predicted position and creates a Target at the position
    public void LockOn()
    {
        rig.velocity = Vector2.zero;
        LockTimeCounter = 0;
        CoolDownTimer = 0;
        moveorder = new Vector2(targetrig.position.x - rig.position.x, targetrig.position.y - rig.position.y);
        moveorder = moveorder + 0.5f*targetrig.velocity;
        targetposition = targetrig.position + 0.5f*targetrig.velocity;
        var newTarget =Instantiate(targetimage, targetposition,Quaternion.Euler(0,0,0));
        newTarget.name = gameObject.name + " Target";
        LockedOn = true;
    }


}
