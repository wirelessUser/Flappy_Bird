using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backgrounds;
    [SerializeField]
    private GameObject[] Grounds;

    private float lastBgX;
    private float lastGroundX;


    private void Awake()
    {
        
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        Grounds = GameObject.FindGameObjectsWithTag("Ground");

        lastBgX = backgrounds[0].transform.localPosition.x;
        lastGroundX = Grounds[0].transform.localPosition.x;
        SetBgAndGrounds();

    }


    void SetBgAndGrounds()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (lastBgX<backgrounds[i].transform.localPosition.x)
            {
                lastBgX = backgrounds[i].transform.localPosition.x;
            }
        }

        for (int i = 0; i < Grounds.Length; i++)
        {
            if (lastBgX < Grounds[i].transform.localPosition.x)
            {
                lastGroundX = Grounds[i].transform.localPosition.x;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Background")
        {
            Vector3 temp = collision.transform.localPosition;
            float width = ((BoxCollider2D)collision).size.x;

            temp.x = (lastBgX + width)-0.7405f;
            collision.transform.localPosition = temp;

            lastBgX = temp.x;
        }
        else if(collision.gameObject.tag == "Ground")
        {
            Vector3 temp = collision.transform.localPosition;

           float width= ((BoxCollider2D)collision).size.x;

            temp.x = (lastGroundX + width)-0.7405f;
            collision.transform.localPosition = temp;

            lastGroundX = temp.x;
        }
    }
}
