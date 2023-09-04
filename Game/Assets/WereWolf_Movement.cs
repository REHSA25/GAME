using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereWolf_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public float MoveSpeed = 2.5f;

    private bool facingLeft;
    public Animator animator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        if (Player.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            facingLeft = false;
        } else
        {
            scale.x = Mathf.Abs(scale.x);
            facingLeft = true;
        }

        transform.localScale = scale;

        if (facingLeft)
        {
            transform.position -= transform.right * MoveSpeed * Time.deltaTime;
        } else
        {
            transform.position += transform.right * MoveSpeed * Time.deltaTime;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Samurai 1")
        {
            animator.SetBool("isattacking", true); 
        }
    }
}
