using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class SetScrollSpeed : FsmStateAction
{
    public GameObject ScrollView;
    public FsmFloat ScrollSpeed;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        ScrollView.GetComponent<scroll>().ScrollSpeed = ScrollSpeed.Value;
		Finish();
	}


}
