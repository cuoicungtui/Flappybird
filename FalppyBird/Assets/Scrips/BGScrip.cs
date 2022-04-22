using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Vector3 temp = transform.position;

        float height = sr.bounds.size.y;

        float width = sr.bounds.size.x;

        float WorldHeight = Camera.main.orthographicSize * 2f;

        float WorldWith = WorldHeight * Screen.width / Screen.height;

        temp.y = WorldHeight / height;

        temp.x = WorldWith / width;

        transform.localScale = temp;


    }


}
