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
	[SerializeField] private Rail mediumRail = null;
	[SerializeField] private Rail belowRail = null;
	[SerializeField] private UIAnchor railAreaAnchor = null;
	[SerializeField] private UITexture background = null;
	[SerializeField] private UIAnchor backgroundAnchor = null;
	[SerializeField] private Texture[] backgroundTexture = null;
	[SerializeField] private UIAnchor bubbleNoticeAnchor = null;
	[SerializeField] private UIAnchor shoalNoticeAnchor = null;
	[SerializeField] private UIAnchor coralReefNoticeAnchor = null;
	[SerializeField] private UIAnchor marinNoticeWinAnchor = null;
	[SerializeField] private TextureAnimation marinNoticeWinAnime = null;
	[SerializeField] private UIAnchor marinNoticeLoseAnchor = null;
	[SerializeField] private TextureAnimation marinNoticeLoseAnime = null;
	[SerializeField] private UIAnchor marinShakeHandAnchor = null;
	[SerializeField] private TextureAnimation marinShakeHandAnime = null;
	[SerializeField] private UIAnchor marinBrownAnchor = null;
	[SerializeField] private TextureAnimation marinSBrownAnime = null;
	[SerializeField] private UIAnchor loseBubbleAnchor = null;
	[SerializeField] private TextureAnimation loseBubbleAnime = null;
	[SerializeField] private UIAnchor lostStringAnchor = null;
	[SerializeField] private TextureAnimation lostStringAnime = null;
	[SerializeField] private UIAnchor marinPeaceAnchor = null;
	[SerializeField] private TextureAnimation marinPeaceAnime = null;
	[SerializeField] private TextureAnimation rollBubble = null;
	[SerializeField] private TextureAnimation bonusPicture = null;
	[SerializeField] private UITexture bonusPictureNum = null;
	[SerializeField] private GameObject bonusPictureBase = null;
	[SerializeField] private UITexture bonusRound = null;
	[SerializeField] private UITexture bonusRoundBase = null;
	[SerializeField] private int picturePatternNum = 0;
	[SerializeField] private Texture[] pictureTexture = null;
	[SerializeField] private Texture[] roundtexture = null;
	[SerializeField] private Texture[] numTexture = null;
	private int roundCount = 0;
	[SerializeField] private TextureAnimation marinFinishAnime = null;
	[SerializeField] private UIAnchor marinFinishAnchor = null;
	[SerializeField] private GameObject bonusFinishBackground = null;
	[SerializeField] private GameObject bonusFinishLabel = null;
	private bool isBackgroundLoop = false;
	private float deltaTime = 0;
#if UNITY_EDITOR
	private string orderCode = string.Empty;
