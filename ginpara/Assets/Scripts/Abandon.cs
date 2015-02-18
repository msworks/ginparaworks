using UnityEngine;
using System.Collections;

public class Abandon : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
