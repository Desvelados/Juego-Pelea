using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject prefab;
	private int count=0;
	public Transform target;
	public Animator anim;

	// Use this for initialization
	void Start () {
		GameObject heroe = GameObject.FindGameObjectWithTag ("Player");
		anim = heroe.GetComponent<Animator>(); 
		target = heroe.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position.Set (target.position.x, target.position.y, target.position.z);

		if (Input.GetKeyUp (KeyCode.DownArrow)) 
		{
			GameObject Fueguito = Instantiate (prefab, transform.position, transform.rotation) as GameObject;
			Fueguito.name = "F" + count++ ;
			
			Fueguito fueg = Fueguito.GetComponent<Fueguito>();
			
			//GameObject heroe = GameObject.FindGameObjectWithTag ("Player");
			//Animator anim = heroe.GetComponent<Animator>();
			anim.SetTrigger("Shoot");
			
			fueg.Shoot();
			Destroy (Fueguito, 3f);
		}
	}
}
