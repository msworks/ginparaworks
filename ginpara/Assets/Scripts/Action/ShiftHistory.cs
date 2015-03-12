using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class ShiftHistory : FsmStateAction
{
    public FsmInt[] histories;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        for (int i = 1; i < 10; i++)
        {
            histories[i].Value = histories[i - 1].Value;
        }
        histories[0].Value = 0;
        Finish();
	}


}
