using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2( 0, moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
