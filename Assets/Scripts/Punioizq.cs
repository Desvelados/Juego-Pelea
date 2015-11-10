using UnityEngine;
using System.Collections;

public class Punioizq : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.5F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<ControlesHeroe>().takeDamage(10);
            Destroy(gameObject);
        }
    }
}
