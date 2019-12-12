using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    // State Machine for Enemy above using enum^^
    // Variables for enemy, Here im using the FloatValue created in ScriptObjects for Enemy Health Value for hits
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    // Start is called before the first frame update
    
    // Changed to Awake as Start was throwing Errors. This problem lasted longer than it should of.
    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    // Was going to copy and paste for Player/Warrior health but not the same and wouldnt make sense didnt have time
    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Time after first hit player can hit again and damage
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }
    
    // IEnumerator for KnockCo in Knock
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
