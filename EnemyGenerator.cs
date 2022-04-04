using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject particle;
    float timePassed;

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 3)
        {
            timePassed = 0;
            StartCoroutine(GenerateEnemy());
        }
    }
    IEnumerator GenerateEnemy()
    {
        List<Vector2> availablePos = new List<Vector2>();
        for (int x = (int)-WorldSize.x / 2; x < WorldSize.x / 2; x++)
        {
            for (int y = (int)-WorldSize.y / 2; y < WorldSize.y / 2; y++)
            {
                Vector2 pos = new Vector2(x, y);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, 1);
                if (!Array.Exists(colliders, collider => (collider.GetComponent<WallBehave>() != null)))
                {
                    availablePos.Add(pos);
                }
            }
        }
        if (availablePos.Count != 0)
        {
            Vector2 randomPos = availablePos[Random.Range(0, availablePos.Count)];
            Instantiate(particle, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(2);
            Instantiate(enemies[Random.Range(0, enemies.Length)], randomPos, Quaternion.identity);
        }
    }
    Vector2 WorldSize => Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2;
}
