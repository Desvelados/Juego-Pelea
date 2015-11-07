using UnityEngine;
using System.Collections;

public class Fueguitoizq : MonoBehaviour {
	public bool derecha;
	public ControlesHeroe2 ch;
	public GameObject hero;
	// Use this for initialization
	void Start () {
		derecha = true;
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
}
