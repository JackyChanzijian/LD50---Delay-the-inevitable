using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PlayerBehave : CreatureBase
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject damageParticle;
    [SerializeField] CanvasGroup endScreen;
    Rigidbody2D rb;

    [SerializeField] float invincibleDuration = 1;

    float timeSinceLastHit; // For invincible time 
    PlayerBehave()
    {
        health = 3;
    }
    private static PlayerBehave _instance;

    public static PlayerBehave Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider.maxValue = health;
    }
    private void Update()
    {
        slider.value = health;

        timeSinceLastHit += Time.deltaTime; 
    }
    public override void TakeDamage(float value)
    {
        if (timeSinceLastHit < invincibleDuration) return;   // Return if was hit 1 second ago
        base.TakeDamage(value);
        timeSinceLastHit = 0;
        Debug.Log("Player health -1");
    }

    public override void Killed()
    {
        Debug.Log("Player Die");
        endScreen.DOFade(1, 1);
    }
    public void Heal()
    {
        health += .4f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.TryGetComponent(out EnemyBase enemyBase))
        {
            if (collision.transform.GetComponent<ArcherBehave>() != null) return;
            Utility.SlowMotion(.3f, .3f);
            rb.AddForce((transform.position - collision.transform.position).normalized * 15, ForceMode2D.Impulse);
            Instantiate(damageParticle, transform.position, Quaternion.identity);
            TakeDamage();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ArrowBehave>() != null)
        {
            rb.AddForce((transform.position - collision.transform.position).normalized * 15, ForceMode2D.Impulse);
            Instantiate(damageParticle, transform.position, Quaternion.identity);
            TakeDamage();
        }
    }
}
