using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player1 Score");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        GameObject[] ob = GameObject.FindGameObjectsWithTag("Player2 Score");
        if (ob.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Kill()
    {
        Debug.Log("HI");
        SceneManager.LoadScene("Main Scene");
    }
}
