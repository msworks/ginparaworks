using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class LastRoundBGM : FsmStateAction
{
    public FsmInt Round;
    public FsmInt LastRound;

	public override void OnEnter()
	{
        if (Round.Value == LastRound.Value)
        {
            AudioManager.Instance.PlayBGMLoop(7);
        }

        Finish();
    }
}
