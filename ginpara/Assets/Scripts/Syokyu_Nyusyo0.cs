﻿using UnityEngine;
using System.Collections;

// チャッカー
public class Syokyu_Nyusyo0 : MonoBehaviour {

    public GameObject Horyu;
    public GameObject ChackerOut;
    public GameObject BallPrefab;
    public GameObject BodyPath;

    const string msg = "チャッカー通過";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
        }

        // 保留オブジェクトにチャッカー通過メッセージを送る
        Horyu.GetComponent<PlayMakerFSM>().SendEvent(msg);

        // チャッカー出口に玉を出す(TODO 遅れて出す 遅れなくてもそんなに不自然には見えない)
        var ball = NGUITools.AddChild(BodyPath, BallPrefab);
        ball.transform.position = ChackerOut.transform.position;

    }

}