#endif
	
	//====================================================================================================
	// Method
	//====================================================================================================
	void Start(){
	}
	
	//----------------------------------------------------------------------------------------------------
	void Update(){
			this.deltaTime = Time.deltaTime;
		if(this.isBackgroundLoop){
			float value = this.backgroundAnchor.relativeOffset.x + (this.deltaTime / 22.5f);
			if(value > 1) value -= 2;
			this.backgroundAnchor.relativeOffset = new Vector2(value, this.backgroundAnchor.relativeOffset.y);
		}
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
	
	//----------------------------------------------------------------------------------------------------
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
			StartCoroutine(this.mediumRail.RailStart(() => {
				if(callback != null) callback();
			}));
			break;

		case "3":
			StartCoroutine(this.belowRail.RailStart(() => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-1":
			StartCoroutine (this.topRail.RailStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-2":
			StartCoroutine (this.topRail.RailStop (-10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-3":
			StartCoroutine (this.topRail.RailStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-4":
			StartCoroutine (this.topRail.RailStop (-9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-5":
			StartCoroutine (this.topRail.RailStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-6":
			StartCoroutine (this.topRail.RailStop (-8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-7":
			StartCoroutine (this.topRail.RailStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-8":
			StartCoroutine (this.topRail.RailStop (-7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-9":
			StartCoroutine (this.topRail.RailStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-10":
			StartCoroutine (this.topRail.RailStop (-6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-11":
			StartCoroutine (this.topRail.RailStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-12":
			StartCoroutine (this.topRail.RailStop (-5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-13":
			StartCoroutine (this.topRail.RailStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-14":
			StartCoroutine (this.topRail.RailStop (-4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-15":
			StartCoroutine (this.topRail.RailStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-16":
			StartCoroutine (this.topRail.RailStop (-3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-17":
			StartCoroutine (this.topRail.RailStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-18":
			StartCoroutine (this.topRail.RailStop (-2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-19":
			StartCoroutine (this.topRail.RailStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "4-20":
			StartCoroutine (this.topRail.RailStop (-1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-1":
			StartCoroutine (this.mediumRail.RailStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-2":
			StartCoroutine (this.mediumRail.RailStop (-1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-3":
			StartCoroutine (this.mediumRail.RailStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-4":
			StartCoroutine (this.mediumRail.RailStop (-2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-5":
			StartCoroutine (this.mediumRail.RailStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-6":
			StartCoroutine (this.mediumRail.RailStop (-3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-7":
			StartCoroutine (this.mediumRail.RailStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-8":
			StartCoroutine (this.mediumRail.RailStop (-4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-9":
			StartCoroutine (this.mediumRail.RailStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-10":
			StartCoroutine (this.mediumRail.RailStop (-5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-11":
			StartCoroutine (this.mediumRail.RailStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-12":
			StartCoroutine (this.mediumRail.RailStop (-6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-13":
			StartCoroutine (this.mediumRail.RailStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-14":
			StartCoroutine (this.mediumRail.RailStop (-7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-15":
			StartCoroutine (this.mediumRail.RailStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-16":
			StartCoroutine (this.mediumRail.RailStop (-8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-17":
			StartCoroutine (this.mediumRail.RailStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-18":
			StartCoroutine (this.mediumRail.RailStop (-9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-19":
			StartCoroutine (this.mediumRail.RailStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "5-20":
			StartCoroutine (this.mediumRail.RailStop (-10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-1":
			StartCoroutine (this.belowRail.RailStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-2":
			StartCoroutine (this.belowRail.RailStop (-1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-3":
			StartCoroutine (this.belowRail.RailStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-4":
			StartCoroutine (this.belowRail.RailStop (-2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-5":
			StartCoroutine (this.belowRail.RailStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-6":
			StartCoroutine (this.belowRail.RailStop (-3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-7":
			StartCoroutine (this.belowRail.RailStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-8":
			StartCoroutine (this.belowRail.RailStop (-4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-9":
			StartCoroutine (this.belowRail.RailStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-10":
			StartCoroutine (this.belowRail.RailStop (-5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-11":
			StartCoroutine (this.belowRail.RailStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-12":
			StartCoroutine (this.belowRail.RailStop (-6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-13":
			StartCoroutine (this.belowRail.RailStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-14":
			StartCoroutine (this.belowRail.RailStop (-7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-15":
			StartCoroutine (this.belowRail.RailStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-16":
			StartCoroutine (this.belowRail.RailStop (-8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-17":
			StartCoroutine (this.belowRail.RailStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-18":
			StartCoroutine (this.belowRail.RailStop (-9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-19":
			StartCoroutine (this.belowRail.RailStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "6-20":
			StartCoroutine (this.belowRail.RailStop (-10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-1":
			StartCoroutine (this.mediumRail.RailReach (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-2":
			StartCoroutine (this.mediumRail.RailReach (-1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-3":
			StartCoroutine (this.mediumRail.RailReach (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-4":
			StartCoroutine (this.mediumRail.RailReach (-2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-5":
			StartCoroutine (this.mediumRail.RailReach (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-6":
			StartCoroutine (this.mediumRail.RailReach (-3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-7":
			StartCoroutine (this.mediumRail.RailReach (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-8":
			StartCoroutine (this.mediumRail.RailReach (-4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-9":
			StartCoroutine (this.mediumRail.RailReach (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-10":
			StartCoroutine (this.mediumRail.RailReach (-5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-11":
			StartCoroutine (this.mediumRail.RailReach (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-12":
			StartCoroutine (this.mediumRail.RailReach (-6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-13":
			StartCoroutine (this.mediumRail.RailReach (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-14":
			StartCoroutine (this.mediumRail.RailReach (-7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-15":
			StartCoroutine (this.mediumRail.RailReach (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-16":
			StartCoroutine (this.mediumRail.RailReach (-8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-17":
			StartCoroutine (this.mediumRail.RailReach (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-18":
			StartCoroutine (this.mediumRail.RailReach (-9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-19":
			StartCoroutine (this.mediumRail.RailReach (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "7-20":
			StartCoroutine (this.mediumRail.RailReach (-10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-1":
			StartCoroutine (this.mediumRail.RailSuperReach (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-2":
			StartCoroutine (this.mediumRail.RailSuperReach (-1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-3":
			StartCoroutine (this.mediumRail.RailSuperReach (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-4":
			StartCoroutine (this.mediumRail.RailSuperReach (-2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-5":
			StartCoroutine (this.mediumRail.RailSuperReach (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-6":
			StartCoroutine (this.mediumRail.RailSuperReach (-3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-7":
			StartCoroutine (this.mediumRail.RailSuperReach (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-8":
			StartCoroutine (this.mediumRail.RailSuperReach (-4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-9":
			StartCoroutine (this.mediumRail.RailSuperReach (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-10":
			StartCoroutine (this.mediumRail.RailSuperReach (-5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-11":
			StartCoroutine (this.mediumRail.RailSuperReach (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-12":
			StartCoroutine (this.mediumRail.RailSuperReach (-6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-13":
			StartCoroutine (this.mediumRail.RailSuperReach (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-14":
			StartCoroutine (this.mediumRail.RailSuperReach (-7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-15":
			StartCoroutine (this.mediumRail.RailSuperReach (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-16":
			StartCoroutine (this.mediumRail.RailSuperReach (-8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-17":
			StartCoroutine (this.mediumRail.RailSuperReach (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-18":
			StartCoroutine (this.mediumRail.RailSuperReach (-9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-19":
			StartCoroutine (this.mediumRail.RailSuperReach (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "8-20":
			StartCoroutine (this.mediumRail.RailSuperReach (-10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "9-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "10-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "11-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "12-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "13-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "14-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "15-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "16-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "17-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "18-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "19-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "20-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "21-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "22-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "23-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "24-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "25-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "26-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "27-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-1":
			StartCoroutine (this.mediumRail.RailVitaStop (1, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-2":
			StartCoroutine (this.mediumRail.RailVitaStop (2, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-3":
			StartCoroutine (this.mediumRail.RailVitaStop (3, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-4":
			StartCoroutine (this.mediumRail.RailVitaStop (4, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-5":
			StartCoroutine (this.mediumRail.RailVitaStop (5, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-6":
			StartCoroutine (this.mediumRail.RailVitaStop (6, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-7":
			StartCoroutine (this.mediumRail.RailVitaStop (7, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-8":
			StartCoroutine (this.mediumRail.RailVitaStop (8, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-9":
			StartCoroutine (this.mediumRail.RailVitaStop (9, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-10":
			StartCoroutine (this.mediumRail.RailVitaStop (10, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-11":
			StartCoroutine (this.mediumRail.RailVitaStop (11, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-12":
			StartCoroutine (this.mediumRail.RailVitaStop (12, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-13":
			StartCoroutine (this.mediumRail.RailVitaStop (13, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-14":
			StartCoroutine (this.mediumRail.RailVitaStop (14, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-15":
			StartCoroutine (this.mediumRail.RailVitaStop (15, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-16":
			StartCoroutine (this.mediumRail.RailVitaStop (16, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-17":
			StartCoroutine (this.mediumRail.RailVitaStop (17, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-18":
			StartCoroutine (this.mediumRail.RailVitaStop (18, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "28-19":
			StartCoroutine (this.mediumRail.RailVitaStop (19, () => {
				if(callback != null) callback();
			}));
			break;
			
		case "29-1":
			this.topRail.StartAnime (1);
			this.mediumRail.StartAnime (1);
			this.belowRail.StartAnime (1);
			break;
			
		case "29-2":
			this.topRail.StartAnime (1);
			this.mediumRail.StartAnime (1);
			this.belowRail.StartAnime (1);
			break;
			
		case "29-3":
			this.topRail.StartAnime (1);
			this.mediumRail.StartAnime (1);
			this.belowRail.StartAnime (1);
			break;
			
		case "29-4":
			this.topRail.StartAnime (1);
			this.mediumRail.StartAnime (1);
			this.belowRail.StartAnime (1);
			break;
			
		case "29-5":
			this.topRail.StartAnime (1);
			this.mediumRail.StartAnime (1);
			this.belowRail.StartAnime (1);
			break;
			
		case "30-1":
			this.topRail.StartAnime (2);
			this.mediumRail.StartAnime (2);
			this.belowRail.StartAnime (2);
			break;
			
		case "30-2":
			this.topRail.StartAnime (2);
			this.mediumRail.StartAnime (2);
			this.belowRail.StartAnime (2);
			break;
			
		case "30-3":
			this.topRail.StartAnime (2);
			this.mediumRail.StartAnime (2);
			this.belowRail.StartAnime (2);
			break;
			
		case "30-4":
			this.topRail.StartAnime (2);
			this.mediumRail.StartAnime (2);
			this.belowRail.StartAnime (2);
			break;
			
		case "30-5":
			this.topRail.StartAnime (2);
			this.mediumRail.StartAnime (2);
			this.belowRail.StartAnime (2);
			break;
			
		case "31-1":
			this.topRail.StartAnime (3);
			this.mediumRail.StartAnime (3);
			this.belowRail.StartAnime (3);
			break;
			
		case "31-2":
			this.topRail.StartAnime (3);
			this.mediumRail.StartAnime (3);
			this.belowRail.StartAnime (3);
			break;
			
		case "31-3":
			this.topRail.StartAnime (3);
			this.mediumRail.StartAnime (3);
			this.belowRail.StartAnime (3);
			break;
			
		case "31-4":
			this.topRail.StartAnime (3);
			this.mediumRail.StartAnime (3);
			this.belowRail.StartAnime (3);
			break;
			
		case "31-5":
			this.topRail.StartAnime (3);
			this.mediumRail.StartAnime (3);
			this.belowRail.StartAnime (3);
			break;
			
		case "32-1":
			this.topRail.StartAnime (4);
			this.mediumRail.StartAnime (4);
			this.belowRail.StartAnime (4);
			break;
			
		case "32-2":
			this.topRail.StartAnime (4);
			this.mediumRail.StartAnime (4);
			this.belowRail.StartAnime (4);
			break;
			
		case "32-3":
			this.topRail.StartAnime (4);
			this.mediumRail.StartAnime (4);
			this.belowRail.StartAnime (4);
			break;
			
		case "32-4":
			this.topRail.StartAnime (4);
			this.mediumRail.StartAnime (4);
			this.belowRail.StartAnime (4);
			break;
			
		case "32-5":
			this.topRail.StartAnime (4);
			this.mediumRail.StartAnime (4);
			this.belowRail.StartAnime (4);
			break;
			
		case "33-1":
			this.topRail.StartAnime (5);
			this.mediumRail.StartAnime (5);
			this.belowRail.StartAnime (5);
			break;
			
		case "33-2":
			this.topRail.StartAnime (5);
			this.mediumRail.StartAnime (5);
			this.belowRail.StartAnime (5);
			break;
			
		case "33-3":
			this.topRail.StartAnime (5);
			this.mediumRail.StartAnime (5);
			this.belowRail.StartAnime (5);
			break;
			
		case "33-4":
			this.topRail.StartAnime (5);
			this.mediumRail.StartAnime (5);
			this.belowRail.StartAnime (5);
			break;
			
		case "33-5":
			this.topRail.StartAnime (5);
			this.mediumRail.StartAnime (5);
			this.belowRail.StartAnime (5);
			break;
			
		case "34-1":
			this.topRail.StartAnime (6);
			this.mediumRail.StartAnime (6);
			this.belowRail.StartAnime (6);
			break;
			
		case "34-2":
			this.topRail.StartAnime (6);
			this.mediumRail.StartAnime (6);
			this.belowRail.StartAnime (6);
			break;
			
		case "34-3":
			this.topRail.StartAnime (6);
			this.mediumRail.StartAnime (6);
			this.belowRail.StartAnime (6);
			break;
			
		case "34-4":
			this.topRail.StartAnime (6);
			this.mediumRail.StartAnime (6);
			this.belowRail.StartAnime (6);
			break;
			
		case "34-5":
			this.topRail.StartAnime (6);
			this.mediumRail.StartAnime (6);
			this.belowRail.StartAnime (6);
			break;
			
		case "35-1":
			this.topRail.StartAnime (7);
			this.mediumRail.StartAnime (7);
			this.belowRail.StartAnime (7);
			break;
			
		case "35-2":
			this.topRail.StartAnime (7);
			this.mediumRail.StartAnime (7);
			this.belowRail.StartAnime (7);
			break;
			
		case "35-3":
			this.topRail.StartAnime (7);
			this.mediumRail.StartAnime (7);
			this.belowRail.StartAnime (7);
			break;
			
		case "35-4":
			this.topRail.StartAnime (7);
			this.mediumRail.StartAnime (7);
			this.belowRail.StartAnime (7);
			break;
			
		case "35-5":
			this.topRail.StartAnime (7);
			this.mediumRail.StartAnime (7);
			this.belowRail.StartAnime (7);
			break;
			
		case "36-1":
			this.topRail.StartAnime (8);
			this.mediumRail.StartAnime (8);
			this.belowRail.StartAnime (8);
			break;
			
		case "36-2":
			this.topRail.StartAnime (8);
			this.mediumRail.StartAnime (8);
			this.belowRail.StartAnime (8);
			break;
			
		case "36-3":
			this.topRail.StartAnime (8);
			this.mediumRail.StartAnime (8);
			this.belowRail.StartAnime (8);
			break;
			
		case "36-4":
			this.topRail.StartAnime (8);
			this.mediumRail.StartAnime (8);
			this.belowRail.StartAnime (8);
			break;
			
		case "36-5":
			this.topRail.StartAnime (8);
			this.mediumRail.StartAnime (8);
			this.belowRail.StartAnime (8);
			break;
			
		case "37-1":
			this.topRail.StartAnime (9);
			this.mediumRail.StartAnime (9);
			this.belowRail.StartAnime (9);
			break;
			
		case "37-2":
			this.topRail.StartAnime (9);
			this.mediumRail.StartAnime (9);
			this.belowRail.StartAnime (9);
			break;
			
		case "37-3":
			this.topRail.StartAnime (9);
			this.mediumRail.StartAnime (9);
			this.belowRail.StartAnime (9);
			break;
			
		case "37-4":
			this.topRail.StartAnime (9);
			this.mediumRail.StartAnime (9);
			this.belowRail.StartAnime (9);
			break;
			
		case "37-5":
			this.topRail.StartAnime (9);
			this.mediumRail.StartAnime (9);
			this.belowRail.StartAnime (9);
			break;
			
		case "38-1":
			this.topRail.StartAnime (10);
			this.mediumRail.StartAnime (10);
			this.belowRail.StartAnime (10);
			break;
			
		case "38-2":
			this.topRail.StartAnime (10);
			this.mediumRail.StartAnime (10);
			this.belowRail.StartAnime (10);
			break;
			
		case "38-3":
			this.topRail.StartAnime (10);
			this.mediumRail.StartAnime (10);
			this.belowRail.StartAnime (10);
			break;
			
		case "38-4":
			this.topRail.StartAnime (10);
			this.mediumRail.StartAnime (10);
			this.belowRail.StartAnime (10);
			break;
			
		case "38-5":
			this.topRail.StartAnime (10);
			this.mediumRail.StartAnime (10);
			this.belowRail.StartAnime (10);
			break;
			
		case "39-1":
			this.topRail.ChangePicture (1, 2);
			break;
			
		case "40-1":
			this.topRail.ChangePicture (2, 2);
			break;
			
		case "41-1":
			this.topRail.ChangePicture (3, 2);
			break;
			
		case "42-1":
			this.topRail.ChangePicture (4, 2);
			break;
			
		case "43-1":
			this.topRail.ChangePicture (5, 2);
			break;
			
		case "44-1":
			this.topRail.ChangePicture (6, 2);
			break;
			
		case "45-1":
			this.topRail.ChangePicture (7, 2);
			break;
			
		case "46-1":
			this.topRail.ChangePicture (8, 2);
			break;
			
		case "47-1":
			this.topRail.ChangePicture (9, 2);
			break;
			
		case "48-1":
			this.topRail.ChangePicture (10, 2);
			break;
			
		case "101":
			this.isBackgroundLoop = true;
			this.background.depth = -1;
			this.backgroundAnchor.relativeOffset = new Vector2(this.backgroundAnchor.relativeOffset.x, 0.5f);
			this.background.mainTexture = this.backgroundTexture[0];
			this.railAreaAnchor.relativeOffset = new Vector2(0, 0);
			if(callback != null) callback();
			break;
			
		case "102":
			this.isBackgroundLoop = true;
			this.background.depth = -1;
			this.backgroundAnchor.relativeOffset = new Vector2(this.backgroundAnchor.relativeOffset.x, 0.5f);
			this.background.mainTexture = this.backgroundTexture[1];
			this.railAreaAnchor.relativeOffset = new Vector2(0, 0);
			if(callback != null) callback();
			break;
			
		case "103":
			this.isBackgroundLoop = true;
			this.background.depth = -1;
			this.backgroundAnchor.relativeOffset = new Vector2(this.backgroundAnchor.relativeOffset.x, 0.5f);
			this.background.mainTexture = this.backgroundTexture[2];
			this.railAreaAnchor.relativeOffset = new Vector2(0, 0);
			if(callback != null) callback();
			break;
			
		case "104":
			this.bubbleNoticeAnchor.transform.gameObject.SetActive (true);
			StartCoroutine (this.BubbleNotice (callback));
			break;
			
		case "105":
			this.shoalNoticeAnchor.transform.gameObject.SetActive (true);
			StartCoroutine (this.ShoalNotice (callback));
			break;
			
		case "106":
			this.coralReefNoticeAnchor.transform.gameObject.SetActive (true);
			StartCoroutine (this.CoralReefNotice (callback));
			break;
			
		case "107":
			this.marinNoticeWinAnchor.transform.gameObject.SetActive(true);
			StartCoroutine (this.MarinNoticeWin(callback));
			break;
			
		case "108":
			this.marinNoticeLoseAnchor.transform.gameObject.SetActive(true);
			StartCoroutine (this.MarinNoticeLose(callback));
			break;
			
		case "201":
			StartCoroutine (this.DisplayUpper (callback));
			break;
			
		case "202":
			this.marinShakeHandAnchor.transform.gameObject.SetActive (true);
			StartCoroutine (this.MarinShakeHand (callback));
			break;
			
		case "203":
			this.marinBrownAnchor.transform.gameObject.SetActive (true);
			this.loseBubbleAnchor.transform.gameObject.SetActive (true);
			StartCoroutine(this.MarinBrown(callback));
			break;
			
		case "204":
			this.lostStringAnchor.transform.gameObject.SetActive (true);
			StartCoroutine(this.LostString(callback));
			break;
			
		case "301":
			this.marinPeaceAnchor.transform.gameObject.SetActive (true);
			StartCoroutine(this.MarinPeace(callback));
			break;
			
		case "302":
			this.rollBubble.transform.gameObject.SetActive (true);
			StartCoroutine(this.RollBubble(callback));
			break;
			
		case "401":
			this.Order ("101", null);
			this.background.depth = 300;
			int[] topNum = this.topRail.RecodePanelNum;
			int[] belowNum = this.belowRail.RecodePanelNum;
			int bonusNum = 0;
			if(topNum[0] == belowNum[0]  &&  topNum[0] != 0)
				bonusNum = topNum[0];
			else if( (topNum[1] == belowNum[1]  &&  topNum[1] != 0)  ||  topNum[0] == belowNum[2]  ||  topNum[2] == belowNum[0] )
				bonusNum = topNum[1];
			else if(topNum[2] == belowNum[2]  &&  topNum[2] != 0)
				bonusNum = topNum[2];


			this.bonusPicture.TextureList.Clear ();
			for(int i = 0; i < this.picturePatternNum; ++i){
				this.bonusPicture.TextureList.Add(this.pictureTexture[( (bonusNum - 1) * this.picturePatternNum) + i]);
			}
			this.bonusPictureNum.mainTexture = this.numTexture[bonusNum - 1];
			this.bonusPicture.transform.gameObject.SetActive(true);
			this.bonusPictureNum.transform.gameObject.SetActive(true);
			this.bonusPictureBase.transform.gameObject.SetActive(true);
			this.bonusRoundBase.transform.gameObject.SetActive(true);
			this.bonusPicture.Play (null);
			Debug.Log ("大当たりUIの準備が完了。ラウンド数を表示・更新するにはorderCode「402」を実行。");
			if(callback != null) callback();
			break;
			
		case "402":
			if(this.roundCount > this.roundtexture.Length - 1){
				Debug.LogError("表示ラウンド数が超過しています！表示ラウンド数を減らすか、テクスチャを追加して下さい。");
				break;
			}
			
			this.bonusRound.mainTexture = this.roundtexture[this.roundCount];
			this.bonusRound.transform.gameObject.SetActive(true);
			this.roundCount = (this.roundCount < this.roundtexture.Length - 1) ? this.roundCount + 1 : 0;
			Debug.Log ("Round ("+this.roundCount+") を表示します。次のRoundを表示する為には、もう一度 orderCode[402] を送信して下さい。");
			if(callback != null) callback();
			break;
			
		case "403":
			this.bonusPicture.transform.gameObject.SetActive (false);
			this.bonusPictureNum.transform.gameObject.SetActive(false);
			this.bonusPictureBase.transform.gameObject.SetActive (false);
			this.bonusRound.transform.gameObject.SetActive(false);
			this.bonusRoundBase.transform.gameObject.SetActive(false);
			
			this.bonusFinishBackground.transform.gameObject.SetActive (true);
			this.bonusFinishLabel.transform.gameObject.SetActive (true);
			this.marinFinishAnime.transform.gameObject.SetActive (true);
			StartCoroutine (this.BonusFinish(callback));
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
	private IEnumerator BubbleNotice(System.Action callback){
		float totalTime = 0;
		while(totalTime < 1f){
			float time = Time.deltaTime;
			totalTime += time;
			float xValue = 0;
			if(totalTime < 0.3f)
				xValue = -0.03f;
			else if(totalTime < 0.7f)
				xValue = -0.14f;
			else
				xValue = -0.03f;
				
			this.bubbleNoticeAnchor.relativeOffset += new Vector2(time * xValue, time * 2f);
			yield return null;
		}
		this.bubbleNoticeAnchor.relativeOffset = new Vector2(0, -1f);
		this.bubbleNoticeAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator ShoalNotice(System.Action callback){
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.shoalNoticeAnchor.relativeOffset -= new Vector2(time * 1.5f, 0);
			yield return null;
		}
		this.shoalNoticeAnchor.relativeOffset = new Vector2(1.5f, 0);
		this.shoalNoticeAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator CoralReefNotice(System.Action callback){
		int[] top = this.topRail.RecodePanelNum;
		int[] below = this.belowRail.RecodePanelNum;
		float anchorX = 0;
		if(top[0] != 0  &&  top[0] == below[0])
			anchorX = -0.333f;
		else if(top[2] != 0  &&  top[2] == below[2])
			anchorX = 0.333f;
		this.coralReefNoticeAnchor.relativeOffset = new Vector2(anchorX, this.coralReefNoticeAnchor.relativeOffset.y);

		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.coralReefNoticeAnchor.relativeOffset += new Vector2(0, time * 0.5f);
			yield return null;
		}

		while(this.mediumRail.IsAnimating)
			yield return null;

		totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.coralReefNoticeAnchor.relativeOffset -= new Vector2(0, time * 0.5f);
			yield return null;
		}

		this.coralReefNoticeAnchor.relativeOffset = new Vector2(0, -1);
		this.coralReefNoticeAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator MarinNoticeWin(System.Action callback){
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.marinNoticeWinAnchor.relativeOffset -= new Vector2(0, time * 1.5f);
			yield return null;
		}
		
		this.marinNoticeWinAnime.Play (null);
		
		while(this.marinNoticeWinAnime.IsAnimating)
			yield return null;
		
		totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.marinNoticeWinAnchor.relativeOffset += new Vector2(0, time * 1.5f);
			yield return null;
		}
		
		this.marinNoticeWinAnchor.relativeOffset = new Vector2(0, 2);
		this.marinNoticeWinAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator MarinNoticeLose(System.Action callback){
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.marinNoticeLoseAnchor.relativeOffset -= new Vector2(0, time * 1.5f);
			yield return null;
		}
		
		this.marinNoticeLoseAnime.Play (null);
		
		while(this.marinNoticeLoseAnime.IsAnimating)
			yield return null;
		
		totalTime = 0;
		while(totalTime < 1f){
			float time = Time.deltaTime;
			totalTime += time;
			this.marinNoticeLoseAnchor.relativeOffset -= new Vector2(0, time);
			yield return null;
		}
		
		this.marinNoticeLoseAnchor.relativeOffset = new Vector2(0, 2);
		this.marinNoticeLoseAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator DisplayUpper(System.Action callback){
		float totalTime = 0;
		while(totalTime < 5f){
			float time = Time.deltaTime;
			totalTime += time;
			float value = this.railAreaAnchor.relativeOffset.y - (this.deltaTime / 5f);
			this.railAreaAnchor.relativeOffset = new Vector2(this.railAreaAnchor.relativeOffset.x ,value);
			yield return null;
		}

		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator MarinShakeHand(System.Action callback){
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.marinShakeHandAnchor.relativeOffset -= new Vector2(0, time * 0.5f);
			yield return null;
		}
		
		this.marinShakeHandAnime.Play (null);
		
		while(this.marinShakeHandAnime.IsAnimating)
			yield return null;
		
		this.marinShakeHandAnchor.relativeOffset = new Vector2(0, 0);
		this.marinShakeHandAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator MarinBrown(System.Action callback){
		this.marinSBrownAnime.Play (null);
		this.loseBubbleAnime.Play (null);
		
		while(this.marinSBrownAnime.IsAnimating  ||  this.loseBubbleAnime.IsAnimating)
			yield return null;
		
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.loseBubbleAnchor.relativeOffset -= new Vector2(0, time * 0.5f);
			this.marinBrownAnchor.relativeOffset -= new Vector2(0, time * 0.5f);
			yield return null;
		}
		
		this.marinBrownAnchor.relativeOffset = new Vector2(0, 0);
		this.loseBubbleAnchor.relativeOffset = new Vector2(0, 0);
		this.loseBubbleAnchor.transform.gameObject.SetActive (false);
		this.marinBrownAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator LostString(System.Action callback){
		this.lostStringAnime.Play (null);
		
		while(this.lostStringAnime.IsAnimating  ||  this.loseBubbleAnime.IsAnimating)
			yield return null;
		
		float totalTime = 0;
		while(totalTime < 2f){
			float time = Time.deltaTime;
			totalTime += time;
			this.lostStringAnchor.relativeOffset -= new Vector2(0, time * 0.5f);
			yield return null;
		}
		
		this.lostStringAnchor.relativeOffset = new Vector2(0, 0);
		this.lostStringAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator MarinPeace(System.Action callback){
		this.marinPeaceAnime.Play (null);
		
		while(this.marinPeaceAnime.IsAnimating  ||  this.loseBubbleAnime.IsAnimating)
			yield return null;
		
		this.marinPeaceAnchor.relativeOffset = new Vector2(0, 0);
		this.marinPeaceAnchor.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator RollBubble(System.Action callback){
		this.rollBubble.Play (null);
		
		while(this.rollBubble.IsAnimating  ||  this.loseBubbleAnime.IsAnimating){
			this.rollBubble.transform.Rotate (0, 0, -90f * this.deltaTime);
			yield return null;
		}
		
		this.rollBubble.transform.localRotation = new Quaternion();
		this.rollBubble.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator BonusFinish(System.Action callback){
		this.marinFinishAnime.Play( ()=> {
			this.marinFinishAnchor.relativeOffset = new Vector2(-0.35f, 0);
			this.marinFinishAnime.transform.gameObject.SetActive (false);
			this.bonusFinishBackground.transform.gameObject.SetActive (false);
			this.bonusFinishLabel.transform.gameObject.SetActive (false);
			if(callback != null) callback();
		});
		
		while(this.marinFinishAnime.IsAnimating){
			this.marinFinishAnchor.relativeOffset += new Vector2(this.deltaTime * 0.35f / 3f, 0);
			yield return null;
		}
	}

	//----------------------------------------------------------------------------------------------------
	#if UNITY_EDITOR
	void OnGUI(){
		GUILayout.Label ("パターンNoを入力（Enterで実行） : " + this.orderCode, GUILayout.Height (Screen.height / 5));
	}
	#endif
}
