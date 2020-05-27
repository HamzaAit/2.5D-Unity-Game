using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour

{
    public Rigidbody2D enemy;
    public Transform target;
    public float speed = 3f;
    public float attack1Range = 1f;
    public int attack1Damage = 1;
    public float timeBetweenAttacks;
    bool immobile = true;
    Animator anim;
    public int dir = 3;


    public float EPSILON { get; private set; }


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Immobile", true);
    }

    // Update is called once per frame
    void Update()
    {
        //if (enemy.velocity.x == 0f && enemy.velocity.y == 0f)
        //    immobile = false;
        //else
        //    immobile = false;
        anim.SetInteger("Direction", dir);
        anim.SetBool("Immobile", immobile);

    }

    public void MoveToPlayer()
    {
        Debug.Log("I'm moving");

        immobile = false;
        anim.SetBool("Immobile", false);
        
        if (System.Math.Abs(target.position.y - transform.position.y) > 0.01)
        {

            if (target.position.y > transform.position.y)
            {
                transform.Translate(Vector3.up * Time.deltaTime);
                dir = 1;
            }
            else if (target.position.y < transform.position.y)
            {
                transform.Translate(Vector3.down * Time.deltaTime);
                dir = 3;
            }
            


        }
        else if (System.Math.Abs(target.position.x - transform.position.x) > 0.01)
        {

            if (target.position.x > transform.position.x)
            {
                transform.Translate(Vector3.right * Time.deltaTime);
                dir = 2;
            }
            else if (target.position.x < transform.position.x)
            {
                transform.Translate(Vector3.left * Time.deltaTime);
                dir = 4;
            }
            immobile = false;

        }
        else
        {
            Attack();
        }
        
    }

    public void Attack()
    {
        Debug.Log("range");
        anim.SetTrigger("InRange");


    }
    public void Notattack()
    {
        anim.ResetTrigger("InRange");
    }

}