using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject boundary;
    public GameObject noman;
    public GameObject AIShip;
    public float aispawntime;
    private float aispawnrandom;
    private float aispawntimer;
    private int shipcounter;

    void Start()
    {
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

        aispawntimer = -2;
        aispawnrandom = Random.Range(0, 3);
        shipcounter = 0;


    }

    private void Update()
    {
        aispawntimer = aispawntimer + Time.deltaTime;
        if ((aispawntimer + aispawnrandom) > aispawntime)
        {
            var newShip= Instantiate(AIShip, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
            newShip.name = ("AIShip" + shipcounter);
            shipcounter++;
            aispawntimer = 0;
            aispawnrandom = Random.Range(0, 4);
        }

    }


}
