using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ginpara
{

/// <summary>
/// �哖���蒊�I���s��
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

        // ���o�����R�[���o�b�N
        Action callback = () =>
        {
            Debug.Log("CALLBACK");
            ReelController.GetComponent<ReelController>().EndEvent();
        };

        if (result.isOOatari)
        {
            // TODO �哖�������
            Debug.Log("*** �哖���� ***");
            ReelController.GetComponent<ReelController>().EnqueueDirection("1", 1f);
            ReelController.GetComponent<ReelController>().EnqueueDirection("2", 1f);
            ReelController.GetComponent<ReelController>().EnqueueDirection("3", 8f);
            ReelController.GetComponent<ReelController>().EnqueueDirection("4-1", 0.5f);
            ReelController.GetComponent<ReelController>().EnqueueDirection("5-1", 0.5f);
            ReelController.GetComponent<ReelController>().EnqueueDirection("6-1", 0.5f, callback);
        }
        else
        {
            // �n�Y��
            if (result.reachPattern == -1){
                // �o���P��
                // �G�t�F�N�g��ʒm
                if (HoryuSu.Value < 3)
                {
                    // �ۗ��O�A�P�A�Q�̃G�t�F�N�g
                    ReelController.GetComponent<ReelController>().EnqueueDirection("1", 1f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("2", 1f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("3", 8f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, callback);
                }
                else
                {
                    // �ۗ��R�C�S�̃G�t�F�N�g
                    ReelController.GetComponent<ReelController>().EnqueueDirection("1", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("2", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("3", 0f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, callback);
                }
                // �����܂Ńo���P��
            }
            else
            {
                // �n�Y�����[�`
                /*
                Debug.Log("���}�F" + result.tokuzu);
                Debug.Log("���}�F" + result.reachLineName);
                Debug.Log("���[�`���C��"+result.reachLine);
                Debug.Log("���[�`�p�^�[���F" + result.reachPatternName);
                 */

                // ���[���̎~�܂�ʒu���擾
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

                // �G�t�F�N�g��ʒm
                if (HoryuSu.Value < 3)
                {
                    // �ۗ��O�A�P�A�Q�̃G�t�F�N�g
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
                    // �ۗ��R�C�S�̃G�t�F�N�g
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
        new RP2Direction{ Label="�m�[�}��", Sizi="101" },
        new RP2Direction{ Label="�A", Sizi="104" },
        new RP2Direction{ Label="���Q", Sizi="105" },
        new RP2Direction{ Label="SP1", Sizi="102" },
        new RP2Direction{ Label="SP3", Sizi="107-2" },  
    };

    static List<RP2Direction> RPDExitList = new List<RP2Direction>(){
        new RP2Direction{ Label="�m�[�}��", Sizi="101" },
        new RP2Direction{ Label="�A", Sizi="101" },
        new RP2Direction{ Label="���Q", Sizi="101" },
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
    /// ���[�`�p�^�[�������牉�o����p�^�[���̃��X�g���擾
    /// </summary>
    /// <param name="ReachPattern"></param>
    /// <returns></returns>
    static public List<String> GetReachPatternList(
        String ReachPattern,
        int ReachLine
    ){

        List<String> SiziList = new List<String>();

        // �A�A�m�[�}���A���Q�ASP1, SP2, SP3 ���ڂ��Ă��邩����
        RPDExitList.ForEach(RPD =>
        {
            if (ReachPattern.Contains(RPD.Label))
            {
                SiziList.Add(RPD.Sizi);
            }
        });

        // ���񂲏�
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
    /// ���[�`�p�^�[�������牉�o����I���p�^�[���̃��X�g���擾
    /// </summary>
    /// <param name="ReachPattern"></param>
    /// <returns></returns>
    static public List<String> GetReachPatternExitList(
        String ReachPattern,
        int ReachLine
    ){

        List<String> SiziList = new List<String>();

        // �A�A�m�[�}���A���Q�ASP1, SP2, SP3 ���ڂ��Ă��邩����
        RPDExitList.ForEach(RPD =>
        {
            if (ReachPattern.Contains(RPD.Label))
            {
                SiziList.Add(RPD.Sizi);
            }
        });

        // ���񂲏�
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
