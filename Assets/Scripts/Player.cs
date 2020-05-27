using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D player;
    public float playerSpeed;
    Animator anim;
    public int dir=1;
    bool immobile = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        attack();
        Debug.Log(immobile);
    }

    public void attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))//Space
        {
            anim.SetTrigger("Space is clicked");
        }
        if (Input.GetButtonUp("Fire1"))//Space is released i.e: Attack is done
        {
            anim.ResetTrigger("Space is clicked");
        }
    }


    public void move()
    {
        if (Input.GetKeyDown(KeyCode.D))//right
        {
            player.velocity = new Vector2(playerSpeed, player.velocity.y);
            dir = 2;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {//left
            dir = 4;
            player.velocity = new Vector2(-playerSpeed, player.velocity.y);
        }

        if (Input.GetButtonUp("Horizontal"))
            player.velocity = new Vector2(0f, player.velocity.y);

        if (Input.GetKeyDown(KeyCode.Z))//Up
        {
            dir = 1;
            player.velocity = new Vector2(player.velocity.x, playerSpeed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            dir = 3;
            //down
            player.velocity = new Vector2(player.velocity.x, -playerSpeed);

        }
        if (Input.GetButtonUp("Vertical"))
            player.velocity = new Vector2(player.velocity.x, 0f);

        anim.SetInteger("Direction", dir);
        if (player.velocity.x == 0f && player.velocity.y == 0f)
            immobile = true;
        else
            immobile = false;
        anim.SetBool("Immobile", immobile);
    }

}