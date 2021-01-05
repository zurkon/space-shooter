using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 10f;
    [Tooltip("Padding for Player object's half don't go outside of MainCamera.")]
    public Vector2 padding = new Vector2( 0.3f, 1f );

    [Header("Player Stats")]
    public GameObject laserPrefab;
    public float fireRate = 0.1f;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    IEnumerator FireAtWill()
    {
        while (true)
        {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireAtWill());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private void Move()
    {
        float deltaX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float deltaY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        // Clamp Player movement to prevent him to go outside scene camera view
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetupMoveBoundaries()
    {
        // Get the Scene's mainCamera object
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding.x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding.x;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding.y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding.y;
    }
}
