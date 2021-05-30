using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;
    [SerializeField] ColorType color;
    [SerializeField] float colorChangingSpeed = 5f;
    [SerializeField] float movingSpeed = 3f;
    [SerializeField] string playerId;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        switch (color)
        {
            case ColorType.Green:
                spriteRenderer.color = Color.green;
                break;
            case ColorType.Red:
                spriteRenderer.color = Color.red;
                break;
            case ColorType.Blue:
                spriteRenderer.color = Color.blue;
                break;
        }

        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        var input = Input.GetAxis(playerId + "_Horizontal") * Vector3.right + Input.GetAxis(playerId + "_Vertical") * Vector3.up;
        var newPosition = transform.position + movingSpeed * Time.deltaTime * input;
        transform.position = newPosition;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var face = collision.gameObject.GetComponent<Face>();
        if (face == null || face.ColorType != ColorType.White)
        {
            return;
        }

        var spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

        if (circleCollider.bounds.Contains(collision.bounds.min) &&
            circleCollider.bounds.Contains(collision.bounds.max))
        {
            var rendererColor = spriteRenderer.color;
            Color newColor;
            switch (color)
            {
                case ColorType.Green:
                    newColor = new Color(rendererColor.r - colorChangingSpeed * Time.fixedDeltaTime, rendererColor.g, 
                        rendererColor.b - colorChangingSpeed * Time.fixedDeltaTime);
                    if (rendererColor.r < 0 && rendererColor.g >= 1f && rendererColor.b < 0)
                    {
                        face.ColorType = ColorType.Green;
                    }
                    break;
                case ColorType.Red:
                    newColor = new Color(rendererColor.r, rendererColor.g - colorChangingSpeed * Time.fixedDeltaTime,
                        rendererColor.b - colorChangingSpeed * Time.fixedDeltaTime);
                    if (rendererColor.r >= 1f && rendererColor.g < 0 && rendererColor.b < 0)
                    {
                        face.ColorType = ColorType.Red;
                    }
                    break;
                case ColorType.Blue:
                default:
                    newColor = new Color(rendererColor.r - colorChangingSpeed * Time.fixedDeltaTime, 
                        rendererColor.g - colorChangingSpeed * Time.fixedDeltaTime, rendererColor.b);
                    if (rendererColor.r < 0 && rendererColor.g < 0 && rendererColor.b >= 1f)
                    {
                        face.ColorType = ColorType.Blue;
                    }
                    break;
            }
            spriteRenderer.color = newColor;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var face = other.gameObject.GetComponent<Face>();
        if (face == null || face.ColorType != ColorType.White)
        {
            return;
        }

        var spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
    }
}
