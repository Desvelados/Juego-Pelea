using UnityEngine;
using System.Collections;

public class AtaqueHeroe : MonoBehaviour {
	GameObject target;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.UpArrow)){
			Attack();
		}
		else if(Input.GetKeyUp(KeyCode.DownArrow)){
			//AtaqueEspecial();
		}
	}

	void Attack(){
		//float distance = Vector3.Distance (target.transform.position, );
		anim.SetTrigger("Patear");
	}

	//void AtaqueEspecial(){

		////GameObject Fire = GameObject.FindGameObjectWithTag ("Special");
		////Fire.GetComponent<Rigidbody2D>.velocity = new Vector2(10, 0);

	//}
}
