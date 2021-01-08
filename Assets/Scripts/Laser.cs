using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Properties")]
    [Tooltip("Laser movement speed value.")]
    public float moveSpeed = 20f;

    // Called when the object becomes enabled and active.
    void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2( 0, moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Shredder")
        {
            gameObject.SetActive(false);
        }
    }
}
