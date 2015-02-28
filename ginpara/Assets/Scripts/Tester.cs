using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Tester : MonoBehaviour {

	const string MainLogicFSMName = "MainLogicFSM";

	public GameObject MainLogic;
    public GameObject Atacker;
	private PlayMakerFSM MainLogicFSM;
    private MainLogic ml;

	string[] labels = new []{
		"チャッカー通過",
        "アタッカー開"
	};

	class EventButton {
		public string Label{ set; get; }
		public int CheckerID{ set; get; }
		public Rect rect{ set; get;}
	}

	List<EventButton> checkers = new List<EventButton>();

	// Use this for initialization
	void Start () {

		const int ButtonWidth = 150;
		const int ButtonHeight = 20;
		const int BeginY = 50;

		var y = BeginY;
		int ID = 0;

		labels.ToList().ForEach(label=>{
			var checker = new EventButton{
				Label = label,
				CheckerID = ID,
				rect = new Rect(0,y,ButtonWidth,ButtonHeight)
			};
			checkers.Add (checker);
			y+=ButtonHeight;
			ID++;
		});

		var fsms = MainLogic.GetComponents<PlayMakerFSM>();
		fsms.ToList ().ForEach (fsm=>{
			if( fsm.FsmName == MainLogicFSMName ){
				MainLogicFSM = fsm;
			}
		});

        ml = MainLogic.GetComponent<MainLogic>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		checkers.ForEach(c=>{
            switch (c.CheckerID)
            {
                case 0:
			        if( GUI.Button (c.rect, c.Label) ){
				        ml.NoticeChacker();
			        }
                    break;
                case 1:
			        if( GUI.Button (c.rect, c.Label) ){
                        Atacker.GetComponent<PlayMakerFSM>().SendEvent("大当たり");
			        }
                    break;
            }
		});
	}
}
