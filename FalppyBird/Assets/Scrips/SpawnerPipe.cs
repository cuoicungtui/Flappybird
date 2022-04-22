using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHoder;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());

    }


    // thực hiện sau bao nhiêu thời gian IEnumerator
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1.3f);


        float y = Random.Range(-1.48f, 2.54f);

        Vector3 temp = transform.position;

        temp.y =y;

        GameObject k =  Instantiate(pipeHoder, temp, Quaternion.identity);

        Destroy(k, 3f);

        

        StartCoroutine(Spawner());

    }
}
