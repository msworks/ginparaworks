using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GinparaManager : MonoBehaviour {
	//====================================================================================================
	// Field
	//====================================================================================================
	[SerializeField] private UITextureManager back = null;
	[SerializeField] private UITextureManager lamp1 = null;
	[SerializeField] private UITextureManager lamp6 = null;
	[SerializeField] private UITextureManager lamp7 = null;
	[SerializeField] private UITextureManager lamp8 = null;
	[SerializeField] private UITextureManager pull11 = null;
	[SerializeField] private UITextureManager lampCircle2 = null;
	[SerializeField] private UITextureManager lampCircle3 = null;
	[SerializeField] private Rail topRail = null;
#if UNITY_EDITOR
	private string orderCode = string.Empty;
#endif

	void Start(){
	}

	void Update(){
#if UNITY_EDITOR
		if(Input.GetKeyUp(KeyCode.Alpha0)){
			this.orderCode += "0";
		}
		if(Input.GetKeyUp(KeyCode.Alpha1)){
			this.orderCode += "1";
		}
		if(Input.GetKeyUp(KeyCode.Alpha2)){
			this.orderCode += "2";
		}
		if(Input.GetKeyUp(KeyCode.Alpha3)){
			this.orderCode += "3";
		}
		if(Input.GetKeyUp(KeyCode.Alpha4)){
			this.orderCode += "4";
		}
		if(Input.GetKeyUp(KeyCode.Alpha5)){
			this.orderCode += "5";
		}
		if(Input.GetKeyUp(KeyCode.Alpha6)){
			this.orderCode += "6";
		}
		if(Input.GetKeyUp(KeyCode.Alpha7)){
			this.orderCode += "7";
		}
		if(Input.GetKeyUp(KeyCode.Alpha8)){
			this.orderCode += "8";
		}
		if(Input.GetKeyUp(KeyCode.Alpha9)){
			this.orderCode += "9";
		}
		if(Input.GetKeyUp(KeyCode.Minus)){
			this.orderCode += "-";
		}
		if(Input.GetKeyUp(KeyCode.Return)){
			this.Order (this.orderCode);
			this.orderCode = string.Empty;
		}
#endif
	}
	//====================================================================================================
	// Method
	//====================================================================================================
	/// <para>【第1引数】実行するパターンNo</para>
	/// <para>【第2引数】実行完了後（またはループ開始時）に呼ばれるコールバック</para>
	/// <para>【戻り値】発生したエラー内容を返します（普通は null が返ります）</para>
	public string Order(string patternNo, System.Action callback = null){
		string errorCode = null;
		switch (patternNo) {
		case "1":
			StartCoroutine(this.topRail.RailStart(() => {
				if(callback != null) callback();
			}));
			break;

		case "2":
			Debug.Log ("未実装");
			break;

		case "3":
			Debug.Log ("未実装");
			break;
			
		case "4-1":
			Debug.Log ("未実装");
			break;
			
		case "4-2":
			Debug.Log ("未実装");
			break;
			
		case "4-3":
			Debug.Log ("未実装");
			break;
			
		case "4-4":
			Debug.Log ("未実装");
			break;
			
		case "4-5":
			Debug.Log ("未実装");
			break;
			
		case "4-6":
			Debug.Log ("未実装");
			break;
			
		case "4-7":
			Debug.Log ("未実装");
			break;
			
		case "4-8":
			Debug.Log ("未実装");
			break;
			
		case "4-9":
			Debug.Log ("未実装");
			break;
			
		case "4-10":
			Debug.Log ("未実装");
			break;
			
		case "4-11":
			Debug.Log ("未実装");
			break;
			
		case "4-12":
			Debug.Log ("未実装");
			break;
			
		case "4-13":
			Debug.Log ("未実装");
			break;
			
		case "4-14":
			Debug.Log ("未実装");
			break;
			
		case "4-15":
			Debug.Log ("未実装");
			break;
			
		case "4-16":
			Debug.Log ("未実装");
			break;
			
		case "4-17":
			Debug.Log ("未実装");
			break;
			
		case "4-18":
			Debug.Log ("未実装");
			break;
			
		case "4-19":
			Debug.Log ("未実装");
			break;
			
		case "4-20":
			Debug.Log ("未実装");
			break;
			
		case "5-1":
			Debug.Log ("未実装");
			break;
			
		case "5-2":
			Debug.Log ("未実装");
			break;
			
		case "5-3":
			Debug.Log ("未実装");
			break;
			
		case "5-4":
			Debug.Log ("未実装");
			break;
			
		case "5-5":
			Debug.Log ("未実装");
			break;
			
		case "5-6":
			Debug.Log ("未実装");
			break;
			
		case "5-7":
			Debug.Log ("未実装");
			break;
			
		case "5-8":
			Debug.Log ("未実装");
			break;
			
		case "5-9":
			Debug.Log ("未実装");
			break;
			
		case "5-10":
			Debug.Log ("未実装");
			break;
			
		case "5-11":
			Debug.Log ("未実装");
			break;
			
		case "5-12":
			Debug.Log ("未実装");
			break;
			
		case "5-13":
			Debug.Log ("未実装");
			break;
			
		case "5-14":
			Debug.Log ("未実装");
			break;
			
		case "5-15":
			Debug.Log ("未実装");
			break;
			
		case "5-16":
			Debug.Log ("未実装");
			break;
			
		case "5-17":
			Debug.Log ("未実装");
			break;
			
		case "5-18":
			Debug.Log ("未実装");
			break;
			
		case "5-19":
			Debug.Log ("未実装");
			break;
			
		case "5-20":
			Debug.Log ("未実装");
			break;
			
		case "6-1":
			Debug.Log ("未実装");
			break;
			
		case "6-2":
			Debug.Log ("未実装");
			break;
			
		case "6-3":
			Debug.Log ("未実装");
			break;
			
		case "6-4":
			Debug.Log ("未実装");
			break;
			
		case "6-5":
			Debug.Log ("未実装");
			break;
			
		case "6-6":
			Debug.Log ("未実装");
			break;
			
		case "6-7":
			Debug.Log ("未実装");
			break;
			
		case "6-8":
			Debug.Log ("未実装");
			break;
			
		case "6-9":
			Debug.Log ("未実装");
			break;
			
		case "6-10":
			Debug.Log ("未実装");
			break;
			
		case "6-11":
			Debug.Log ("未実装");
			break;
			
		case "6-12":
			Debug.Log ("未実装");
			break;
			
		case "6-13":
			Debug.Log ("未実装");
			break;
			
		case "6-14":
			Debug.Log ("未実装");
			break;
			
		case "6-15":
			Debug.Log ("未実装");
			break;
			
		case "6-16":
			Debug.Log ("未実装");
			break;
			
		case "6-17":
			Debug.Log ("未実装");
			break;
			
		case "6-18":
			Debug.Log ("未実装");
			break;
			
		case "6-19":
			Debug.Log ("未実装");
			break;
			
		case "6-20":
			Debug.Log ("未実装");
			break;
			
		case "7-1":
			Debug.Log ("未実装");
			break;
			
		case "7-2":
			Debug.Log ("未実装");
			break;
			
		case "7-3":
			Debug.Log ("未実装");
			break;
			
		case "7-4":
			Debug.Log ("未実装");
			break;
			
		case "7-5":
			Debug.Log ("未実装");
			break;
			
		case "7-6":
			Debug.Log ("未実装");
			break;
			
		case "7-7":
			Debug.Log ("未実装");
			break;
			
		case "7-8":
			Debug.Log ("未実装");
			break;
			
		case "7-9":
			Debug.Log ("未実装");
			break;
			
		case "7-10":
			Debug.Log ("未実装");
			break;
			
		case "7-11":
			Debug.Log ("未実装");
			break;
			
		case "7-12":
			Debug.Log ("未実装");
			break;
			
		case "7-13":
			Debug.Log ("未実装");
			break;
			
		case "7-14":
			Debug.Log ("未実装");
			break;
			
		case "7-15":
			Debug.Log ("未実装");
			break;
			
		case "7-16":
			Debug.Log ("未実装");
			break;
			
		case "7-17":
			Debug.Log ("未実装");
			break;
			
		case "7-18":
			Debug.Log ("未実装");
			break;
			
		case "7-19":
			Debug.Log ("未実装");
			break;
			
		case "7-20":
			Debug.Log ("未実装");
			break;
			
		case "8-1":
			Debug.Log ("未実装");
			break;
			
		case "8-2":
			Debug.Log ("未実装");
			break;
			
		case "8-3":
			Debug.Log ("未実装");
			break;
			
		case "8-4":
			Debug.Log ("未実装");
			break;
			
		case "8-5":
			Debug.Log ("未実装");
			break;
			
		case "8-6":
			Debug.Log ("未実装");
			break;
			
		case "8-7":
			Debug.Log ("未実装");
			break;
			
		case "8-8":
			Debug.Log ("未実装");
			break;
			
		case "8-9":
			Debug.Log ("未実装");
			break;
			
		case "8-10":
			Debug.Log ("未実装");
			break;
			
		case "8-11":
			Debug.Log ("未実装");
			break;
			
		case "8-12":
			Debug.Log ("未実装");
			break;
			
		case "8-13":
			Debug.Log ("未実装");
			break;
			
		case "8-14":
			Debug.Log ("未実装");
			break;
			
		case "8-15":
			Debug.Log ("未実装");
			break;
			
		case "8-16":
			Debug.Log ("未実装");
			break;
			
		case "8-17":
			Debug.Log ("未実装");
			break;
			
		case "8-18":
			Debug.Log ("未実装");
			break;
			
		case "8-19":
			Debug.Log ("未実装");
			break;
			
		case "8-20":
			Debug.Log ("未実装");
			break;
			
		case "9-1":
			Debug.Log ("未実装");
			break;
			
		case "9-2":
			Debug.Log ("未実装");
			break;
			
		case "9-3":
			Debug.Log ("未実装");
			break;
			
		case "9-4":
			Debug.Log ("未実装");
			break;
			
		case "9-5":
			Debug.Log ("未実装");
			break;
			
		case "9-6":
			Debug.Log ("未実装");
			break;
			
		case "9-7":
			Debug.Log ("未実装");
			break;
			
		case "9-8":
			Debug.Log ("未実装");
			break;
			
		case "9-9":
			Debug.Log ("未実装");
			break;
			
		case "9-10":
			Debug.Log ("未実装");
			break;
			
		case "9-11":
			Debug.Log ("未実装");
			break;
			
		case "9-12":
			Debug.Log ("未実装");
			break;
			
		case "9-13":
			Debug.Log ("未実装");
			break;
			
		case "9-14":
			Debug.Log ("未実装");
			break;
			
		case "9-15":
			Debug.Log ("未実装");
			break;
			
		case "9-16":
			Debug.Log ("未実装");
			break;
			
		case "9-17":
			Debug.Log ("未実装");
			break;
			
		case "9-18":
			Debug.Log ("未実装");
			break;
			
		case "9-19":
			Debug.Log ("未実装");
			break;
			
		case "10-1":
			Debug.Log ("未実装");
			break;
			
		case "10-2":
			Debug.Log ("未実装");
			break;
			
		case "10-3":
			Debug.Log ("未実装");
			break;
			
		case "10-4":
			Debug.Log ("未実装");
			break;
			
		case "10-5":
			Debug.Log ("未実装");
			break;
			
		case "10-6":
			Debug.Log ("未実装");
			break;
			
		case "10-7":
			Debug.Log ("未実装");
			break;
			
		case "10-8":
			Debug.Log ("未実装");
			break;
			
		case "10-9":
			Debug.Log ("未実装");
			break;
			
		case "10-10":
			Debug.Log ("未実装");
			break;
			
		case "10-11":
			Debug.Log ("未実装");
			break;
			
		case "10-12":
			Debug.Log ("未実装");
			break;
			
		case "10-13":
			Debug.Log ("未実装");
			break;
			
		case "10-14":
			Debug.Log ("未実装");
			break;
			
		case "10-15":
			Debug.Log ("未実装");
			break;
			
		case "10-16":
			Debug.Log ("未実装");
			break;
			
		case "10-17":
			Debug.Log ("未実装");
			break;
			
		case "10-18":
			Debug.Log ("未実装");
			break;
			
		case "10-19":
			Debug.Log ("未実装");
			break;
			
		case "11-1":
			Debug.Log ("未実装");
			break;
			
		case "11-2":
			Debug.Log ("未実装");
			break;
			
		case "11-3":
			Debug.Log ("未実装");
			break;
			
		case "11-4":
			Debug.Log ("未実装");
			break;
			
		case "11-5":
			Debug.Log ("未実装");
			break;
			
		case "11-6":
			Debug.Log ("未実装");
			break;
			
		case "11-7":
			Debug.Log ("未実装");
			break;
			
		case "11-8":
			Debug.Log ("未実装");
			break;
			
		case "11-9":
			Debug.Log ("未実装");
			break;
			
		case "11-10":
			Debug.Log ("未実装");
			break;
			
		case "11-11":
			Debug.Log ("未実装");
			break;
			
		case "11-12":
			Debug.Log ("未実装");
			break;
			
		case "11-13":
			Debug.Log ("未実装");
			break;
			
		case "11-14":
			Debug.Log ("未実装");
			break;
			
		case "11-15":
			Debug.Log ("未実装");
			break;
			
		case "11-16":
			Debug.Log ("未実装");
			break;
			
		case "11-17":
			Debug.Log ("未実装");
			break;
			
		case "11-18":
			Debug.Log ("未実装");
			break;
			
		case "11-19":
			Debug.Log ("未実装");
			break;
			
		case "12-1":
			Debug.Log ("未実装");
			break;
			
		case "12-2":
			Debug.Log ("未実装");
			break;
			
		case "12-3":
			Debug.Log ("未実装");
			break;
			
		case "12-4":
			Debug.Log ("未実装");
			break;
			
		case "12-5":
			Debug.Log ("未実装");
			break;
			
		case "12-6":
			Debug.Log ("未実装");
			break;
			
		case "12-7":
			Debug.Log ("未実装");
			break;
			
		case "12-8":
			Debug.Log ("未実装");
			break;
			
		case "12-9":
			Debug.Log ("未実装");
			break;
			
		case "12-10":
			Debug.Log ("未実装");
			break;
			
		case "12-11":
			Debug.Log ("未実装");
			break;
			
		case "12-12":
			Debug.Log ("未実装");
			break;
			
		case "12-13":
			Debug.Log ("未実装");
			break;
			
		case "12-14":
			Debug.Log ("未実装");
			break;
			
		case "12-15":
			Debug.Log ("未実装");
			break;
			
		case "12-16":
			Debug.Log ("未実装");
			break;
			
		case "12-17":
			Debug.Log ("未実装");
			break;
			
		case "12-18":
			Debug.Log ("未実装");
			break;
			
		case "12-19":
			Debug.Log ("未実装");
			break;
			
		case "13-1":
			Debug.Log ("未実装");
			break;
			
		case "13-2":
			Debug.Log ("未実装");
			break;
			
		case "13-3":
			Debug.Log ("未実装");
			break;
			
		case "13-4":
			Debug.Log ("未実装");
			break;
			
		case "13-5":
			Debug.Log ("未実装");
			break;
			
		case "13-6":
			Debug.Log ("未実装");
			break;
			
		case "13-7":
			Debug.Log ("未実装");
			break;
			
		case "13-8":
			Debug.Log ("未実装");
			break;
			
		case "13-9":
			Debug.Log ("未実装");
			break;
			
		case "13-10":
			Debug.Log ("未実装");
			break;
			
		case "13-11":
			Debug.Log ("未実装");
			break;
			
		case "13-12":
			Debug.Log ("未実装");
			break;
			
		case "13-13":
			Debug.Log ("未実装");
			break;
			
		case "13-14":
			Debug.Log ("未実装");
			break;
			
		case "13-15":
			Debug.Log ("未実装");
			break;
			
		case "13-16":
			Debug.Log ("未実装");
			break;
			
		case "13-17":
			Debug.Log ("未実装");
			break;
			
		case "13-18":
			Debug.Log ("未実装");
			break;
			
		case "13-19":
			Debug.Log ("未実装");
			break;
			
		case "14-1":
			Debug.Log ("未実装");
			break;
			
		case "14-2":
			Debug.Log ("未実装");
			break;
			
		case "14-3":
			Debug.Log ("未実装");
			break;
			
		case "14-4":
			Debug.Log ("未実装");
			break;
			
		case "14-5":
			Debug.Log ("未実装");
			break;
			
		case "14-6":
			Debug.Log ("未実装");
			break;
			
		case "14-7":
			Debug.Log ("未実装");
			break;
			
		case "14-8":
			Debug.Log ("未実装");
			break;
			
		case "14-9":
			Debug.Log ("未実装");
			break;
			
		case "14-10":
			Debug.Log ("未実装");
			break;
			
		case "14-11":
			Debug.Log ("未実装");
			break;
			
		case "14-12":
			Debug.Log ("未実装");
			break;
			
		case "14-13":
			Debug.Log ("未実装");
			break;
			
		case "14-14":
			Debug.Log ("未実装");
			break;
			
		case "14-15":
			Debug.Log ("未実装");
			break;
			
		case "14-16":
			Debug.Log ("未実装");
			break;
			
		case "14-17":
			Debug.Log ("未実装");
			break;
			
		case "14-18":
			Debug.Log ("未実装");
			break;
			
		case "14-19":
			Debug.Log ("未実装");
			break;
			
		case "15-1":
			Debug.Log ("未実装");
			break;
			
		case "15-2":
			Debug.Log ("未実装");
			break;
			
		case "15-3":
			Debug.Log ("未実装");
			break;
			
		case "15-4":
			Debug.Log ("未実装");
			break;
			
		case "15-5":
			Debug.Log ("未実装");
			break;
			
		case "15-6":
			Debug.Log ("未実装");
			break;
			
		case "15-7":
			Debug.Log ("未実装");
			break;
			
		case "15-8":
			Debug.Log ("未実装");
			break;
			
		case "15-9":
			Debug.Log ("未実装");
			break;
			
		case "15-10":
			Debug.Log ("未実装");
			break;
			
		case "15-11":
			Debug.Log ("未実装");
			break;
			
		case "15-12":
			Debug.Log ("未実装");
			break;
			
		case "15-13":
			Debug.Log ("未実装");
			break;
			
		case "15-14":
			Debug.Log ("未実装");
			break;
			
		case "15-15":
			Debug.Log ("未実装");
			break;
			
		case "15-16":
			Debug.Log ("未実装");
			break;
			
		case "15-17":
			Debug.Log ("未実装");
			break;
			
		case "15-18":
			Debug.Log ("未実装");
			break;
			
		case "15-19":
			Debug.Log ("未実装");
			break;
			
		case "16-1":
			Debug.Log ("未実装");
			break;
			
		case "16-2":
			Debug.Log ("未実装");
			break;
			
		case "16-3":
			Debug.Log ("未実装");
			break;
			
		case "16-4":
			Debug.Log ("未実装");
			break;
			
		case "16-5":
			Debug.Log ("未実装");
			break;
			
		case "16-6":
			Debug.Log ("未実装");
			break;
			
		case "16-7":
			Debug.Log ("未実装");
			break;
			
		case "16-8":
			Debug.Log ("未実装");
			break;
			
		case "16-9":
			Debug.Log ("未実装");
			break;
			
		case "16-10":
			Debug.Log ("未実装");
			break;
			
		case "16-11":
			Debug.Log ("未実装");
			break;
			
		case "16-12":
			Debug.Log ("未実装");
			break;
			
		case "16-13":
			Debug.Log ("未実装");
			break;
			
		case "16-14":
			Debug.Log ("未実装");
			break;
			
		case "16-15":
			Debug.Log ("未実装");
			break;
			
		case "16-16":
			Debug.Log ("未実装");
			break;
			
		case "16-17":
			Debug.Log ("未実装");
			break;
			
		case "16-18":
			Debug.Log ("未実装");
			break;
			
		case "16-19":
			Debug.Log ("未実装");
			break;
			
		case "17-1":
			Debug.Log ("未実装");
			break;
			
		case "17-2":
			Debug.Log ("未実装");
			break;
			
		case "17-3":
			Debug.Log ("未実装");
			break;
			
		case "17-4":
			Debug.Log ("未実装");
			break;
			
		case "17-5":
			Debug.Log ("未実装");
			break;
			
		case "17-6":
			Debug.Log ("未実装");
			break;
			
		case "17-7":
			Debug.Log ("未実装");
			break;
			
		case "17-8":
			Debug.Log ("未実装");
			break;
			
		case "17-9":
			Debug.Log ("未実装");
			break;
			
		case "17-10":
			Debug.Log ("未実装");
			break;
			
		case "17-11":
			Debug.Log ("未実装");
			break;
			
		case "17-12":
			Debug.Log ("未実装");
			break;
			
		case "17-13":
			Debug.Log ("未実装");
			break;
			
		case "17-14":
			Debug.Log ("未実装");
			break;
			
		case "17-15":
			Debug.Log ("未実装");
			break;
			
		case "17-16":
			Debug.Log ("未実装");
			break;
			
		case "17-17":
			Debug.Log ("未実装");
			break;
			
		case "17-18":
			Debug.Log ("未実装");
			break;
			
		case "17-19":
			Debug.Log ("未実装");
			break;
			
		case "18-1":
			Debug.Log ("未実装");
			break;
			
		case "18-2":
			Debug.Log ("未実装");
			break;
			
		case "18-3":
			Debug.Log ("未実装");
			break;
			
		case "18-4":
			Debug.Log ("未実装");
			break;
			
		case "18-5":
			Debug.Log ("未実装");
			break;
			
		case "18-6":
			Debug.Log ("未実装");
			break;
			
		case "18-7":
			Debug.Log ("未実装");
			break;
			
		case "18-8":
			Debug.Log ("未実装");
			break;
			
		case "18-9":
			Debug.Log ("未実装");
			break;
			
		case "18-10":
			Debug.Log ("未実装");
			break;
			
		case "18-11":
			Debug.Log ("未実装");
			break;
			
		case "18-12":
			Debug.Log ("未実装");
			break;
			
		case "18-13":
			Debug.Log ("未実装");
			break;
			
		case "18-14":
			Debug.Log ("未実装");
			break;
			
		case "18-15":
			Debug.Log ("未実装");
			break;
			
		case "18-16":
			Debug.Log ("未実装");
			break;
			
		case "18-17":
			Debug.Log ("未実装");
			break;
			
		case "18-18":
			Debug.Log ("未実装");
			break;
			
		case "18-19":
			Debug.Log ("未実装");
			break;
			
		case "19-1":
			Debug.Log ("未実装");
			break;
			
		case "19-2":
			Debug.Log ("未実装");
			break;
			
		case "19-3":
			Debug.Log ("未実装");
			break;
			
		case "19-4":
			Debug.Log ("未実装");
			break;
			
		case "19-5":
			Debug.Log ("未実装");
			break;
			
		case "19-6":
			Debug.Log ("未実装");
			break;
			
		case "19-7":
			Debug.Log ("未実装");
			break;
			
		case "19-8":
			Debug.Log ("未実装");
			break;
			
		case "19-9":
			Debug.Log ("未実装");
			break;
			
		case "19-10":
			Debug.Log ("未実装");
			break;
			
		case "19-11":
			Debug.Log ("未実装");
			break;
			
		case "19-12":
			Debug.Log ("未実装");
			break;
			
		case "19-13":
			Debug.Log ("未実装");
			break;
			
		case "19-14":
			Debug.Log ("未実装");
			break;
			
		case "19-15":
			Debug.Log ("未実装");
			break;
			
		case "19-16":
			Debug.Log ("未実装");
			break;
			
		case "19-17":
			Debug.Log ("未実装");
			break;
			
		case "19-18":
			Debug.Log ("未実装");
			break;
			
		case "19-19":
			Debug.Log ("未実装");
			break;
			
		case "20-1":
			Debug.Log ("未実装");
			break;
			
		case "20-2":
			Debug.Log ("未実装");
			break;
			
		case "20-3":
			Debug.Log ("未実装");
			break;
			
		case "20-4":
			Debug.Log ("未実装");
			break;
			
		case "20-5":
			Debug.Log ("未実装");
			break;
			
		case "20-6":
			Debug.Log ("未実装");
			break;
			
		case "20-7":
			Debug.Log ("未実装");
			break;
			
		case "20-8":
			Debug.Log ("未実装");
			break;
			
		case "20-9":
			Debug.Log ("未実装");
			break;
			
		case "20-10":
			Debug.Log ("未実装");
			break;
			
		case "20-11":
			Debug.Log ("未実装");
			break;
			
		case "20-12":
			Debug.Log ("未実装");
			break;
			
		case "20-13":
			Debug.Log ("未実装");
			break;
			
		case "20-14":
			Debug.Log ("未実装");
			break;
			
		case "20-15":
			Debug.Log ("未実装");
			break;
			
		case "20-16":
			Debug.Log ("未実装");
			break;
			
		case "20-17":
			Debug.Log ("未実装");
			break;
			
		case "20-18":
			Debug.Log ("未実装");
			break;
			
		case "20-19":
			Debug.Log ("未実装");
			break;
			
		case "21-1":
			Debug.Log ("未実装");
			break;
			
		case "21-2":
			Debug.Log ("未実装");
			break;
			
		case "21-3":
			Debug.Log ("未実装");
			break;
			
		case "21-4":
			Debug.Log ("未実装");
			break;
			
		case "21-5":
			Debug.Log ("未実装");
			break;
			
		case "21-6":
			Debug.Log ("未実装");
			break;
			
		case "21-7":
			Debug.Log ("未実装");
			break;
			
		case "21-8":
			Debug.Log ("未実装");
			break;
			
		case "21-9":
			Debug.Log ("未実装");
			break;
			
		case "21-10":
			Debug.Log ("未実装");
			break;
			
		case "21-11":
			Debug.Log ("未実装");
			break;
			
		case "21-12":
			Debug.Log ("未実装");
			break;
			
		case "21-13":
			Debug.Log ("未実装");
			break;
			
		case "21-14":
			Debug.Log ("未実装");
			break;
			
		case "21-15":
			Debug.Log ("未実装");
			break;
			
		case "21-16":
			Debug.Log ("未実装");
			break;
			
		case "21-17":
			Debug.Log ("未実装");
			break;
			
		case "21-18":
			Debug.Log ("未実装");
			break;
			
		case "21-19":
			Debug.Log ("未実装");
			break;
			
		case "22-1":
			Debug.Log ("未実装");
			break;
			
		case "22-2":
			Debug.Log ("未実装");
			break;
			
		case "22-3":
			Debug.Log ("未実装");
			break;
			
		case "22-4":
			Debug.Log ("未実装");
			break;
			
		case "22-5":
			Debug.Log ("未実装");
			break;
			
		case "22-6":
			Debug.Log ("未実装");
			break;
			
		case "22-7":
			Debug.Log ("未実装");
			break;
			
		case "22-8":
			Debug.Log ("未実装");
			break;
			
		case "22-9":
			Debug.Log ("未実装");
			break;
			
		case "22-10":
			Debug.Log ("未実装");
			break;
			
		case "22-11":
			Debug.Log ("未実装");
			break;
			
		case "22-12":
			Debug.Log ("未実装");
			break;
			
		case "22-13":
			Debug.Log ("未実装");
			break;
			
		case "22-14":
			Debug.Log ("未実装");
			break;
			
		case "22-15":
			Debug.Log ("未実装");
			break;
			
		case "22-16":
			Debug.Log ("未実装");
			break;
			
		case "22-17":
			Debug.Log ("未実装");
			break;
			
		case "22-18":
			Debug.Log ("未実装");
			break;
			
		case "22-19":
			Debug.Log ("未実装");
			break;
			
		case "23-1":
			Debug.Log ("未実装");
			break;
			
		case "23-2":
			Debug.Log ("未実装");
			break;
			
		case "23-3":
			Debug.Log ("未実装");
			break;
			
		case "23-4":
			Debug.Log ("未実装");
			break;
			
		case "23-5":
			Debug.Log ("未実装");
			break;
			
		case "23-6":
			Debug.Log ("未実装");
			break;
			
		case "23-7":
			Debug.Log ("未実装");
			break;
			
		case "23-8":
			Debug.Log ("未実装");
			break;
			
		case "23-9":
			Debug.Log ("未実装");
			break;
			
		case "23-10":
			Debug.Log ("未実装");
			break;
			
		case "23-11":
			Debug.Log ("未実装");
			break;
			
		case "23-12":
			Debug.Log ("未実装");
			break;
			
		case "23-13":
			Debug.Log ("未実装");
			break;
			
		case "23-14":
			Debug.Log ("未実装");
			break;
			
		case "23-15":
			Debug.Log ("未実装");
			break;
			
		case "23-16":
			Debug.Log ("未実装");
			break;
			
		case "23-17":
			Debug.Log ("未実装");
			break;
			
		case "23-18":
			Debug.Log ("未実装");
			break;
			
		case "23-19":
			Debug.Log ("未実装");
			break;
			
		case "24-1":
			Debug.Log ("未実装");
			break;
			
		case "24-2":
			Debug.Log ("未実装");
			break;
			
		case "24-3":
			Debug.Log ("未実装");
			break;
			
		case "24-4":
			Debug.Log ("未実装");
			break;
			
		case "24-5":
			Debug.Log ("未実装");
			break;
			
		case "24-6":
			Debug.Log ("未実装");
			break;
			
		case "24-7":
			Debug.Log ("未実装");
			break;
			
		case "24-8":
			Debug.Log ("未実装");
			break;
			
		case "24-9":
			Debug.Log ("未実装");
			break;
			
		case "24-10":
			Debug.Log ("未実装");
			break;
			
		case "24-11":
			Debug.Log ("未実装");
			break;
			
		case "24-12":
			Debug.Log ("未実装");
			break;
			
		case "24-13":
			Debug.Log ("未実装");
			break;
			
		case "24-14":
			Debug.Log ("未実装");
			break;
			
		case "24-15":
			Debug.Log ("未実装");
			break;
			
		case "24-16":
			Debug.Log ("未実装");
			break;
			
		case "24-17":
			Debug.Log ("未実装");
			break;
			
		case "24-18":
			Debug.Log ("未実装");
			break;
			
		case "24-19":
			Debug.Log ("未実装");
			break;
			
		case "25-1":
			Debug.Log ("未実装");
			break;
			
		case "25-2":
			Debug.Log ("未実装");
			break;
			
		case "25-3":
			Debug.Log ("未実装");
			break;
			
		case "25-4":
			Debug.Log ("未実装");
			break;
			
		case "25-5":
			Debug.Log ("未実装");
			break;
			
		case "25-6":
			Debug.Log ("未実装");
			break;
			
		case "25-7":
			Debug.Log ("未実装");
			break;
			
		case "25-8":
			Debug.Log ("未実装");
			break;
			
		case "25-9":
			Debug.Log ("未実装");
			break;
			
		case "25-10":
			Debug.Log ("未実装");
			break;
			
		case "25-11":
			Debug.Log ("未実装");
			break;
			
		case "25-12":
			Debug.Log ("未実装");
			break;
			
		case "25-13":
			Debug.Log ("未実装");
			break;
			
		case "25-14":
			Debug.Log ("未実装");
			break;
			
		case "25-15":
			Debug.Log ("未実装");
			break;
			
		case "25-16":
			Debug.Log ("未実装");
			break;
			
		case "25-17":
			Debug.Log ("未実装");
			break;
			
		case "25-18":
			Debug.Log ("未実装");
			break;
			
		case "25-19":
			Debug.Log ("未実装");
			break;
			
		case "26-1":
			Debug.Log ("未実装");
			break;
			
		case "26-2":
			Debug.Log ("未実装");
			break;
			
		case "26-3":
			Debug.Log ("未実装");
			break;
			
		case "26-4":
			Debug.Log ("未実装");
			break;
			
		case "26-5":
			Debug.Log ("未実装");
			break;
			
		case "26-6":
			Debug.Log ("未実装");
			break;
			
		case "26-7":
			Debug.Log ("未実装");
			break;
			
		case "26-8":
			Debug.Log ("未実装");
			break;
			
		case "26-9":
			Debug.Log ("未実装");
			break;
			
		case "26-10":
			Debug.Log ("未実装");
			break;
			
		case "26-11":
			Debug.Log ("未実装");
			break;
			
		case "26-12":
			Debug.Log ("未実装");
			break;
			
		case "26-13":
			Debug.Log ("未実装");
			break;
			
		case "26-14":
			Debug.Log ("未実装");
			break;
			
		case "26-15":
			Debug.Log ("未実装");
			break;
			
		case "26-16":
			Debug.Log ("未実装");
			break;
			
		case "26-17":
			Debug.Log ("未実装");
			break;
			
		case "26-18":
			Debug.Log ("未実装");
			break;
			
		case "26-19":
			Debug.Log ("未実装");
			break;
			
		case "27-1":
			Debug.Log ("未実装");
			break;
			
		case "27-2":
			Debug.Log ("未実装");
			break;
			
		case "27-3":
			Debug.Log ("未実装");
			break;
			
		case "27-4":
			Debug.Log ("未実装");
			break;
			
		case "27-5":
			Debug.Log ("未実装");
			break;
			
		case "27-6":
			Debug.Log ("未実装");
			break;
			
		case "27-7":
			Debug.Log ("未実装");
			break;
			
		case "27-8":
			Debug.Log ("未実装");
			break;
			
		case "27-9":
			Debug.Log ("未実装");
			break;
			
		case "27-10":
			Debug.Log ("未実装");
			break;
			
		case "27-11":
			Debug.Log ("未実装");
			break;
			
		case "27-12":
			Debug.Log ("未実装");
			break;
			
		case "27-13":
			Debug.Log ("未実装");
			break;
			
		case "27-14":
			Debug.Log ("未実装");
			break;
			
		case "27-15":
			Debug.Log ("未実装");
			break;
			
		case "27-16":
			Debug.Log ("未実装");
			break;
			
		case "27-17":
			Debug.Log ("未実装");
			break;
			
		case "27-18":
			Debug.Log ("未実装");
			break;
			
		case "27-19":
			Debug.Log ("未実装");
			break;
			
		case "28-1":
			Debug.Log ("未実装");
			break;
			
		case "28-2":
			Debug.Log ("未実装");
			break;
			
		case "28-3":
			Debug.Log ("未実装");
			break;
			
		case "28-4":
			Debug.Log ("未実装");
			break;
			
		case "28-5":
			Debug.Log ("未実装");
			break;
			
		case "28-6":
			Debug.Log ("未実装");
			break;
			
		case "28-7":
			Debug.Log ("未実装");
			break;
			
		case "28-8":
			Debug.Log ("未実装");
			break;
			
		case "28-9":
			Debug.Log ("未実装");
			break;
			
		case "28-10":
			Debug.Log ("未実装");
			break;
			
		case "28-11":
			Debug.Log ("未実装");
			break;
			
		case "28-12":
			Debug.Log ("未実装");
			break;
			
		case "28-13":
			Debug.Log ("未実装");
			break;
			
		case "28-14":
			Debug.Log ("未実装");
			break;
			
		case "28-15":
			Debug.Log ("未実装");
			break;
			
		case "28-16":
			Debug.Log ("未実装");
			break;
			
		case "28-17":
			Debug.Log ("未実装");
			break;
			
		case "28-18":
			Debug.Log ("未実装");
			break;
			
		case "28-19":
			Debug.Log ("未実装");
			break;
			
		case "29-1":
			Debug.Log ("未実装");
			break;
			
		case "29-2":
			Debug.Log ("未実装");
			break;
			
		case "29-3":
			Debug.Log ("未実装");
			break;
			
		case "29-4":
			Debug.Log ("未実装");
			break;
			
		case "29-5":
			Debug.Log ("未実装");
			break;
			
		case "30-1":
			Debug.Log ("未実装");
			break;
			
		case "30-2":
			Debug.Log ("未実装");
			break;
			
		case "30-3":
			Debug.Log ("未実装");
			break;
			
		case "30-4":
			Debug.Log ("未実装");
			break;
			
		case "30-5":
			Debug.Log ("未実装");
			break;
			
		case "31-1":
			Debug.Log ("未実装");
			break;
			
		case "31-2":
			Debug.Log ("未実装");
			break;
			
		case "31-3":
			Debug.Log ("未実装");
			break;
			
		case "31-4":
			Debug.Log ("未実装");
			break;
			
		case "31-5":
			Debug.Log ("未実装");
			break;
			
		case "32-1":
			Debug.Log ("未実装");
			break;
			
		case "32-2":
			Debug.Log ("未実装");
			break;
			
		case "32-3":
			Debug.Log ("未実装");
			break;
			
		case "32-4":
			Debug.Log ("未実装");
			break;
			
		case "32-5":
			Debug.Log ("未実装");
			break;
			
		case "33-1":
			Debug.Log ("未実装");
			break;
			
		case "33-2":
			Debug.Log ("未実装");
			break;
			
		case "33-3":
			Debug.Log ("未実装");
			break;
			
		case "33-4":
			Debug.Log ("未実装");
			break;
			
		case "33-5":
			Debug.Log ("未実装");
			break;
			
		case "34-1":
			Debug.Log ("未実装");
			break;
			
		case "34-2":
			Debug.Log ("未実装");
			break;
			
		case "34-3":
			Debug.Log ("未実装");
			break;
			
		case "34-4":
			Debug.Log ("未実装");
			break;
			
		case "34-5":
			Debug.Log ("未実装");
			break;
			
		case "35-1":
			Debug.Log ("未実装");
			break;
			
		case "35-2":
			Debug.Log ("未実装");
			break;
			
		case "35-3":
			Debug.Log ("未実装");
			break;
			
		case "35-4":
			Debug.Log ("未実装");
			break;
			
		case "35-5":
			Debug.Log ("未実装");
			break;
			
		case "36-1":
			Debug.Log ("未実装");
			break;
			
		case "36-2":
			Debug.Log ("未実装");
			break;
			
		case "36-3":
			Debug.Log ("未実装");
			break;
			
		case "36-4":
			Debug.Log ("未実装");
			break;
			
		case "36-5":
			Debug.Log ("未実装");
			break;
			
		case "37-1":
			Debug.Log ("未実装");
			break;
			
		case "37-2":
			Debug.Log ("未実装");
			break;
			
		case "37-3":
			Debug.Log ("未実装");
			break;
			
		case "37-4":
			Debug.Log ("未実装");
			break;
			
		case "37-5":
			Debug.Log ("未実装");
			break;
			
		case "38-1":
			Debug.Log ("未実装");
			break;
			
		case "38-2":
			Debug.Log ("未実装");
			break;
			
		case "38-3":
			Debug.Log ("未実装");
			break;
			
		case "38-4":
			Debug.Log ("未実装");
			break;
			
		case "38-5":
			Debug.Log ("未実装");
			break;
			
		case "39-1":
			Debug.Log ("未実装");
			break;
			
		case "39-2":
			Debug.Log ("未実装");
			break;
			
		case "39-3":
			Debug.Log ("未実装");
			break;
			
		case "40-1":
			Debug.Log ("未実装");
			break;
			
		case "40-2":
			Debug.Log ("未実装");
			break;
			
		case "40-3":
			Debug.Log ("未実装");
			break;
			
		case "41-1":
			Debug.Log ("未実装");
			break;
			
		case "41-2":
			Debug.Log ("未実装");
			break;
			
		case "41-3":
			Debug.Log ("未実装");
			break;
			
		case "42-1":
			Debug.Log ("未実装");
			break;
			
		case "42-2":
			Debug.Log ("未実装");
			break;
			
		case "42-3":
			Debug.Log ("未実装");
			break;
			
		case "43-1":
			Debug.Log ("未実装");
			break;
			
		case "43-2":
			Debug.Log ("未実装");
			break;
			
		case "43-3":
			Debug.Log ("未実装");
			break;
			
		case "44-1":
			Debug.Log ("未実装");
			break;
			
		case "44-2":
			Debug.Log ("未実装");
			break;
			
		case "44-3":
			Debug.Log ("未実装");
			break;
			
		case "45-1":
			Debug.Log ("未実装");
			break;
			
		case "45-2":
			Debug.Log ("未実装");
			break;
			
		case "45-3":
			Debug.Log ("未実装");
			break;
			
		case "46-1":
			Debug.Log ("未実装");
			break;
			
		case "46-2":
			Debug.Log ("未実装");
			break;
			
		case "46-3":
			Debug.Log ("未実装");
			break;
			
		case "47-1":
			Debug.Log ("未実装");
			break;
			
		case "47-2":
			Debug.Log ("未実装");
			break;
			
		case "47-3":
			Debug.Log ("未実装");
			break;
			
		case "48-1":
			Debug.Log ("未実装");
			break;
			
		case "48-2":
			Debug.Log ("未実装");
			break;
			
		case "48-3":
			Debug.Log ("未実装");
			break;
			
		case "101":
			Debug.Log ("未実装");
			break;
			
		case "102":
			Debug.Log ("未実装");
			break;
			
		case "103":
			Debug.Log ("未実装");
			break;
			
		case "104":
			Debug.Log ("未実装");
			break;
			
		case "105":
			Debug.Log ("未実装");
			break;
			
		case "106":
			Debug.Log ("未実装");
			break;
			
		case "107":
			Debug.Log ("未実装");
			break;
			
		case "108":
			Debug.Log ("未実装");
			break;
			
		case "201":
			Debug.Log ("未実装");
			break;
			
		case "202":
			Debug.Log ("未実装");
			break;
			
		case "203":
			Debug.Log ("未実装");
			break;
			
		case "204":
			Debug.Log ("未実装");
			break;
			
		case "301":
			Debug.Log ("未実装");
			break;
			
		case "302":
			Debug.Log ("未実装");
			break;
			
		case "401":
			Debug.Log ("未実装");
			break;
			
		case "402":
			Debug.Log ("未実装");
			break;
			
		case "403":
			Debug.Log ("未実装");
			break;
			
		case "501":
			if(this.back.transform.gameObject.activeSelf){
				this.back.StopAnim ();
				this.back.textureNum = 0;
			}else{
				this.lamp1.StopAnim ();
				this.lamp1.textureNum = 0;
				this.lamp6.StopAnim ();
				this.lamp6.textureNum = 0;
				this.lamp7.StopAnim ();
				this.lamp7.textureNum = 0;
				this.lamp8.StopAnim ();
				this.lamp8.textureNum = 0;
			}
			this.pull11.StopAnim ();
			this.pull11.textureNum = 0;
			this.lampCircle2.StopAnim ();
			this.lampCircle2.textureNum = 0;
			this.lampCircle3.StopAnim ();
			this.lampCircle3.textureNum = 0;

			if(callback != null) callback();
			break;
			
		case "502":
			if(this.back.transform.gameObject.activeSelf){
				this.back.StopAnim ();
				this.back.textureNum = 1;
			}else{
				this.lamp1.StopAnim ();
				this.lamp1.textureNum = 1;
				this.lamp6.StopAnim ();
				this.lamp6.textureNum = 1;
				this.lamp7.StopAnim ();
				this.lamp7.textureNum = 1;
				this.lamp8.StopAnim ();
				this.lamp8.textureNum = 1;
			}
			this.pull11.StopAnim ();
			this.pull11.textureNum = 1;
			this.lampCircle2.StopAnim ();
			this.lampCircle2.textureNum = 1;
			this.lampCircle3.StopAnim ();
			this.lampCircle3.textureNum = 1;
			
			if(callback != null) callback();
			break;
			
		case "503":
			if(this.back.transform.gameObject.activeSelf){
				this.back.PlayAnim (0);
			}else{
				this.lamp1.PlayAnim (0);
				this.lamp6.PlayAnim (0);
				this.lamp7.PlayAnim (0);
				this.lamp8.PlayAnim (0);
			}
			this.pull11.PlayAnim (0);
			this.lampCircle2.PlayAnim (0);
			this.lampCircle3.PlayAnim (0);
			
			if(callback != null) callback();
			break;
			
		case "504":
			if(this.back.transform.gameObject.activeSelf){
				this.back.PlayAnim (1);
			}else{
				this.lamp1.PlayAnim (1);
				this.lamp6.PlayAnim (1);
				this.lamp7.PlayAnim (1);
				this.lamp8.PlayAnim (1);
			}
			this.pull11.PlayAnim (1);
			this.lampCircle2.PlayAnim (1);
			this.lampCircle3.PlayAnim (1);
			
			if(callback != null) callback();
			break;
			
		case "505":
			if(this.back.transform.gameObject.activeSelf){
				this.back.PlayAnim (2);
			}else{
				this.lamp1.PlayAnim (2);
				this.lamp6.PlayAnim (2);
				this.lamp7.PlayAnim (2);
				this.lamp8.PlayAnim (2);
			}
			this.pull11.PlayAnim (2);
			this.lampCircle2.PlayAnim (2);
			this.lampCircle3.PlayAnim (2);
			
			if(callback != null) callback();
			break;

		default:
			errorCode = "指定コードが間違えています";
			Debug.LogWarning ("指定コードが間違えています");
			break;
		}

		return errorCode;
	}

    //----------------------------------------------------------------------------------------------------
#if UNITY_EDITOR
	void OnGUI(){
		GUILayout.Label ("パターンNoを入力（Enterで実行） : " + this.orderCode, GUILayout.Height (Screen.height / 5));
	}
#endif
}
