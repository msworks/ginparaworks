using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class DrawLotBigRound : FsmStateAction
{
	const int TABLE_SIZE = 65536;
	const int TABLE_ATARI = 202;
	const int TABLE_HAZURE = 65334;
	const int KAKUHEN_ATARI = 2029;
	const int KAKUHEN_HAZURE = 63507;

	public FsmBool InKakuhen;
	public FsmEvent Atari;
	public FsmEvent Hazure;

	private bool[] normaltable;
	private bool[] kakuhentable;
	private System.Random rnd = new System.Random();
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
		// TODO どこかにストアしておく
		var atari = Enumerable.Range (0,TABLE_ATARI).Select(v=>true);
		var hazure = Enumerable.Range (0,TABLE_HAZURE).Select(v=>false);
		normaltable = atari.Concat(hazure).ToArray ();
		
		var kakuhenatari = Enumerable.Range (0,KAKUHEN_ATARI).Select(v=>true);
		var kakuhenhazure = Enumerable.Range (0,KAKUHEN_HAZURE).Select(v=>false);
		kakuhentable = kakuhenatari.Concat (kakuhenhazure).ToArray ();

		var table = InKakuhen.Value ? kakuhentable : normaltable;
		int value = rnd.Next(TABLE_SIZE);

		if( table[value] ){
			Fsm.Event(Atari);
		} else { 
			Fsm.Event(Hazure);
		}

		Finish();
	}


}
