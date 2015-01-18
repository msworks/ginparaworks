using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
GinparaAnimationManager.cs
created by k-sasaki

盤面アニメーション管理用クラス
シングルトン
演出NOを渡すことで対応するアニメーションを起動します
渡された演出ナンバーをキューに格納し順に起動します 

****使い方****
AnimationListに対象のゲームオブジェクトをインスペクターからセットしてください
AnimationNameListに再生したいクリップのファイル名を書いてください（AnimationListに紐づいたelementNO）
*************
*/

public class GinparaAnimationManager : MonoBehaviour {
	public List<Animation> m_AnimationList = new List<Animation>();
	public List<string> m_AnimationNameList = new List<string>();

	static GinparaAnimationManager _Instance;
	private Queue m_ActionQue = new Queue();
	void Awake(){
		_Instance = this;
	}

	static public GinparaAnimationManager getInstance(){
		return _Instance;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//キューを消化 
		while(m_ActionQue.Count > 0){
			Dictionary<string , int> eventDict = (Dictionary<string , int>)m_ActionQue.Dequeue ();
			bool isPlay = ( eventDict["isPlay"] != 0 )? true : false;
			run ((int)eventDict["index"] , isPlay);
		}
	}

	//アニメーションの起動 
	public void runAnimation(int index ){
		Dictionary<string , int> eventDict = new Dictionary<string , int>();
		eventDict.Add ("index" , index);//演出noを格納 
		eventDict.Add ("isPlay" , 1);//再生の有無を格納 

		m_ActionQue.Enqueue(eventDict);//キューに格納 
	}

	//アニメーションの停止 
	public void stopAnimation(int index ){
		Dictionary<string , int> eventDict = new Dictionary<string , int>();
		eventDict.Add ("index" , index);//演出noを格納 
		eventDict.Add ("isPlay" , 0);//再生の有無を格納 

		m_ActionQue.Enqueue(eventDict);//キューに格納 
	}

	//演出noごとの動作指定 
	void run(int index , bool isPlay){
		Animation animation = m_AnimationList[index];
		if (!animation) {
			Debug.LogWarning ("演出NO:" + index + " はありません");
			return;
		}

		if (isPlay) {
			animation.Play(m_AnimationNameList[index]);
			Debug.Log ("演出NO:"+index+ "の" + m_AnimationNameList[index] + " を　再生");
		} else {
			animation.Stop();
			Debug.Log ("演出NO:"+index+" を　停止");
			return;
		}

		switch(index){
			case 1:

				break;
		}


	}

	//テスト用gui 
	int testIndex = 0;
	void OnGUI()
	{
		if ( GUI.Button(new Rect(0, 0, 30, 20), "←" ) )
		{
			testIndex--;
		}

		if ( GUI.Button(new Rect(70, 0, 30, 20), "→" ) )
		{
			testIndex++;
		}

		if ( GUI.Button(new Rect(0, 21, 50, 20), "再生" ) )
		{
			runAnimation(testIndex);
		}
		if ( GUI.Button(new Rect(50, 21, 50, 20), "停止" ) )
		{
			stopAnimation(testIndex);
		}


		GUI.Label (new Rect(36, 0, 60, 20) , ("No:"+testIndex));
	}

}





