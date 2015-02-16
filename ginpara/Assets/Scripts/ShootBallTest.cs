using UnityEngine;
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
        //var ball = (GameObject)Instantiate(
        //    BallPrefab,
        //    ShootPosition.transform.position,
        //    ShootPosition.transform.rotation );

        var ball = NGUITools.AddChild(BodyPath, BallPrefab);
        //ball.transform.position = new Vector3(-800, -300, 0);

        //Debug.Log(ball.transform.position.x);
        ball.transform.position = ShootPosition.transform.position;
        ball.rigidbody2D.velocity = ShootPower;
    }
}
