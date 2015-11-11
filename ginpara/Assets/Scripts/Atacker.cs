using UnityEngine;

/// <summary>
/// アタッカー
/// </summary>
public class Atacker : MonoBehaviour
{
    public GameObject MainLogic;

    string msg = "権利獲得成功";

    /// <summary>
    /// アタッカーに入ったときに権利獲得メッセージを
    /// メインロジックに通知
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);

            // アタッカーに入った→権利獲得
            MainLogic.GetComponent<PlayMakerFSM>().SendEvent(msg);

            GetComponent<PlayMakerFSM>().SendEvent("入賞");
        }
    }
}
