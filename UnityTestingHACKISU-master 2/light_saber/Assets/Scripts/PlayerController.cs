using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public GameObject myo = null;
    public GameObject cEye;
  
    public float speed = 6.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 20.0F;

    public Animation anim;

    void Start()
    {

    }

    private Vector3 moveDirection = Vector3.zero;

    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		float horizontalMovement = Input.GetAxis("Horizontal");
		float verticalMovement = Input.GetAxis("Vertical");

        if (controller.isGrounded) {

			//Shield use
			if ((Input.GetKey (KeyCode.S)) || (thalmicMyo.pose == Thalmic.Myo.Pose.Fist)) 
			{
				anim = GetComponent<Animation> ();
				anim.Play (anim.GetClip ("resist").name);
				//Movement 
				moveDirection = new Vector3 (horizontalMovement, 0, verticalMovement);
				moveDirection = transform.TransformDirection (moveDirection);
			} 

            //Attacking
            else if (Input.GetKey (KeyCode.A)) 
			{
				anim = GetComponent<Animation> ();
				anim.Play (anim.GetClip ("attack").name);
				//Movement 
				moveDirection = new Vector3 (horizontalMovement, 0, verticalMovement);
				moveDirection = transform.TransformDirection (moveDirection);
			} 

			//Jumping
			else if (Input.GetKey (KeyCode.W) )
			{
				anim = GetComponent<Animation>();
				anim.Play (anim.GetClip ("idlebattle").name);
				if (Input.GetKey (KeyCode.LeftArrow))
				{
					moveDirection = new Vector3 (horizontalMovement - 10, jumpSpeed, verticalMovement);

				}
				else if (Input.GetKey (KeyCode.UpArrow))
				{
					moveDirection = new Vector3 (horizontalMovement, jumpSpeed, verticalMovement + 10);

				}
				else if (Input.GetKey (KeyCode.RightArrow)) 
				{
					moveDirection = new Vector3 (horizontalMovement + 10, jumpSpeed, verticalMovement);
				}
				else if (Input.GetKey (KeyCode.DownArrow)) 
				{
					moveDirection = new Vector3 (horizontalMovement, jumpSpeed, verticalMovement - 10);
				} 
				else 
				{
					moveDirection = new Vector3 (horizontalMovement, jumpSpeed, verticalMovement);
				}

				moveDirection = transform.TransformDirection (moveDirection);
			}

			//Walking
			else
			{
				//Detect running
				if (Input.GetKey (KeyCode.LeftControl)) 
				{
					speed = 20.0f;
					anim = GetComponent<Animation> ();
					anim.Play (anim.GetClip ("run").name);
				}

				//Walking
				else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.DownArrow))
				{
					anim = GetComponent<Animation> ();
					anim.Play (anim.clip.name);

				}  
				//Movement 
				moveDirection = new Vector3 (horizontalMovement, 0, verticalMovement);
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection *= speed;

			} 




            
		}  
            
       
       	//Brings him back down to the ground
        moveDirection.y -= 2* gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    //rb.MoveRotation();
    //rb.AddRelativeForce(movement* speed);
}