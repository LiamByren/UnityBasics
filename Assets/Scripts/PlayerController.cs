using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotatespeed;
    private float rotatedirection;
    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody2D rig;
    public GameObject shot;
    public Transform shotSpawn;
    public int bulletcount=0;

    // Use this for initialization
    void Start () {
        rotatedirection = 0;
        rig = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad8)&&bulletcount<3)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            bulletcount++;
        }

    }
    

    private void FixedUpdate()
    {
        
        CalMovement();
        CalRotate();

      
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rig.AddForce(movement * speed);
        rig.MoveRotation(rig.rotation + rotatespeed * rotatedirection);



    }

    //Aquire input for rotating
    private void CalRotate()
    {
        if (Input.GetKey(KeyCode.Keypad4))
        {
            rotatedirection = rotatedirection + Time.deltaTime * 4;
            if (rotatedirection > 1)
            {
                rotatedirection = 1;
            }

        }

        if (Input.GetKey(KeyCode.Keypad6))
        {
            rotatedirection = rotatedirection - Time.deltaTime * 4;
            if (rotatedirection < -1)
            {
                rotatedirection = -1;
            }
        }

        if (!Input.GetKey(KeyCode.Keypad6) && !Input.GetKey(KeyCode.Keypad4))
        {
            rotatedirection = 0;
        }
    }


    //Aquire input for movement
    private void CalMovement()
    {
        if (Input.GetKey("right"))
        {
            moveHorizontal = moveHorizontal + Time.deltaTime * 4;
            if (moveHorizontal > 1)
            {
                moveHorizontal = 1;
            }

        }

        if (Input.GetKey("left"))
        {
            moveHorizontal = moveHorizontal - Time.deltaTime * 4;
            if (moveHorizontal < -1)
            {
                moveHorizontal = -1;
            }
        }

        if (!Input.GetKey("left") && !Input.GetKey("right"))
        {
            moveHorizontal = Mathf.MoveTowards(moveHorizontal, 0, Time.deltaTime * 3);
        }


        if (Input.GetKey("down"))
        {
            moveVertical = moveVertical - Time.deltaTime * 4;
            if (moveVertical < -1)
            {
                moveVertical = -1;
            }
        }

        if (Input.GetKey("up"))
        {
            moveVertical = moveVertical + Time.deltaTime * 4;
            if (moveVertical > 1)
            {
                moveVertical = 1;
            }
        }

        if (!Input.GetKey("up") && !Input.GetKey("down"))
        {
            moveVertical = Mathf.MoveTowards(moveVertical, 0, Time.deltaTime * 3);
        }

        


    }
}
