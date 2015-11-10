using UnityEngine;
using System.Collections;

public class Fueguitoizq : MonoBehaviour {
	public bool derecha;
	public ControlesHeroe2 ch;
    public GameObject hero;
	// Use this for initialization
	void Start () {
        derecha = true;
        Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Shoot () 
	{
		hero = GameObject.FindGameObjectWithTag ("Player2");
		ch = hero.GetComponent<ControlesHeroe2>();
		int dir;
		if (ch.facingRight)
		{
			dir=1;
			if(derecha)
				Flip();
		}
		else
		{
			dir = -1;
			if(!derecha)
				Flip();
		}
		//GetComponent<Rigidbody2D> ().AddForce (new Vector2(60 * dir,transform.position.y), ForceMode2D.Impulse);//(new Vector3(x,0f,1f) * 20f,ForceMode.Impulse);
		GetComponent<Rigidbody2D> ().AddForce (new Vector2(30 * dir,transform.position.y), ForceMode2D.Impulse);//(new Vector3(x,0f,1f) * 20f,ForceMode.Impulse);
	}
	public void Flip()
	{
		derecha = !derecha;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        // If it hits an enemy...
        if (col.tag == "Player")
        {
            // ... find the Enemy script and call the Hurt function.
            col.gameObject.GetComponent<ControlesHeroe>().takeDamage(30);

            // Call the explosion instantiation.
            //OnExplode();

            // Destroy the rocket.
            Destroy(gameObject);
        }
        // Otherwise if the player manages to shoot himself...
        else if (col.gameObject.tag == "Player2")
        {
            // Instantiate the explosion and destroy the rocket.
            //OnExplode();
            Destroy(gameObject);
        }
        else 
        {
            //OnExplode();
            Destroy(gameObject);
        }
    }
    void OnExplode()
    {
        //animacion de destruir el cosito
    }
}
