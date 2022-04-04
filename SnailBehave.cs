using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnailBehave : EnemyBase
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float detectRadius = 5;

    [SerializeField] Sprite move1, move2;

    float timePassed;
    bool didFound;

    protected override void Update()
    {
        base.Update();
        if (Vector2.Distance(transform.position, target.position) < detectRadius)
        {
            if (!didFound)   // just founded
            {
                WarnFoundPlayer();
            }
            didFound = true;
        }
        if (didFound)
        {
            timePassed += Time.deltaTime;
            if (timePassed > 1)
            {
                transform.DOMove(transform.position + (target.position - transform.position).normalized * moveSpeed, 1f);
                timePassed = 0;
            }
            if (timePassed > .5f)
                GetComponent<SpriteRenderer>().sprite = move2;
            else
                GetComponent<SpriteRenderer>().sprite = move1;


        }


    }
    protected override void DropLoot()
    {

    }

    protected override void Flip()
    {
        if (target.position.x > transform.position.x)
            transform.localScale = new Vector2(-1, 1);
        else
            transform.localScale = new Vector2(1, 1);
    }
}
