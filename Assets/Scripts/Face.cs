using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private const float FORCE_MULTIPLIER = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 position, Sprite sprite)
    {
        transform.position = position;
        spriteRenderer.sprite = sprite;
        rigidBody2D.AddForce(Random.insideUnitCircle * FORCE_MULTIPLIER, ForceMode2D.Impulse);
    }
}
