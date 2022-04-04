using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BetBehave : MonoBehaviour
{
    [SerializeField] TrailRenderer tr;
    [SerializeField] GameObject attackParticle;

    int direction = 1;
    public bool isAttacking;
    float timeSinceLastAttack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(Attack());
        }
        if (!isAttacking)   // Follow cursor when is not attacking
        {
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, GetAngle());
        }

        if (isAttacking)
        {
            timeSinceLastAttack += Time.deltaTime;
            if (timeSinceLastAttack > 1)
            {
                timeSinceLastAttack = 0;
                tr.emitting = false;
                isAttacking = false;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isAttacking) return;
        if (collision.TryGetComponent(out EnemyBase enemyBase))
        {
            enemyBase.TakeDamage();
            Instantiate(attackParticle, transform.position, Quaternion.identity);
            Utility.SlowMotion(.3f, .3f);
            transform.parent.GetComponent<PlayerBehave>().Heal();
        }
    }

    IEnumerator Attack()
    {
        tr.emitting = true;
        isAttacking = true;
        direction *= -1;
        timeSinceLastAttack = 0;
        // Animation
        DOTween.KillAll();
        transform.DORotate(Vector3.forward * 360 * direction, .2f, RotateMode.FastBeyond360)
            .SetRelative(true)
            .SetEase(Ease.InBack);
        yield return null;
    }
    //float GetAngle()
    //{
    //    Vector2 distance = (Vector2)Utility.GetMousePosition() - (Vector2)PlayerBehave.Instance.transform.position;
    //    float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg - 90;
    //    return angle;
    //}
}
