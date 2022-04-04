using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBehave : EnemyBase
{
    [SerializeField] float moveSpeed = .3f;
    [SerializeField] float detectRadius = 10;
    [SerializeField] GameObject arrow;
    LineRenderer lr;
    Animator animator;
    bool didFound;
    float timePassed;
    private void Start()
    {
        animator = GetComponent<Animator>();
        lr = transform.GetChild(0).GetComponent<LineRenderer>();
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
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            timePassed += Time.deltaTime;
            if (timePassed > 3)
            {
                timePassed = 0;
                Instantiate(arrow, transform.position, Quaternion.identity);
            }
        }
    }
    protected override void DropLoot()
    {

    }
}
