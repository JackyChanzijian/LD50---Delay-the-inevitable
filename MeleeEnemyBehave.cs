using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehave : EnemyBase
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float detectRadius = 5;
    Animator animator;
    bool didFound;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();
        if (Vector2.Distance(transform.position, target.position) < detectRadius)
        {
            animator.SetBool("didFound", true);
            if (!didFound)   // just founded
            {
                WarnFoundPlayer();
            }
            didFound = true;
        }
        if (didFound)
        {
            moveSpeed += Time.deltaTime;    // Movespeed increase gradually
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<PlayerBehave>() != null)
        {
            Destroy(gameObject);
        }
    }
    protected override void DropLoot()
    {
        
    }
}
