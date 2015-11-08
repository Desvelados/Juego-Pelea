using UnityEngine;
using System.Collections;

public class Spawnerizq : MonoBehaviour {
	public GameObject prefab;
	private int count=0;
	public Transform target;
	public Animator anim;

	// Use this for initialization
	void Start () {
		GameObject heroe = GameObject.FindGameObjectWithTag ("Player2");
		anim = heroe.GetComponent<Animator>(); 
		target = heroe.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position.Set (target.position.x-1, target.position.y, target.position.z);
        
		/*if (Input.GetKeyUp (KeyCode.DownArrow)) 
		{
			
		}*/
	}
    public void shoot() 
    {
        GameObject Fueguito = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        Fueguito.name = "F2" + count++;

        Fueguitoizq fueg = Fueguito.GetComponent<Fueguitoizq>();

        //GameObject heroe = GameObject.FindGameObjectWithTag ("Player");
        //Animator anim = heroe.GetComponent<Animator>();
        anim.SetTrigger("Shoot");

        fueg.Shoot();
    }
}
