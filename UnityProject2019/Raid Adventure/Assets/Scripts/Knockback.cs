﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    // Variables. Knockback only works when player walks into enemy or enemy walks into warrior
    // Used this class to do warrior attack
    public float thrust;
    public float knockTime;
    public float damage;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.gameObject.CompareTag("attack"))
        //{

        //}
        if(other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if(other.gameObject.CompareTag("enemy") && other.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if(other.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<WarriorMovement>().currentState = PlayerState.stagger;
                    other.GetComponent<WarriorMovement>().Knock(hit, knockTime);
                }
                
                // StartCoroutine(KnockCo(hit));
                // Show Enemy is being hit
                // Debug.Log("coroutine");
            }
        }
    }
    // Commented out code i dont want to use but didnt want to get rid off it
    /*private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    }*/
}
