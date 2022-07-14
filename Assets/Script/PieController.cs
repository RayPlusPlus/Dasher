using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            Destroy(col.gameObject);
        }
    }
}
