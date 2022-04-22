using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHoder : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {
        if(Flying.instance!= null)
        {
            if(Flying.instance.flag == 1)
            {
                Destroy(GetComponent<PipeHoder>());
            }
        }

        pipeHoderMove();
    }

    void pipeHoderMove()
    {
        Vector3 temp = transform.position;

        temp.x -= speed * Time.deltaTime;

        transform.position = temp;

    }
}
