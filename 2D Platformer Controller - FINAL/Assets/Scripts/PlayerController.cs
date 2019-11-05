using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;

    
    public Transform groundCheck; //transform is a point in space /object with location
    public float groundCheckRadius; //how big the circle needs 2 be to determine if you are on the ground
    public LayerMask whatIsGround;
    private bool grounded;  //using boolian to determine if true we are on the ground or false we are not private we want it only in this script

    private bool doubleJumped;

    private Animator anim; //control the component that is on the charackter
    
    public float knockback;     //the force we are going to apply to our player
    public float knockbackLength;   //how long the player will be knockbacked
    public float knockbackCount;    //countdown
    public bool knockFromRight;     //we establish from which side the player is hurt or knocked if the enemy is from the right he goes knocked to the left

    private Rigidbody2D myrigidbody2D;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        

	}

    void FixedUpdate()  //FixedUpdate has the same time between calls also everything that affects the physics or the rigidbody should be executed in fixedupdate
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);   //we know if we are on the ground or not
    }               //If this thing is true grounded is true and if not it's false.

    // Update is called once per frame
    void Update () {        //it's called once per frame on every script that uses it the calls are not arranged at the same time delay

        if (grounded)
            doubleJumped = false;  //he hasn't double jumped because he is on the ground

        anim.SetBool("Grounded", grounded);

        if(Input.GetButtonDown("Jump") && grounded) //If the Spacebar is pressed down, get key down works only once the button is pressed and also checks if we are on the ground
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);                 //volocity - the speed that the player is moving we set to velocity to be set to jump height vctor 2 - holds x and y value and we don't want to affect our left and right
            Jump();     //velocity is the speed in 3 different directions
            

        }

        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Jump();
            doubleJumped = true;
        }

        //moveVelocity = 0f;



        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");



        if(knockbackCount <=0.1) //you are able to move the player until you get knocked
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);   //the call that tells the player if he is moving (left or right)
        }                                                                                                   //velocity means the operation or the speed in 3 differen axis
        else
        {
            if (knockFromRight) //if knock from right is true it means enemy is on right
                GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);  //so we add minus to knick player in another direction (if he gets knocked from the right he hoes to the left and also in the air
            if(!knockFromRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime; //the knockback always goes downwards (3, 2, 1, 0)

        }



        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));   //tells us which float we've created / that tells us if it's moving left or right
                                                                                     //Mathf.Abs it returns a value that doesn't have negative numbers (if it's -5 it makes it 5)


        if (GetComponent<Rigidbody2D>().velocity.x > 0)//making player flip to side
            transform.localScale = new Vector3(1f, 1f, 1f);  //localScale is the size of the player also we don't worry about the z in the vector 3
        else if(GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); //otherwise it will make the transform on x axsis -1 which makes him flip around
        }

    }
    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
