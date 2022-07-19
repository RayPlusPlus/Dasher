using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Transform pies;
    public Transform ship;
    public GameObject attackCollider;
    public GameObject stillCollider;
    public GameObject buttCollider;
    public SpriteMask mask;
    public Collider2D playerWalls;
    public float rotationSpeed = -100;
    public float minMovementTime = 1;
    public float maxMovementTime = 2;
    public float movementSpeed = 1;

    private float elapsedTime = 0;
    private float normalizedHeld = 0;
    private float heldDownTime = 0;


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            heldDownTime += Time.deltaTime;
            normalizedHeld = Normalize(heldDownTime, maxMovementTime);
            mask.alphaCutoff = 1 - normalizedHeld;
            //elapsedTime = minMovementTime;
        }
        else
        {
            if (elapsedTime <= 0)
            {
                Rotate();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            elapsedTime = Mathf.Max(heldDownTime, minMovementTime);
            elapsedTime = Mathf.Min(maxMovementTime, elapsedTime);
            heldDownTime = 0;
            mask.alphaCutoff = 1;
        }

        if (elapsedTime > 0)
        {
            Move(elapsedTime);
            elapsedTime -= Time.deltaTime;
        }
        else
        {
            attackCollider.SetActive(false);
            buttCollider.SetActive(false);
            stillCollider.SetActive(true);
        }
    }

    float Normalize(float value, float maxValue)
    {
        return value / maxValue;
    }


    void Move(float speedMultiplier)
    {
        attackCollider.SetActive(true);
        buttCollider.SetActive(true);
        stillCollider.SetActive(false);
        //pies.gameObject.SetActive(false);
        float speed = movementSpeed * speedMultiplier;
        transform.Translate(pies.up * Time.deltaTime * speed, Space.World);
        Bounds bounds = playerWalls.bounds;
        Vector2 playerPosition = transform.position;

            if(playerPosition.x > bounds.max.x)
            {
                playerPosition.x = bounds.max.x;
            }
            else if(playerPosition.x < bounds.min.x)
            {
                playerPosition.x = bounds.min.x;
            }

            if(playerPosition.y > bounds.max.y)
            {
                playerPosition.y = bounds.max.y;
            }
            else if(playerPosition.y < bounds.min.y)
            {
                playerPosition.y = bounds.min.y;
            }
        
        transform.position = playerPosition;

    }

    void Rotate()
    {
        pies.gameObject.SetActive(true);
        pies.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        ship.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}