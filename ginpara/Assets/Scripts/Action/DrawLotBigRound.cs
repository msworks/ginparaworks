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
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 2f);
                }
                else
                {
                    // �ۗ��R�C�S�̃G�t�F�N�g
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
                // �n�Y�����[�`
                Debug.Log("���}�F" + result.tokuzu);
                Debug.Log("���}�F" + result.reachLineName);
                Debug.Log("���[�`���C��"+result.reachLine);
                Debug.Log("���[�`�p�^�[���F" + result.reachPatternName);

                // ���[�`���C���ɓ��}��u��
                reels = Reel.Choose(result.reachLine, result.tokuzu);

                // �e�X�g�Ńo���P�ڃG�t�F�N�g�𔭍s
                // �G�t�F�N�g��ʒm
                if (HoryuSu.Value < 3)
                {
                    // �ۗ��O�A�P�A�Q�̃G�t�F�N�g
                    ReelController.GetComponent<ReelController>().EnqueueDirection("1", 1f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("2", 1f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection("3", 8f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 0.5f);
                    ReelController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 2f);
                }
                else
                {
                    // �ۗ��R�C�S�̃G�t�F�N�g
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
