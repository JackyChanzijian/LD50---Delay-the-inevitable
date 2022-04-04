using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FakeShadow : MonoBehaviour
{
    [SerializeField] float height;
    [HideInInspector]

    GameObject shadow;
    SpriteRenderer shadowSR;
    SpriteRenderer sr;
    GameObject startPoint;
    Vector2 shadowOffset;

    Vector2 shadowScale = new Vector2(1.2f, .1f);
    Color shadowColor = new Color(0, 0, 0, .4f);

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        //Record start point
        startPoint = new GameObject("StartPoint");
        startPoint.transform.SetParent(transform);
        startPoint.transform.position = transform.position;

        CreateShadow();
    }
    void CreateShadow()
    {
        //Initialize
        shadow = new GameObject("Shadow");
        shadow.transform.SetParent(transform);
        shadowSR = shadow.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        //Shadow sprite setting
        shadowSR.sprite = sr.sprite;
        shadowSR.color = shadowColor;
        shadowSR.sortingLayerName = "Shadow";
        //Offset
        shadowOffset = new Vector2(0, -sr.sprite.bounds.size.y / 2);
        shadow.transform.localPosition = shadowOffset;
        //Stretch
        shadow.transform.localScale = shadowScale;
    }
    public bool IsGrounded => (height <= 0);

}