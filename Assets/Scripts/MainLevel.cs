using UnityEngine;
using System.Collections;

public class MainLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        //ControlesHeroe2 ch = (ControlesHeroe2)player2.GetComponent("ControlesHeroe2");
        //ch.Flip();

        player2.gameObject.GetComponent<ControlesHeroe2>().Flip();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
