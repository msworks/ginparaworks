using UnityEngine;
using System.Collections;

public class Syokyu : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO 玉を増やす処理
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
        }
    }
}
