using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int amount = 50;
    [SerializeField] Sprite[] sprites;

    void Start()
    {
        var size = prefab.GetComponent<BoxCollider2D>().size;

        for (int i = 0; i < amount; ++i)
        {
            var obj = GameObject.Instantiate(prefab);
            var posX = Random.Range(ScreenUtils.ScreenLeft + size.x, ScreenUtils.ScreenRight - size.x);
            var posY = Random.Range(ScreenUtils.ScreenBottom + size.y, ScreenUtils.ScreenTop - size.y);
            var position = new Vector2(posX, posY);
            var sprite = sprites[Random.Range(0, sprites.Length)];
            var script = obj.GetComponent<Face>();
            script.Init(position, sprite);
        }
    }
}
