using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Tester : MonoBehaviour {

	public GameObject MainLogic;

	string[] labels = new []{
		"チャッカー通過",
		"check2",
		"check3",
		"check4",
		"check5",
		"check6"
	};

	class CheckerThrower {
		public string Label{ set; get; }
		public int CheckerID{ set; get; }
		public Rect rect{ set; get;}
	}

	List<CheckerThrower> checkers = new List<CheckerThrower>();

	// Use this for initialization
	void Start () {

		const int ButtonWidth = 150;
		const int ButtonHeight = 20;
		const int BeginY = 50;

		var y = BeginY;
		int ID = 0;

		labels.ToList().ForEach(label=>{
			var checker = new CheckerThrower{
				Label = label,
				CheckerID = ID,
				rect = new Rect(0,y,ButtonWidth,ButtonHeight)
			};
			checkers.Add (checker);
			y+=ButtonHeight;
			ID++;
		});

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		checkers.ForEach(c=>{

		});
	}
}
