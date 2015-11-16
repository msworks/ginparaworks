using UnityEngine;

// チャッカー
public class Syokyu_Nyusyo0 : MonoBehaviour
{
    public GameObject Horyu;
    public GameObject ChackerOut;
    public GameObject BallPrefab;
    public GameObject BodyPath;

    const string msg = "チャッカー通過";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Ball")
        {
            return;
        }

        // 保留オブジェクトにチャッカー通過メッセージを送る
        Horyu.GetComponent<PlayMakerFSM>().SendEvent(msg);

        // チャッカー出口に玉を出す
        var ball = collision.gameObject;
        ball.transform.position = ChackerOut.transform.position;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
