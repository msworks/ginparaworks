using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class KakuhenLog : FsmStateAction
{
    public FsmInt Kakuhen;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        Debug.Log("*** �m�� �c�� " + Kakuhen.Value + " ***");
		Finish();
	}


}
