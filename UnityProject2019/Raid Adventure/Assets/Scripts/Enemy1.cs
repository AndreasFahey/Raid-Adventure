using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    // Handy class as i applied to every enemy and just changed health for each
    // This class inherits the enemy class 
    // This class mainly deals with when an enemy is to move/follow player and when to stop
    // Unfortuantely didn't have time to have enemy attack damage Warrior as stated
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    // Start is called before the first frame update
    // Enemy is idle to start
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    // Distance for Enemy to Move towards player
    // Knockback dosent work when Warrior attacks but when enemy touches player knocks them back
    // Change Thrust in Knockback for Knockback distance
    void CheckDistance()
    {
        if (Vector3.Distance(target.position, 
                             transform.position) <= chaseRadius
            && Vector3.Distance(target.position,
                             transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
            && currentState != EnemyState.stagger)
            {

            Vector3 temp = Vector3.MoveTowards(transform.position, 
                                                     target.position, 
                                                     moveSpeed * Time.deltaTime);
            myRigidbody.MovePosition(temp);
            ChangeState(EnemyState.walk);

            }
        }
    }
    
    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
