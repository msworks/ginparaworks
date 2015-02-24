using UnityEngine;
using System.Collections;

// チャッカー
public class Syokyu_Nyusyo0 : MonoBehaviour {

    public GameObject Horyu;

    const string msg = "チャッカー通過";

    void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO 玉を増やす処理
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
        }

        // 保留オブジェクトにチャッカー通過メッセージを送る
        Horyu.GetComponent<PlayMakerFSM>().SendEvent(msg);

    }

}
