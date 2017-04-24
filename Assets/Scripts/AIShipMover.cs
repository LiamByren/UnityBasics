using UnityEngine;

public class AIShipMover : MonoBehaviour {
    public float rotatespeed;
    public float speed;
    public GameObject targetimage;
    public float LockTime;
    public bool LockedOn;
    public GameObject explosion;

    private Rigidbody2D rig;
    private GameObject target;
    private Rigidbody2D targetrig;
    private Vector2 targetposition;
    private float LockTimeCounter;
    private Vector2 moveorder;
    private bool CoolingDown;
    private float CoolDownTimer = 0;
    private bool isQuit = false;
    private bool normalcollision = true;
    

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        if (Random.value > 0.5)
        {
            target = GameObject.Find("Player 1");
        }
        else
        {
            target = GameObject.Find("Player 2");
        }
        targetrig = target.GetComponent<Rigidbody2D>();
        LockedOn = false;
        LockOn();
       

    }

    private void OnDestroy()
    {
        if (isQuit == false && normalcollision == true)
        {   
            var newExp =Instantiate(explosion, transform.position, transform.rotation);
            Destroy(newExp.gameObject, 1);
        }
    }

    private void OnApplicationQuit()
    {
        isQuit = true;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            normalcollision = false;
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
