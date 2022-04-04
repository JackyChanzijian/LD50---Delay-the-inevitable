using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehave : MonoBehaviour
{
    [SerializeField] float damagePerSecond;
    bool isPushing;
    Vector2 initialScale;
    
    [Range(0, 1)] [SerializeField] float expandChance;
    [SerializeField] float expandSpeed, shrinkSpeed;

    private void Start()
    {
        initialScale = transform.localScale;
    }
    private void Update()
    {
        if (Random.value < .03f)
            Expand();
        if (isPushing)
        {
            if (transform.localScale.x > initialScale.x)
                Shrink();
            PlayerBehave.Instance.TakeDamage(Time.deltaTime * damagePerSecond);
        }  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerBehave playerBehave))
        {
            isPushing = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerBehave playerBehave))
        {
            isPushing = false;
        }
    }
    void Expand()
    {
        transform.localScale *= 1 + Time.deltaTime * expandSpeed;
    }
    void Shrink()
    {
        transform.localScale *= 1 - Time.deltaTime;
    }
}
