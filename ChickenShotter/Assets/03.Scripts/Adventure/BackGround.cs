using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }
    private void Check()
    {
        Vector3 pos = transform.position;
        if(pos.x < -23.9)
        {
            pos.x = 23.9f;
        }
        transform.position = pos;
    }
}
