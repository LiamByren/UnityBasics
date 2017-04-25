using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentShotMover : MonoBehaviour {

    public GameObject parent;
    public GameObject target;
    public float speed;
    private Rigidbody2D rig;
    private Rigidbody2D targetrig;
    private Vector2 moveorder;
    public GameObject explosion;
    public ObjectSpawner gc;

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        targetrig = target.GetComponent<Rigidbody2D>();
        rig.angularVelocity = 150;
        gc = GameObject.Find("Game Controller").GetComponent<ObjectSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gc.gameover)
        {
            rig.velocity = Vector2.zero;
            rig.angularVelocity = 0;
            return;
        }

        moveorder = new Vector2(targetrig.position.x - rig.position.x, targetrig.position.y - rig.position.y);
        rig.velocity=moveorder.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && gc.gameover == false)
        {
            
            Destroy(GameObject.Find(gameObject.name + " Target"));
            Destroy(gameObject);
            Destroy(other.gameObject);
            ObjectSpawner os = GameObject.Find("Game Controller").GetComponent<ObjectSpawner>();
            var newExp = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(newExp.gameObject, 1);
            if (other.name.Contains("1"))
            {
                os.ScoreAdjust("Player 2");
            }
            else
            {
                os.ScoreAdjust("Player 1");
            }


        }
    }
}
