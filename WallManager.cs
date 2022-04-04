using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] GameObject wall;
    GameObject[] walls = new GameObject[4];

    private void Start()
    {
        Vector2[] positions =
        {
            new Vector2(0, WorldSize.y / 2),   //Up
            new Vector2(WorldSize.x / 2, 0),    //Right
            new Vector2(0,  -WorldSize.y / 2),  //Down
            new Vector2(-WorldSize.x / 2, 0),  //Left
        };
        float width = .4f;
        Vector2[] scales =
        {
            new Vector2(WorldSize.x, width),
            new Vector2(width, WorldSize.y),
            new Vector2(WorldSize.x, width),
            new Vector2(width, WorldSize.y),
        };
        for (int i = 0; i < 4; i++)
        {
            walls[i] = Instantiate(wall, positions[i], Quaternion.identity);
            walls[i].transform.localScale = scales[i];
        }
    }
    Vector2 WorldSize => Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) * 2;
}
