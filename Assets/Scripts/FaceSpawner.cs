using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    void Start()
    {
        var obj = GameObject.Instantiate(prefab);
        var size = obj.GetComponent<BoxCollider2D>().size;
        var posX = Random.Range(ScreenUtils.ScreenLeft + size.x, ScreenUtils.ScreenRight - size.x);
        var posY = Random.Range(ScreenUtils.ScreenBottom + size.y, ScreenUtils.ScreenTop - size.y);
        var position = new Vector2(posX, posY);
        var script = obj.GetComponent<Face>();
        script.Init(position);
    }
}
