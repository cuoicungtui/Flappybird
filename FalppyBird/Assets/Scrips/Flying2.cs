using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying2 : MonoBehaviour
{

    public float speed;

    private Rigidbody2D Rg;

    // Start is called before the first frame update
    private void Start()
    {
        Rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {

            Rg.AddForce(Vector2.up * speed);

        }

       
    }
}
