using UnityEngine;
using System.Collections;

public class Abandon : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit Object");

        Destroy(collision.gameObject);
    }
}
