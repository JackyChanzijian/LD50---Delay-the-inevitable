using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    readonly float radius = 1f;
    readonly float moveSpeed = 8f;

    private void Update()
    {
        Vector2 screenCenter = new Vector2(Screen.width, Screen.height) / 2;
        Vector2 direction =  ((Vector2)Input.mousePosition - screenCenter).normalized;

        Vector3 endPosition = transform.position + (Vector3)direction * moveSpeed * Time.deltaTime;
        //  assign it if it's inside of radius (limitation)
        if (endPosition.x < radius && endPosition.x > -radius && endPosition.y < radius && endPosition.y > -radius)
        {
            transform.position = endPosition;
        }

    }
}
