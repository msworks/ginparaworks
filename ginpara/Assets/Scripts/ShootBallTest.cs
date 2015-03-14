using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// テストという名前をつけてしまっているが本番
/// </summary>
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
        // パワー０なら打たない
        if (power == 0) return;

        var uchi = Uchidashi.GetComponent<ShootPowerEditor>();

        // パワーを変換
        power = uchi.Power_MIN + power * (uchi.Power_MAX-uchi.Power_MIN);

        ShootPower = new Vector2(-power, power);

        yureMin = 1 - uchi.Yure;
        yureMax = 1 + uchi.Yure;



        float rndp = UnityEngine.Random.Range(yureMin, yureMax);

        var ball = NGUITools.AddChild(BodyPath, BallPrefab);
        ball.transform.position = ShootPosition.transform.position;
        ball.rigidbody2D.velocity = ShootPower * rndp;
    }
}
