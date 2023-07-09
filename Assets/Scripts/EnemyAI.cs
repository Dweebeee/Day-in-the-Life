using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour

{
    private Rigidbody2D rb;
    public GameObject player;
    public float movespeed;
    private Vector2 dirToPlayer;
    private Vector2 localscale;
    private float angle;
    public bool combat;
    private bool moving;


    public GameObject enemyAttack;
    private bool attackOnCooldown = false;
    public float initialAttackDelay;
    public float attackTime;
    public float attackCooldown;

    // THis is because we have changed the trigger detection so it now happens everyframe
    //public bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        localscale= transform.localScale;
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (combat) 
        {
            // IDEA: maybe rotate the knight slowly when he is  doing his attack instead of him standing dead still?
            RotateToPlayer();
            
            
            MoveEnemy();

        }
        
    }
    public void MoveEnemy()
    {
        if (moving)
        {
                // Finds the direction to the player in the form of a normalized vector
                dirToPlayer = (player.transform.position - transform.position).normalized;
            // sets the velocity of the enemy so it continues to move towards the player
            rb.velocity = new Vector2(dirToPlayer.x, dirToPlayer.y) * movespeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    public void RotateToPlayer()
    {
        // Code to rotate the enemy so that they always face the player
        // finds the vector from the enemy to the player
        dirToPlayer = (transform.position - player.transform.position);
        // converts the x & y coordinates from the the previous step to an angle (first in radians & then converted to degrees)
        angle = -Mathf.Atan2(dirToPlayer.x, dirToPlayer.y) * Mathf.Rad2Deg;
        // finally it rotates the players sprite so that it corresponds with this angle(direction)
        transform.rotation = Quaternion.AngleAxis(angle + 180, Vector3.forward);

        // Calls a script to update the angle text on screen
        //gameplayManager.UpdateAngle(((int)angle));
        //Debug.Log(angle);;
    }

    public void callEnemyAttack()
    {
        if (attackOnCooldown == false)
        {
            Debug.Log("Enemy stop moving");
            moving = false;
            StartCoroutine(EnemyAttack());
            
        }
    }

    // need to call this FROM SOMEWHERE
    IEnumerator EnemyAttack()
    {
        attackOnCooldown = true;
        // Initial attack delay
        yield return new WaitForSeconds(initialAttackDelay);
        
        // Enable attack box
        enemyAttack.SetActive(true);
        
        // wait attackTime
        yield return new WaitForSeconds(attackTime);
        
        // Disable attack box
        enemyAttack.SetActive(false);


        Debug.Log("Enemy start moving");
        moving = true;

        // attackCooldown
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
        
    }

}
