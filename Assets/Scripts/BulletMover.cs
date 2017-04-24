using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public string color;
    public int maxbounce;
    public GameObject parent;
    public PlayerController pc;
    public Sprite RedBounce;
    public Sprite BlueBounce;


    private Rigidbody2D rig;
    private int bouncecount = 0;
    private SpriteRenderer spriteRenderer;


    void Start () {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = -speed*transform.up;
       

        //Red Lasers for Player 1 Blue Lasers for Player 2
        if (color.Equals("Red"))
        {
            parent = GameObject.Find("Player 1");
            pc = parent.GetComponent<PlayerController>();
        }

        if (color.Equals("Blue"))
        {
            parent = GameObject.Find("Player 2");
            pc = parent.GetComponent<PlayerController>();
        }



    }



    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If collision with the parent after a bounce destory the bullet
        if (other.name.Equals(parent.name))
        {
            if (bouncecount > 0)
            {
                Destroy(gameObject);
                pc.bulletcount--;
            }
            return;
        }

        //If Collision with AiSHIp destory the ship

        if (other.tag.Equals("AIShip")){
            Destroy(other.gameObject);
            Destroy(GameObject.Find(other.gameObject.name + " Target"));
            Destroy(gameObject);
            pc.bulletcount--;
            return;
        }
        
        


        //Bounce off walls Method
        //Correct angle of bounce calculated with parallel and perpendiclar vectors
        if (other.tag.Equals("Boundary")){
            bouncecount++;

            //Change color of bullet when it bounces
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (color.Equals("Red"))
            {
                spriteRenderer.sprite = RedBounce;
            }
            else
            {
                spriteRenderer.sprite = BlueBounce;
            }
           

            float normal = other.transform.rotation.eulerAngles.z - 90;
            if (normal < 0)
            {
                normal = 360 + normal;
            }
            float normalrad = normal / 180 * Mathf.PI;
            Vector2 normvect=  new Vector2((float)Mathf.Cos(normalrad), (float)Mathf.Sin(normalrad));
            Vector2 bulletvect = rig.velocity;

            Vector2 u = (Vector2.Dot(bulletvect, normvect) / Vector2.Dot(normvect, normvect))* normvect;
            Vector2 w = bulletvect - u;
            Vector2 v = u - 1.2f*w;
            rig.velocity = v;
            rig.rotation=(Mathf.Atan2(v.y, v.x)*180/Mathf.PI)-90;

            if (bouncecount > maxbounce)
            {
                Destroy(gameObject);
                pc.bulletcount--;
                
            }


        }
    }

}
