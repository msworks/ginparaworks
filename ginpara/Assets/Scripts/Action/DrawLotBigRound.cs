using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ginpara
{

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

    // DEBUG
    public FsmBool ForceNormalReach;

	public override void OnEnter()
	{
        var result = MainLogic.GetComponent<MainLogic>().DrawLot(
            HoryuSu.Value,
            KenriKaisu.Value,
            ForceNormalReach.Value
        );

        var reels = Reel.Choose();

        if (result.isOOatari)
        {
            // TODO 大当たり
        }
        else
        {
            // ハズレ
            if (result.reachPattern == -1){
                // バラケ目
                // エフェクトを通知
                if (HoryuSu.Value < 3)
                {
                    // 保留０、１、２のエフェクト
                    ReelController.GetComponent<ReelController>().EnqueueDirection("1", 1f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("2", 1f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("3", 8f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 2f);
                }
                else
                {
                    // 保留３，４のエフェクト
                    ReelController.GetComponent<ReelController>().EnqueueDirection("1", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("2", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("3", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 2f);
                }
            }
            else
            {
                // ハズレリーチ
                Debug.Log("特図：" + result.tokuzu);
                Debug.Log("特図：" + result.reachLineName);
                Debug.Log("リーチライン"+result.reachLine);
                Debug.Log("リーチパターン：" + result.reachPatternName);

                // リーチラインに特図を置く
                reels = Reel.Choose(result.reachLine, result.tokuzu);

                // テストでバラケ目エフェクトを発行
                // エフェクトを通知
                if (HoryuSu.Value < 3)
                {
                    // 保留０、１、２のエフェクト
                    ReelController.GetComponent<ReelController>().EnqueueDirection("1", 1f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("2", 1f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("3", 8f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 2f);
                }
                else
                {
                    // 保留３，４のエフェクト
                    ReelController.GetComponent<ReelController>().EnqueueDirection("1", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("2", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("3", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 2f);
                }
            }

        }

        IsOoatari.Value = result.isOOatari;
        ReachLine.Value = result.reachLine;
        ReachPattern.Value = result.reachPattern;

		Finish();
	}

}

}
