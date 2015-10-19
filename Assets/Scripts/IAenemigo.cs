using UnityEngine;
using System.Collections;

public class IAenemigo : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public bool mirandoIzquierda;

	public Transform miTransform;

	void Awake(){
		miTransform = transform;
		mirandoIzquierda = true;
	}
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawLine (target.position, miTransform.position, Color.red);
		//mirar al heroe
		if(target.position.x < miTransform.position.x){
			if(!mirandoIzquierda){
				flip ();
			}
		}
		else{
			if(mirandoIzquierda){
				flip();
			}
		}

	}

	void flip(){
		Vector3 theScale = miTransform.localScale;
		theScale.x *= -1;
		miTransform.localScale = theScale;
		mirandoIzquierda = !mirandoIzquierda;
	}
}
