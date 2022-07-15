using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Transform pies;
    public float rotationSpeed = -100;
    public float minMovementTime = 1;
    public float maxMovementTime = 2;
    public float movementSpeed = 1;

    private float elapsedTime = 0;
    private float heldDownTime = 0;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            heldDownTime += Time.deltaTime;
            //elapsedTime = minMovementTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            elapsedTime = Mathf.Max(heldDownTime, minMovementTime);
            elapsedTime = Mathf.Min(maxMovementTime, elapsedTime);
            heldDownTime = 0;
        }

        if (elapsedTime > 0)
        {
            Move(elapsedTime);
            elapsedTime -= Time.deltaTime;
        }
        else
        {
            Rotate();
        }
    }


    void Move(float speedMultiplier)
    {
        pies.gameObject.SetActive(false);
        float speed = movementSpeed * speedMultiplier;
        transform.Translate(pies.up * Time.deltaTime * speed, Space.World);
    }

    void Rotate()
    {
        pies.gameObject.SetActive(true);
        pies.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}