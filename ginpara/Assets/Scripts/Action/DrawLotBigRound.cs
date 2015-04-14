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
    public FsmInt HoryuSu;
    public FsmInt KenriKaisu;

    public FsmBool IsOoatari;
    public FsmInt ReachLine;
    public FsmInt ReachPattern;

    public GameObject ReelController;
    public GameObject DirectionController;
    public GameObject Atacker;
    public GameObject MarinController;

    // DEBUG
    public FsmBool ForceNormalReach;
    public FsmBool ForceSPReach;
    public FsmBool ForceOoatari;
    public FsmBool ForceSP3;
    public FsmBool ForceSaishidou;

    string Ooatari = "大当たり";

    struct Sizi
    {
        public string EnsyutuNo;
        public float waitTime;
    }

    List<Sizi> H012Start = new List<Sizi>()
    {
        new Sizi{ EnsyutuNo="1", waitTime=1f },
        new Sizi{ EnsyutuNo="2", waitTime=1f },
        new Sizi{ EnsyutuNo="3", waitTime=8f },
    };

    List<Sizi> H34Start = new List<Sizi>()
    {
        new Sizi{ EnsyutuNo="1", waitTime=0f },
        new Sizi{ EnsyutuNo="2", waitTime=0f },
        new Sizi{ EnsyutuNo="3", waitTime=0f },
    };

	public override void OnEnter()
	{
        int atariZugara = -1;

        var result = MainLogic.Instance.DrawLot(
            HoryuSu.Value,
            KenriKaisu.Value,
            ForceNormalReach.Value,
            ForceSPReach.Value,
            ForceOoatari.Value,
            ForceSP3.Value,
            ForceSaishidou.Value
        );

        // 演出完了コールバック
        Action callback = () =>
        {
            ReelController.GetComponent<ReelController>().EndEvent();
        };

        // 演出完了コールバック（何も通知しない）
        Action NoReaction = () => { };

        List<Sizi> StartList;
        if (HoryuSu.Value < 3)
        {
            StartList = H012Start;
        }
        else
        {
            StartList = H34Start;
        }

        // スタート演出
        StartList.ForEach(s =>
        {
            DirectionController.GetComponent<ReelController>().EnqueueDirection(s.EnsyutuNo, s.waitTime);
        });

        // 停止演出
        if (result.reachPattern == -1){
            // バラケ目
            var reels = Reel.ChooseBarakeme();
            DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
            DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
            DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, callback);
        }
        else
        {
            // SP3演出ならマリンコントローラーに通知
            if( result.reachPatternName.Contains("SP3")){
                if (HoryuSu.Value < 3)
                {
                    MarinController.GetComponent<PlayMakerFSM>().SendEvent("HazureH012");
                }
                else
                {
                    MarinController.GetComponent<PlayMakerFSM>().SendEvent("HazureH34");
                }
            }

            // リールの止まる位置を取得
            ReelElement[] reels;
            if (result.isOOatari)
            {

                reels = Reel.ChooseOoatari(result, out atariZugara);
            }
            else if (result.reachPatternName.Contains("SP"))
            {
                reels = Reel.ChooseSP(result.reachLine, result.tokuzu, result.reachPatternName);
            }
            else
            {
                reels = Reel.Choose(result.reachLine, result.tokuzu);
            }

            var pattern = GetReachPatternList(result.reachPatternName, result.reachLine);
            var ExitPtn = GetReachPatternExitList(result.reachPatternName, result.reachLine);

            // 保留３，４のエフェクト
            pattern.ForEach(ptn =>
            {
                DirectionController.GetComponent<ReelController>().EnqueueDirection(ptn, 0f);
            }); 
            DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
            DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
            DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, () =>
            {
                if(result.isOOatari){
                    // さんご下げる
                    SangoExit(result.reachPatternName, result.reachLine).ForEach(ptn =>
                    {
                        DirectionController.GetComponent<ReelController>().EnqueueDirection(ptn, 0f);
                    });
                    MarinController.GetComponent<PlayMakerFSM>().SendEvent("Atari");
                    OoatariController.Instance.Ooatari(atariZugara);
                }
                else
                {
                    foreach (var ptn in ExitPtn)
                    {
                        var cb = NoReaction;
                        if (ptn == ExitPtn.Last())
                        {
                            cb = callback;
                        }

                        DirectionController.GetComponent<ReelController>().EnqueueDirection(ptn, 0.5f, cb);

                        if (result.reachPatternName.Contains("SP3"))
                        {
                            MarinController.GetComponent<PlayMakerFSM>().SendEvent("Out");
                        }
                    }
                }
            });
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
        new RP2Direction{ Label="SP1", Sizi="901" },
        new RP2Direction{ Label="SP3", Sizi="107-2" },  // マリン呼び込み
    };

    static List<RP2Direction> RPDExitList = new List<RP2Direction>(){
        new RP2Direction{ Label="ノーマル", Sizi="101" },
        new RP2Direction{ Label="泡", Sizi="101" },
        new RP2Direction{ Label="魚群", Sizi="101" },
        new RP2Direction{ Label="SP1", Sizi="101" },
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
        RPDList.ForEach(RPD =>
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

    static public List<String> SangoExit(
        String ReachPattern,
        int ReachLine
    )
    {

        List<String> SiziList = new List<String>();

        // さんご礁
        RPRLDExitList.ForEach(RPRLD =>
        {
            if (ReachLine == RPRLD.ReachLine && ReachPattern.Contains(RPRLD.Label))
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
