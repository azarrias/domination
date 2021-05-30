using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;
    [SerializeField] ColorType color;
    [SerializeField] float colorChangingSpeed = 5f;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Face>().ColorType != ColorType.White)
        {
            return;
        }

        if (circleCollider.bounds.Contains(collision.bounds.min) &&
            circleCollider.bounds.Contains(collision.bounds.max))
        {
            var spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            var rendererColor = spriteRenderer.color;
            Color newColor;
            switch (color)
            {
                case ColorType.Green:
                    newColor = new Color(rendererColor.r - colorChangingSpeed * Time.fixedDeltaTime, rendererColor.g, 
                        rendererColor.b - colorChangingSpeed * Time.fixedDeltaTime);
                    if (rendererColor.r < 0)
                    {
                        var face = collision.gameObject.GetComponent<Face>();
                        face.ColorType = ColorType.Green;
                    }
                    break;
                case ColorType.Red:
                    newColor = new Color(rendererColor.r, rendererColor.g - colorChangingSpeed * Time.fixedDeltaTime,
                        rendererColor.b - colorChangingSpeed * Time.fixedDeltaTime);
                    if (rendererColor.g < 0)
                    {
                        var face = collision.gameObject.GetComponent<Face>();
                        face.ColorType = ColorType.Green;
                    }
                    break;
                case ColorType.Blue:
                default:
                    newColor = new Color(rendererColor.r - colorChangingSpeed * Time.fixedDeltaTime, 
                        rendererColor.g - colorChangingSpeed * Time.fixedDeltaTime, rendererColor.b);
                    if (rendererColor.r < 0)
                    {
                        var face = collision.gameObject.GetComponent<Face>();
                        face.ColorType = ColorType.Green;
                    }
                    break;
            }
            spriteRenderer.color = newColor;
        }
    }
}
