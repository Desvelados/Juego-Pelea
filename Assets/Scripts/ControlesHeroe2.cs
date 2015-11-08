using UnityEngine;
using System.Collections;

public class ControlesHeroe2 : MonoBehaviour {

	//[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;               // Condition for whether the player should jump.
    private bool vivo = true;

    public int healthPoints = 100;
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	//public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 450f;			// Amount of force added when the player jumps.
	
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
    private GameObject healthBar;

	//objeto de secuencia de prueba
	KeySequence lTestSequence = new KeySequence(new KeySequence.HandleCallback(ControlesHeroe2.TestSequencePressed));

	static void TestSequencePressed(KeySequence sec){
        GameObject heroe = GameObject.FindGameObjectWithTag("Player2");
        heroe.GetComponentInChildren<Spawnerizq>().shoot();
	}


	void Awake(){
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		anim = GetComponent<Animator>();
        healthBar = GameObject.FindGameObjectWithTag("BarraP2");

		//declaracion de secuencia de prueba
        lTestSequence.AddKey2Sequence(KeyCode.RightArrow);
        lTestSequence.AddKey2Sequence(KeyCode.DownArrow);
        lTestSequence.AddKey2Sequence(KeyCode.LeftArrow);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

		//Update del objeto de secuencia de prueba
		lTestSequence.Update ();

		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetKey(KeyCode.UpArrow) && grounded)
			jump = true;
	}

	void FixedUpdate (){
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * 0.17f;// * Time.deltaTime;// speed;// * Time.deltaTime;
            anim.SetFloat("Speed", 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * 0.17f;// * Time.deltaTime;
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
        /*
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");
		
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(h));
		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			// ... add a force to the player.
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();
		*/
		// If the player should jump...
		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");
			
			// Play a random jump audio clip.
			//int i = Random.Range(0, jumpClips.Length);
			//AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
			
			// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}
	public void Flip (){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    public void takeDamage(int cant)
    {
        if (vivo)
        {
            healthPoints -= cant;
            //hago cosa para actualizar la barra
            healthBar.GetComponent<BarraVida2>().takeDamage(cant);
            if (healthPoints <= 0)
            {
                //me mori
                GetComponent<ControlesHeroe2>().enabled = false;
                //animacion de muerte
                //anim.SetTrigger("Die");
                anim.SetFloat("Speed", 0);
                anim.transform.Rotate(0, 0, -90);
                anim.Stop();
                vivo = false;
            }
        }
    }
}
