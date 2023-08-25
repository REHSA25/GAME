using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WereWolf_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Transform playerPos;
    public Vector2 currentPos;
    public float distance;
    public float speedEnemy;

    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speedEnemy * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(transform.position, currentPos) <= 0)
            {

            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currrentPos, speedEnemy * Time.deltaTime);
            }
        }
    }
}
