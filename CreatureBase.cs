using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FakeShadow))]
public abstract class CreatureBase : MonoBehaviour
{
    protected float health = 1f;
    public virtual void TakeDamage(float value)
    {
        health -= value;
        if (health <= 0)
        {
            Killed();
        }
    }
    public virtual void TakeDamage()
    {
        TakeDamage(1f);
    }
    public abstract void Killed();

}
