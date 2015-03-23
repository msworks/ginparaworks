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

        // 演出完了コールバック
        Action callback = () =>
        {
            ReelController.GetComponent<ReelController>().EndEvent();
        };

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
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, callback);
                }
                else
                {
                    // 保留３，４のエフェクト
                    ReelController.GetComponent<ReelController>().EnqueueDirection("1", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("2", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("3", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, callback);
                }
                // ここまでバラケ目
            }
            else
            {
                // ハズレリーチ
                Debug.Log("特図：" + result.tokuzu);
                Debug.Log("特図：" + result.reachLineName);
                Debug.Log("リーチライン"+result.reachLine);
                Debug.Log("リーチパターン：" + result.reachPatternName);

                // リールの止まる位置を取得
                reels = Reel.Choose(result.reachLine, result.tokuzu);

                var pattern = GetReachPatternList(result.reachPatternName);

                // エフェクトを通知
                if (HoryuSu.Value < 3)
                {
                    // 保留０、１、２のエフェクト
                    ReelController.GetComponent<ReelController>().EnqueueDirection("1", 1f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("2", 1f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("3", 8f);
                    pattern.ForEach(ptn =>
                    {
                        ReelController.GetComponent<ReelController>().EnqueueDirection(ptn, 0f);
                    });
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, callback);
                }
                else
                {
                    // 保留３，４のエフェクト
                    ReelController.GetComponent<ReelController>().EnqueueDirection("1", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("2", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("3", 0f);
                    pattern.ForEach(ptn =>
                    {
                        ReelController.GetComponent<ReelController>().EnqueueDirection(ptn, 0f);
                    }); 
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, callback);
                }
            }

        }

        IsOoatari.Value = result.isOOatari;
        ReachLine.Value = result.reachLine;
        ReachPattern.Value = result.reachPattern;

		Finish();
	}

    struct RP2Direction
    {
        public String Label;
        public String Sizi;
    };

    static List<RP2Direction> RPDList = new List<RP2Direction>(){
        new RP2Direction{ Label="ノーマル", Sizi="101" },
        new RP2Direction{ Label="泡", Sizi="104" },
        new RP2Direction{ Label="魚群", Sizi="105" },
        //new RP2Direction{ Label="SP1", Sizi="101" },
        //new RP2Direction{ Label="SP2", Sizi="101" },  
        //new RP2Direction{ Label="SP3", Sizi="101" },  
    };

    /// <summary>
    /// リーチパターン名から演出動作パターンのリストを取得
    /// </summary>
    /// <param name="ReachPattern"></param>
    /// <returns></returns>
    static public List<String> GetReachPatternList(String ReachPattern){

        List<String> SiziList = new List<String>();

        // 泡、ノーマル、魚群、SP1, SP2, SP3 が載っているか調査
        RPDList.ForEach(RPD =>
        {
            if (ReachPattern.Contains(RPD.Label))
            {
                SiziList.Add(RPD.Sizi);
            }
        });


        return SiziList;
    }
}

}
