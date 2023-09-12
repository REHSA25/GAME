using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereWolf_Movement : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed = 2.5f;

    private bool facingLeft;
    public Animator animator;

    public bool isattacking = false;

    // Variables for Health Bar
    public int maxHealth = 2;
    public int currentHealth;
    public HealthBar healthBar;

    // Get Samurai GameObject to check if it is attacking
    public GameObject Samurai;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        animator.SetBool("isattacking", isattacking);
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
            isattacking = true;
            if (Samurai.GetComponent<PlayerController>().isAttacking)
            {
                TakeDamage(1);
            }
        }
    }

    void stopattacking()
    {
        isattacking = false;
    }

    void TakeDamage (int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
