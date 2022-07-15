using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
        }
    }
}
