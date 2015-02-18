using UnityEngine;
using System.Collections;

public class Syokyu : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision:");
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
        }
    }
}
