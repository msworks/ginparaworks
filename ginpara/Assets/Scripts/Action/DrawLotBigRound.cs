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
    public FsmBool ForceSPReach;

	public override void OnEnter()
	{
        var result = MainLogic.GetComponent<MainLogic>().DrawLot(
            HoryuSu.Value,
            KenriKaisu.Value,
            ForceNormalReach.Value,
            ForceSPReach.Value
        );

        var reels = Reel.Choose();

        // 演出完了コールバック
        Action callback = () =>
        {
            Debug.Log("CALLBACK");
            ReelController.GetComponent<ReelController>().EndEvent();
        };

        if (result.isOOatari)
        {
            // TODO 大当たり実装
            Debug.Log("*** 大当たり ***");
            ReelController.GetComponent<ReelController>().EnqueueDirection("1", 1f);
            ReelController.GetComponent<ReelController>().EnqueueDirection("2", 1f);
            ReelController.GetComponent<ReelController>().EnqueueDirection("3", 8f);
            ReelController.GetComponent<ReelController>().EnqueueDirection("4-1", 0.5f);
            ReelController.GetComponent<ReelController>().EnqueueDirection("5-1", 0.5f);
            ReelController.GetComponent<ReelController>().EnqueueDirection("6-1", 0.5f, callback);
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
                /*
                Debug.Log("特図：" + result.tokuzu);
                Debug.Log("特図：" + result.reachLineName);
                Debug.Log("リーチライン"+result.reachLine);
                Debug.Log("リーチパターン：" + result.reachPatternName);
                 */

                // リールの止まる位置を取得
                if (result.reachPatternName.Contains("SP"))
                {
                    reels = Reel.ChooseSP(result.reachLine, result.tokuzu, result.reachPatternName);
                }
                else
                {
                    reels = Reel.Choose(result.reachLine, result.tokuzu);
                }

                var pattern = GetReachPatternList(result.reachPatternName, result.reachLine);

                var ExitPtn = GetReachPatternExitList(result.reachPatternName, result.reachLine);

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
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, ()=>{
                        Debug.Log("CALLBACK 012");
                        ExitPtn.ForEach(ptn =>
                        {
                            ReelController.GetComponent<ReelController>().EnqueueDirection(ptn, 0f);
                        });
                        ReelController.GetComponent<ReelController>().EndEvent();
                    });
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
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, () =>
                    {
                        Debug.Log("CALLBACK 34");
                        ExitPtn.ForEach(ptn =>
                        {
                            ReelController.GetComponent<ReelController>().EnqueueDirection(ptn, 0f);
                        });
                        ReelController.GetComponent<ReelController>().EndEvent();
                    });
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

    struct RPRL2Direction
    {
        public int ReachLine;
        public String Label;
        public String Sizi;
    };

    static List<RP2Direction> RPDList = new List<RP2Direction>(){
        new RP2Direction{ Label="ノーマル", Sizi="101" },
        new RP2Direction{ Label="泡", Sizi="104" },
        new RP2Direction{ Label="魚群", Sizi="105" },
        new RP2Direction{ Label="SP1", Sizi="102" },
        new RP2Direction{ Label="SP3", Sizi="107-2" },  
    };

    static List<RP2Direction> RPDExitList = new List<RP2Direction>(){
        new RP2Direction{ Label="ノーマル", Sizi="101" },
        new RP2Direction{ Label="泡", Sizi="101" },
        new RP2Direction{ Label="魚群", Sizi="101" },
        new RP2Direction{ Label="SP1", Sizi="101" },
        new RP2Direction{ Label="SP3", Sizi="107-1" },  
    };

    static List<RPRL2Direction> RPRLDList = new List<RPRL2Direction>(){
        new RPRL2Direction{ ReachLine=1, Label="SP2", Sizi="106-1" },  
        new RPRL2Direction{ ReachLine=2, Label="SP2", Sizi="106-3" },  
        new RPRL2Direction{ ReachLine=3, Label="SP2", Sizi="106-5" },  
        new RPRL2Direction{ ReachLine=4, Label="SP2", Sizi="106-3" },  
    };

    static List<RPRL2Direction> RPRLDExitList = new List<RPRL2Direction>(){
        new RPRL2Direction{ ReachLine=1, Label="SP2", Sizi="106-2" },  
        new RPRL2Direction{ ReachLine=2, Label="SP2", Sizi="106-4" },  
        new RPRL2Direction{ ReachLine=3, Label="SP2", Sizi="106-6" },  
        new RPRL2Direction{ ReachLine=4, Label="SP2", Sizi="106-4" },  
    };

    /// <summary>
    /// リーチパターン名から演出動作パターンのリストを取得
    /// </summary>
    /// <param name="ReachPattern"></param>
    /// <returns></returns>
    static public List<String> GetReachPatternList(
        String ReachPattern,
        int ReachLine
    ){

        List<String> SiziList = new List<String>();

        // 泡、ノーマル、魚群、SP1, SP2, SP3 が載っているか調査
        RPDExitList.ForEach(RPD =>
        {
            if (ReachPattern.Contains(RPD.Label))
            {
                SiziList.Add(RPD.Sizi);
            }
        });

        // さんご礁
        RPRLDList.ForEach(RPRLD =>
        {
            if (ReachLine==RPRLD.ReachLine&&ReachPattern.Contains(RPRLD.Label))
            {
                SiziList.Add(RPRLD.Sizi);
            }
        });

        return SiziList;
    }

    /// <summary>
    /// リーチパターン名から演出動作終了パターンのリストを取得
    /// </summary>
    /// <param name="ReachPattern"></param>
    /// <returns></returns>
    static public List<String> GetReachPatternExitList(
        String ReachPattern,
        int ReachLine
    ){

        List<String> SiziList = new List<String>();

        // 泡、ノーマル、魚群、SP1, SP2, SP3 が載っているか調査
        RPDExitList.ForEach(RPD =>
        {
            if (ReachPattern.Contains(RPD.Label))
            {
                SiziList.Add(RPD.Sizi);
            }
        });

        // さんご礁
        RPRLDExitList.ForEach(RPRLD =>
        {
            if (ReachLine==RPRLD.ReachLine&&ReachPattern.Contains(RPRLD.Label))
            {
                SiziList.Add(RPRLD.Sizi);
            }
        });

        return SiziList;
    }
}

}
