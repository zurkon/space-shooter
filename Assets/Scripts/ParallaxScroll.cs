using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector2 startPosition;
    public Vector2 borderPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movementThisFrame = moveSpeed * Time.deltaTime;

        Vector2 nextPosition = new Vector2(transform.position.x, transform.position.y + movementThisFrame);

        transform.position = nextPosition;

        if (transform.position.y <= borderPosition.y)
        {
            transform.position = startPosition;
        }
    }
}
