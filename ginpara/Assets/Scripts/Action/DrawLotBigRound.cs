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

	public override void OnEnter()
	{
        var result = MainLogic.GetComponent<MainLogic>().DrawLot(
            HoryuSu.Value,
            KenriKaisu.Value,
            ForceNormalReach.Value
        );

        var reels = Reel.Choose();

        // ���o�����R�[���o�b�N
        Action callback = () =>
        {
            ReelController.GetComponent<ReelController>().EndEvent();
        };

        if (result.isOOatari)
        {
            // TODO �哖����
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
                Debug.Log("���}�F" + result.tokuzu);
                Debug.Log("���}�F" + result.reachLineName);
                Debug.Log("���[�`���C��"+result.reachLine);
                Debug.Log("���[�`�p�^�[���F" + result.reachPatternName);

                // ���[���̎~�܂�ʒu���擾
                reels = Reel.Choose(result.reachLine, result.tokuzu);

                var pattern = GetReachPatternList(result.reachPatternName);

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
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, callback);
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
        new RP2Direction{ Label="�m�[�}��", Sizi="101" },
        new RP2Direction{ Label="�A", Sizi="104" },
        new RP2Direction{ Label="���Q", Sizi="105" },
        //new RP2Direction{ Label="SP1", Sizi="101" },
        //new RP2Direction{ Label="SP2", Sizi="101" },  
        //new RP2Direction{ Label="SP3", Sizi="101" },  
    };

    /// <summary>
    /// ���[�`�p�^�[�������牉�o����p�^�[���̃��X�g���擾
    /// </summary>
    /// <param name="ReachPattern"></param>
    /// <returns></returns>
    static public List<String> GetReachPatternList(String ReachPattern){

        List<String> SiziList = new List<String>();

        // �A�A�m�[�}���A���Q�ASP1, SP2, SP3 ���ڂ��Ă��邩����
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
