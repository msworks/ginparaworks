using UnityEngine;
using TheOcean;

/// <summary>
/// 賞球クラス
/// </summary>
public class Syokyu : MonoBehaviour
{
    public GameObject Kenri;
    public GameObject Uchidashi;
    public int Syokyusu;

    [SerializeField]
    Route route;

    public static int Syokyu15Count = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Ball")
        //{
        //    var ball = collision.gameObject.GetComponent<Ball>();

        //    ball.DeleteBall(route);

        //    Uchidashi.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmInt("tama").Value += Syokyusu;

        //    // 払い出し音
        //    AudioManager.Instance.PlaySE(19);

        //    if (Syokyusu == 15)
        //    {
        //        Syokyu15Count++;
        //        if (Syokyu15Count == 10)
        //        {
        //            // ラウンド終了メッセージを送信
        //            Kenri.GetComponent<PlayMakerFSM>().SendEvent("ラウンド終了");
        //        }
        //    }
        //}
    }
}
