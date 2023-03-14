using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour
{
    private GameObject[] pipeHolder;

    private float lastpipeX;
    private float distance = 2.5f;
    private float pipeMin = -1.5f;
    private float pipeMax = 2.4f;
    void Awake()
    {
        pipeHolder = GameObject.FindGameObjectsWithTag("Pipe");

        for (int i = 0; i < pipeHolder.Length; i++)
        {
            Vector3 temp = pipeHolder[i].transform.position;
           temp.y = Random.Range(pipeMin,pipeMax);
            pipeHolder[i].transform.position = temp;
        }

        lastpipeX= pipeHolder[0].transform.position.x;
        for (int i = 0; i < pipeHolder.Length; i++)
        {
            if (lastpipeX< pipeHolder[i].transform.position.x)
            {
                lastpipeX = pipeHolder[i].transform.position.x;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Pipe")
        {
            Vector3 temp = collision.transform.position;
            temp.x = lastpipeX+ distance;
            temp.y = Random.Range(pipeMin,pipeMax);
            collision.transform.position = temp;

            lastpipeX = temp.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
