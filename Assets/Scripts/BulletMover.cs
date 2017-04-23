﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public string color;
    public int maxbounce;
    public GameObject parent;
    public PlayerController pc;
    public Sprite sprite1;

    private Rigidbody2D rig;
    private int bouncecount = 0;
    private SpriteRenderer spriteRenderer;


    void Start () {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = -speed*transform.up;
        if (color.Equals("Red"))
        {
            parent = GameObject.Find("Player 1");
            pc = parent.GetComponent<PlayerController>();
        }
       
       

    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Equals(parent.name))
        {
            if (bouncecount > 0)
            {
                Destroy(gameObject);
            }
            return;
        }
        else

        if (other.tag.Equals("Boundary")){
            bouncecount++;

            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite1;

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