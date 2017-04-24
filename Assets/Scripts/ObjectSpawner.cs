using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject boundary;
    public GameObject noman;
    public GameObject AIShip;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Sentry1;
    public GameObject Sentry2;

    public GameObject score1;
    public GameObject score2;
    public Text t1;
    public Text t2;

    public float aispawntime;
    private float aispawnrandom;
    private float aispawntimer;
    private int shipcounter;

    void Start()
    {
        

        // Created boundaries based on camera size
        Camera cam = Camera.main;
        boundary.transform.localScale = new Vector2(0.5f, cam.orthographicSize * 4);
        noman.transform.localScale = new Vector2(2, cam.orthographicSize * 30);
        Vector2 pos1 = new Vector2(cam.orthographicSize * 2 + 0.2f, 0);
        Vector2 pos2 = new Vector2(-cam.orthographicSize * 2 - 0.2f, 0);
        Vector2 pos3 = new Vector2(0, cam.orthographicSize + 0.2f);
        Vector2 pos4 = new Vector2(0, -cam.orthographicSize - 0.2f);
        Vector2 pos5 = new Vector2(0, 0);
        Instantiate(boundary, pos1, Quaternion.Euler(0, 0, 0));
        Instantiate(boundary, pos2, Quaternion.Euler(0, 0, 180));
        Instantiate(boundary, pos3, Quaternion.Euler(0, 0, 90));
        Instantiate(boundary, pos4, Quaternion.Euler(0, 0, 270));
        Instantiate(noman, pos5, Quaternion.Euler(0, 0, 0));

        SpawnPlayers();


        aispawntimer = -2;
        aispawnrandom = Random.Range(0, 3);
        shipcounter = 0;


    }

    private void Update()
    {
        

        //Spawn new ship every 6-10 seconds
        aispawntimer = aispawntimer + Time.deltaTime;
        if ((aispawntimer + aispawnrandom) > aispawntime)
        {
            var newShip= Instantiate(AIShip, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
            newShip.name = ("AIShip" + shipcounter);
            shipcounter++;
            aispawntimer = 0;
            aispawnrandom = Random.Range(0, 4);
        }
        // If Escape pressed return to main menu
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void SpawnPlayers()

        //Reset the game
    {
        
        var P1 =Instantiate(Player1, new Vector2(-7, 0), Quaternion.Euler(0, 0, 90));
        P1.name = "Player 1";
        var P2 =Instantiate(Player2, new Vector2(7, -0), Quaternion.Euler(0, 0, -90));
        P2.name = "Player 2";

        Instantiate(Sentry1, new Vector2(0, 6), Quaternion.Euler(0, 0, 0));
        Instantiate(Sentry2, new Vector2(0, -6), Quaternion.Euler(0, 0, 180));
      
    }

    public void ScoreAdjust(string player)
    {
        GameObject score1 = GameObject.Find("Player 1 Score");
        GameObject score2 = GameObject.Find("Player 2 Score");
        t1 = score1.GetComponent<Text>();
        t2 = score2.GetComponent<Text>();

        if (player.Contains("1"))
        {
            if (t1.text.Equals("o"))
            {
                t1.text = "i";
            }
            else
            {
                t1.text = t1.text + " i";
            }
        }
        if (player.Contains("2"))
        {
            if (t2.text.Equals("o"))
            {
                t2.text = "i";
            }
            else
            {
                t2.text = t2.text + " i";
            }
        }
        SceneManager.LoadScene("Main Scene");
    }

}



