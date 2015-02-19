using UnityEngine;
using System.Collections;

public class TapTest : MonoBehaviour {

    public GameObject BodyPath;
    public GameObject BallPrefab;

    // 台調整用　タップした場所に玉を置く
    void OnTap(TapGesture gesture)
    {
        //var ball = NGUITools.AddChild(BodyPath, BallPrefab);
        //ball.transform.position = gesture.Position;

    }

}
