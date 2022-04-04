using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : CreatureBase
{
    protected Transform target;
    [SerializeField] GameObject exclamationMark;

    protected float dropRate = 1;

    protected virtual void Awake()
    {
        target = FindObjectOfType<PlayerBehave>().transform;
    }
    public override void Killed()
    {
        if (Random.value < dropRate)
        {
            DropLoot();
        }
        Destroy(gameObject);
    }
    protected virtual void Update()
    {
        Flip();
    }
    protected virtual void Flip()
    {
        if (target.position.x > transform.position.x)
            transform.localScale = new Vector2(1, 1);
        else
            transform.localScale = new Vector2(-1, 1);
    }
    protected void WarnFoundPlayer()
    {
        Instantiate(exclamationMark, transform);
    }
    protected abstract void DropLoot();
}
