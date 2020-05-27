using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{
    public BoxCollider2D territory;
    public BoxCollider2D range;
    GameObject player;
    bool playerInTerritory;
    bool playerInRange ;
    Animator anim;
    

    public GameObject enemy;
    BasicEnemy basicenemy;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        basicenemy = enemy.GetComponent<BasicEnemy>();
        playerInTerritory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTerritory == true && !playerInRange)
        {
            basicenemy.MoveToPlayer();
        }

        if (playerInRange == true)
        {
            basicenemy.Attack();
        }
        //if (playerInRange == false)
        //    basicenemy.notattack();
    }

    void OnTriggerEnter2D(Collider2D territory)
    {
        if (territory.gameObject == player)
        {
            playerInTerritory = true;
        }
    }

    private void OnTriggerEnterRange2D(Collider2D range)
    {
        if (range.gameObject == player)
        {
            playerInRange = true;
            anim.SetTrigger("InRange");
            Debug.Log("In range");
        }
    }
    /*private void OnTriggerExitrRange2D(Collider2D range)
    {
        if (range.gameObject != player)
        {
            playerInRange = false;
        }
    }*/
}

