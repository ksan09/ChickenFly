using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Vector2 dir;
    [SerializeField] private float speed = 1f;

    public float Speed { 
        get { return speed; } 
        set { speed = value; }
    }
    private void Update()
    {
        MoveTo();
    }
    public void MoveTo()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

}
