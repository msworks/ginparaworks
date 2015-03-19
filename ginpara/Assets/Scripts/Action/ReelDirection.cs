using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class ReelDirection : FsmStateAction
{
    public GameObject GinparaManager;   // �o�͐�
    public GameObject ReelController;   // ���͌�
    public FsmFloat WaitTime;

	// Code that runs on entering the state.
	public override void OnEnter()
	{
        var data = (GPDirection)ReelController.GetComponent<ReelController>().Direction.Dequeue();

        //Debug.Log("�w���i���o�[�F" + data.sizi + " �҂����ԁF" + data.time.ToString());

        GinparaManager.GetComponent<GinparaManager>().Order(data.sizi);

        // �҂����Ԃ��擾
        WaitTime.Value = data.time;

        Finish();
	}

}

[ActionCategory("Ginpara")]
public class CheckReelDirection : FsmStateAction
{
    public GameObject ReelController;   // ���͌�
    public FsmEvent ari;
    public FsmEvent nasi;

    // ���o�f�[�^������΂���C�x���g���A�Ȃ���΂Ȃ��C�x���g�𔭍s
    public override void OnEnter()
    {
        var data = ReelController.GetComponent<ReelController>().Direction.Count;
        Fsm.Event(data != 0 ? ari : nasi);
    }

}
