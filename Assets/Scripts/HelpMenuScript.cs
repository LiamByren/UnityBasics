using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
