using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStillCollision : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            Destroy(player);
        }
    }
}
