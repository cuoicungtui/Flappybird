using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Flying : MonoBehaviour
{
    public Text text;

    public Text Score;

    private float dem ;

    public static Flying instance;

    public float BounceForce;

    public GameObject gameOver;

    private Rigidbody2D Rb;

    private Animator Anim;

    private bool isAlive;

    private bool didFlap;

    public float flag =0;

    private GameObject spawner;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip,PingClip, DeadClip;

    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;

        dem = 0;

        Rb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();

        MakeInstance();

        spawner = GameObject.Find("Spawner pipe");

        gameOver.SetActive(false);


    }

    void MakeInstance()
    {

        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BirdMovie();
    }

    void BirdMovie()
    {
        if (isAlive)
        {
            if (didFlap)
            {
                didFlap = false;
                Rb.velocity = new Vector2(Rb.velocity.x, BounceForce);
                Rb.AddForce(Vector2.up * BounceForce);
                audioSource.PlayOneShot(flyClip);

            }
        }




        //if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) )//
        //{
        //   Rb.velocity =  new Vector2(Rb.velocity.x, BounceForce);
        //    // Rb.AddForce(Vector2.up * BounceForce);
        //    audioSource.PlayOneShot(flyClip);
        //}

        if(Rb.velocity.y > 0)
        {

            float angel = 0;

            angel = Mathf.Lerp(0, 90, Rb.velocity.y/7);

            transform.rotation = Quaternion.Euler(0, 0, angel);

        }
        else if(Rb.velocity.y == 0)
        {


            transform.rotation = Quaternion.Euler(0, 0, 0);

        }else if(Rb.velocity.y <0)
            {

            float angel = 0;

            angel = Mathf.Lerp(0, -90, -Rb.velocity.y / 7);

            transform.rotation = Quaternion.Euler(0, 0, angel);

        }


    }


    public void flapButton()
    {
        didFlap = true;
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "PipeHoder")
        {

            audioSource.PlayOneShot(PingClip);

            dem++;

            text.text = "Score : " + dem;

        }


    }


    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "pipe" || target.gameObject.tag == "Groud")
        {
            flag = 1;

            if (isAlive)
            {
                isAlive = false; 

                audioSource.PlayOneShot(DeadClip);

                Anim.SetTrigger("Died");
            
                Destroy(spawner);

                gameOver.SetActive(true);

                Score.text =""+ dem;

                Time.timeScale =0;

             

            }

            

           
        }
    }

    public void gameNewButton()
    {
       
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
