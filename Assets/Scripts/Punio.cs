using UnityEngine;
using System.Collections;

public class Punio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.5F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player2")
        {
            col.gameObject.GetComponent<ControlesHeroe2>().takeDamage(10);
            Destroy(gameObject);
        }
    }
}
