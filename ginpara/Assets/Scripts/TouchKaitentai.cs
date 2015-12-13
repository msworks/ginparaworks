using UnityEngine;

/// <summary>
/// 回転体の中に玉が入ったときに、玉通過メッセージを発行
/// </summary>
public class TouchKaitentai : MonoBehaviour
{
    public GameObject TurnBallPrefab;
    public GameObject BodyPath;

    void OnTriggerEnter2D(Collider2D collision)
    {
        ////Destroy(collision.gameObject);
        //var ball = collision.gameObject.GetComponent<Ball>();
        //ball.DeleteBall(TheOcean.Route.Kaitenti);

        //this.gameObject.GetComponent<PlayMakerFSM>().SendEvent("玉通過");
    }
}
