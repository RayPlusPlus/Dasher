using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStillCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject explosionParticle;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            Instantiate(explosionParticle, player.transform.position, Quaternion.identity);
            Destroy(player);
        }
    }
}
