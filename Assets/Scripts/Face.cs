using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private CircleCollider2D circleCollider;
    private const float FORCE_MULTIPLIER = 5f;
    public ColorType ColorType = ColorType.White;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public void Init(Vector2 position, Sprite sprite)
    {
        transform.position = position;
        spriteRenderer.sprite = sprite;
        rigidBody2D.AddForce(Random.insideUnitCircle * FORCE_MULTIPLIER, ForceMode2D.Impulse);
        gameObject.transform.eulerAngles = Vector3.forward * Random.Range(0, 360);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherFace = collision.gameObject.GetComponent<Face>();
        if (otherFace == null || otherFace.ColorType != ColorType.White)
        {
            return;
        }

        SpriteRenderer renderer;

        if (ColorType == ColorType.White && otherFace.ColorType != ColorType.White)
        {
            renderer = spriteRenderer;
            ColorType = otherFace.ColorType;
        }
        else if (ColorType != ColorType.White && otherFace.ColorType == ColorType.White)
        {
            renderer = otherFace.GetComponent<SpriteRenderer>();
            otherFace.ColorType = ColorType;
        }
        else 
        { 
            return; 
        }

        switch (ColorType)
        {
            case ColorType.Green:
                renderer.color = Color.green;
                break;
            case ColorType.Red:
                renderer.color = Color.red;
                break;
            case ColorType.Blue:
                renderer.color = Color.blue;
                break;
        }
    }
}
