using UnityEngine;
using System.Collections;

public class Atacker : MonoBehaviour {

    public GameObject MainLogic;

    string msg = "権利獲得成功";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);

            // アタッカーに入った→権利獲得
            MainLogic.GetComponent<PlayMakerFSM>().SendEvent(msg);
        }
    }
}
