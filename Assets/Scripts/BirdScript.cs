using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public static BirdScript instance;

    [SerializeField]
    private Rigidbody2D myBody;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float forwardSpeed = 3f;

    private float bounceSpeed = 4f;

    private bool didFlap;
    public bool isAlive;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flapClip, pointClip, diedClip;

    [SerializeField]
    private Button jumpButton;
    public int score;
    void Start() 
    {

        jumpButton = GameObject.Find("Button").GetComponent<Button>();

        jumpButton.onClick.AddListener(() => FlapTheBird());
        score =0;
        SetCameraX();

        if (instance==null)
        {
            instance = this;
        }

        isAlive = true;
       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 temp = transform.position;

            temp.x += forwardSpeed * Time.deltaTime;
            //myBody.velocity = new Vector3(temp.x, 0);
            transform.position = temp;
            audioSource.PlayOneShot(flapClip);
        }


        if (didFlap)
        {
            didFlap = false;
            myBody.velocity = new Vector3(0, bounceSpeed);
            anim.SetTrigger("Flap");
        }
    }



    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag=="Pipe")
        {
            score++;
            audioSource.PlayOneShot(pointClip);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {

            if (isAlive)
            {
                isAlive = false;
                anim.SetTrigger("BirdDead");
                audioSource.PlayOneShot(diedClip);
            }

        }
    }
    void SetCameraX()
    {
        CameraScript.offset = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }
    public float GetPositionX()
    {
        return transform.position.x;
    }

    public void FlapTheBird()
    {
        didFlap = true;
    }
}
