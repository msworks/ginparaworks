using UnityEngine;
using System.Collections;

// 回転体に玉が乗ったときの挙動
// ボールの状態を変化させる。自律的にやる。
// 
public class TouchKaitentai : MonoBehaviour {

    private string msg = "TouchKaitentai";

    public GameObject TurnBallPrefab;
    public GameObject BodyPath;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        var ball = NGUITools.AddChild(BodyPath, TurnBallPrefab);
        //ball.transform.position = ShootPosition.transform.position;
        //ball.rigidbody2D.velocity = ShootPower * rndp;

        this.gameObject.GetComponent<PlayMakerFSM>().SendEvent("玉通過");
    }

}
