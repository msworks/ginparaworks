using UnityEngine;
using System;
using System.Collections;

public class ShootBallTest : MonoBehaviour {

    // TODO 動的にボールを生成するとメモリに負荷をかける。
    // 先にボールを十分な数確保しておいて、
    // 回収→打ち出し　というループにできないか。
    public GameObject BallPrefab;
    public GameObject BodyPath;
    public GameObject ShootPosition;

    public GameObject Uchidashi;

    private float yureMin;
    private float yureMax;

    // テスト用
    Vector2 ShootPower = new Vector2(-7.5f, 7.5f);

	// 初期化
	void Start () {

	}

    // 玉を発射する
    public void ShootBall(float power)
    {
        var uchi = Uchidashi.GetComponent<ShootPowerEditor>();

        ShootPower = new Vector2(-uchi.Power, uchi.Power);

        yureMin = 1 - uchi.Yure;
        yureMax = 1 + uchi.Yure;

        if (power == 0) return;


        float rndp = UnityEngine.Random.Range(yureMin, yureMax);

        var ball = NGUITools.AddChild(BodyPath, BallPrefab);
        ball.transform.position = ShootPosition.transform.position;
        ball.rigidbody2D.velocity = ShootPower * power * rndp;
    }
}
