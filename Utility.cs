using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class Utility
{
    public static Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public static Vector2 ClampVector(Vector2 value, Vector2 min, Vector2 max)
    {
        float x = Mathf.Clamp(value.x, min.x, max.x);
        float y = Mathf.Clamp(value.y, min.y, max.y);
        return new Vector2(x, y);
    }
    public static Vector3 ClampVector(Vector3 value, Vector2 min, Vector2 max)
    {
        float x = Mathf.Clamp(value.x, min.x, max.x);
        float y = Mathf.Clamp(value.y, min.y, max.y);
        return new Vector3(x, y, value.z);
    }
    public static async void SlowMotion(float scale, float duration)
    {
        float end = Time.time + duration * scale;
        Time.timeScale = scale;
        Time.fixedDeltaTime = 0.02F * scale;
        while (Time.time < end)
        {
            await Task.Yield();
        }
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F;
    }
}
