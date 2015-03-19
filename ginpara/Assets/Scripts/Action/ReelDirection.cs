using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class ReelDirection : FsmStateAction
{
    public GameObject GinparaManager;   // 出力先
    public GameObject ReelController;   // 入力元
    public FsmFloat WaitTime;

	// Code that runs on entering the state.
	public override void OnEnter()
	{
        var data = (GPDirection)ReelController.GetComponent<ReelController>().Direction.Dequeue();

        //Debug.Log("指示ナンバー：" + data.sizi + " 待ち時間：" + data.time.ToString());

        GinparaManager.GetComponent<GinparaManager>().Order(data.sizi);

        // 待ち時間を取得
        WaitTime.Value = data.time;

        Finish();
	}

}

[ActionCategory("Ginpara")]
public class CheckReelDirection : FsmStateAction
{
    public GameObject ReelController;   // 入力元
    public FsmEvent ari;
    public FsmEvent nasi;

    // 演出データがあればありイベントを、なければなしイベントを発行
    public override void OnEnter()
    {
        var data = ReelController.GetComponent<ReelController>().Direction.Count;
        Fsm.Event(data != 0 ? ari : nasi);
    }

}
