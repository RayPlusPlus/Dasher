using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Transform pies;
    public float rotationSpeed = -100;
    public float minMovementTime = 1;
    public float movementSpeed = 1;

    private float elapsedTime = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button.");
            elapsedTime = minMovementTime;
        }

        if (elapsedTime > 0)
        {
            Move();
            elapsedTime -= Time.deltaTime;
        }
        else
        {
            Rotate();
        }
    }


    void Move()
    {
        pies.gameObject.SetActive(false);
        transform.Translate(pies.up * Time.deltaTime * movementSpeed, Space.World);
    }

    void Rotate()
    {
        pies.gameObject.SetActive(true);
        pies.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}