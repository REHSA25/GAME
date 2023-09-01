using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
	public float minspeed = 5f;
	public float maxspeed = 9.5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
	public bool facingRight = true;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    public Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.Space)) {
			animator.SetBool("isattacking",true);
		}
		else{
			animator.SetBool("isattacking",false);
		}
        if (Input.GetKey(KeyCode.LeftShift)){ 
			speed = maxspeed; 
		}
		else {
			speed = minspeed; 
		}
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");
		animator.SetBool("istouchingground",isTouchingGround); 
        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            animator.SetBool("ismoving", true);
			if (!facingRight)
			{
				Flip();
			
			}
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            animator.SetBool("ismoving", true);
			if (facingRight)
			{
				Flip();
			
			}
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
            animator.SetBool("ismoving", false);
        }

        if (Input.GetKey(KeyCode.W) && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        animator.SetFloat("yvelocity", player.velocity.y);
    }
	void Flip(){
		Vector3 currentScale = player.transform.localScale;
		currentScale.x *= -1;
		player.transform.localScale = currentScale;
		
		facingRight = !facingRight;
	}

}