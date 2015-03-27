using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// �q�X�g���[���P��������
/// </summary>
[ActionCategory("Ginpara")]
public class AddHistory : FsmStateAction
{
    public override void OnEnter()
    {
        Fsm.GameObject.GetComponent<History>().Add();
        Finish();
    }
}

/// <summary>
/// �q�X�g���[���E�ɃV�t�g����
/// </summary>
[ActionCategory("Ginpara")]
public class ShiftHistory : FsmStateAction
{
    public override void OnEnter()
    {
        Fsm.GameObject.GetComponent<History>().Shift();
        Finish();
    }
}

