using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class NGUILabelSetText : FsmStateAction
{
    public GameObject Label;
    public FsmString msg;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        Label.GetComponent<UILabel>().text = msg.Value;
		Finish();
	}
}

[ActionCategory("Ginpara")]
public class NGUISetSpriteName : FsmStateAction
{
    public GameObject Sprite;
    public FsmString SpriteName;

    // Code that runs on entering the state.
    public override void OnEnter()
    {
        Sprite.GetComponent<UISprite>().spriteName = SpriteName.Value;
        Finish();
    }
}