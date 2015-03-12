using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class DisplayHistory : FsmStateAction
{
    public GameObject[] historySprites;
    public FsmInt[] histories;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        for (int i = 0; i < 10; ++i)
        {
            var level = 0;
            var h = histories[i].Value;
            if(h==0){
                level = 0;
            } else {
                level = (h-h%100+100)/100;
            }

            if (level > 10)
            {
                // “_–Å
                // TODO ‚Ç‚¤‚â‚Á‚Ä“_–Å‚³‚¹‚é‚©
            }
            else
            {
                // “_“”
                historySprites[i].GetComponent<UISprite>().spriteName = "meteor_lv" + level.ToString();
            }
        }
        Finish();
	}


}
