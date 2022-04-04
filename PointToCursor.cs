using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToCursor : MonoBehaviour
{
    private void Update()
    {
        transform.up = (Vector2)(Utility.GetMousePosition() - transform.position);
    }
}
