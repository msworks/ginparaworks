using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// ラウンド開始
/// </summary>
[ActionCategory("Ginpara")]
public class Round : FsmStateAction
{
    public FsmInt round;
    public GameObject DirectionController;

    // Code that runs on entering the state.
    public override void OnEnter()
    {
        var sizi = "402-" + round.Value.ToString();
        DirectionController.GetComponent<ReelController>().EnqueueDirection(sizi, 1f);
        //DirectionController.GetComponent<ReelController>().EnqueueDirection("403", 1f);

        Finish();
    }
}

/// <summary>
/// ラウンド終了
/// </summary>
[ActionCategory("Ginpara")]
public class ExitRound : FsmStateAction
{
    public GameObject DirectionController;

    // Code that runs on entering the state.
    public override void OnEnter()
    {
        DirectionController.GetComponent<ReelController>().EnqueueDirection("403", 1f);
        DirectionController.GetComponent<ReelController>().EnqueueDirection("201-2", 1f);

        Finish();
    }
}

