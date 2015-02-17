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

    // テスト用
    static Vector2 ShootPower = new Vector2(-7.5f, 7.5f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        var ball = NGUITools.AddChild(BodyPath, BallPrefab);
        ball.transform.position = ShootPosition.transform.position;
        ball.rigidbody2D.velocity = ShootPower;
    }

    public void ShootBall(float power)
    {
        if (power == 0) return;

        float rndp = UnityEngine.Random.Range(0.995f, 1.005f);

        var ball = NGUITools.AddChild(BodyPath, BallPrefab);
        ball.transform.position = ShootPosition.transform.position;
        ball.rigidbody2D.velocity = ShootPower * power * rndp;
    }
}
