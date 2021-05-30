using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdgeCollider : MonoBehaviour
{
    [SerializeField] PhysicsMaterial2D physicsMaterial;

    void Awake()
    {
        var camera = Camera.main;

        if (camera == null)
        {
            Debug.LogError("Main camera not found");
        }

        var bottomLeft = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenBottom);
        var topLeft = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenTop);
        var topRight = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenTop);
        var bottomRight = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenBottom);

        var edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        edgeCollider.points = new[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };

        if (physicsMaterial != null)
        {
            edgeCollider.sharedMaterial = physicsMaterial;
        }
    }
}
