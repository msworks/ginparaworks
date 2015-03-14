using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 大当たり抽選を行う
/// </summary>
[ActionCategory("Ginpara")]
public class DrawLotBigRound : FsmStateAction
{
    public GameObject MainLogic;
    public FsmInt     HoryuSu;
    public FsmInt     KenriKaisu;

    public FsmBool IsOoatari;
    public FsmInt ReachLine;
    public FsmInt ReachPattern;

    public GameObject ReelController;

	public override void OnEnter()
	{
        var result = MainLogic.GetComponent<MainLogic>().DrawLot(
            HoryuSu.Value,
            KenriKaisu.Value
        );

        // TODO とりあえずバラケ目固定
        var reels = Reel.Choose();

        // エフェクトを通知
        ReelController.GetComponent<ReelController>().EnqueueDirection("1", 0.5f);
        ReelController.GetComponent<ReelController>().EnqueueDirection("2", 0.5f);
        ReelController.GetComponent<ReelController>().EnqueueDirection("3", 8f);
        ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
        ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
        ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 1f);

        IsOoatari.Value = result.isOOatari;
        ReachLine.Value = result.reachLine;
        ReachPattern.Value = result.reachPattern;

		Finish();
	}


}
