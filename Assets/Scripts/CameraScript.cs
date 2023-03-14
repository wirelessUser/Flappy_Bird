using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static float offset;

   void MoveThecamera()
    {
        Vector3 temp = transform.position;
        temp.x = BirdScript.instance.GetPositionX() + offset;
        transform.position = temp;

    }

    // Update is called once per frame
    void Update()
    {
        if (BirdScript.instance!=null)
        {
            MoveThecamera();
        }
    }
}
