using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(GinparaManager))]
public class GinparaManagerInspector : Editor {
	//====================================================================================================
	// Field
	//====================================================================================================
	private bool isPicture1Open = false;
	private int picture1Size = 0;
	private bool isPicture2Open = false;
	private int picture2Size = 0;
	private bool isPicture3Open = false;
	private int picture3Size = 0;
	private bool isPicture4Open = false;
	private int picture4Size = 0;
	private bool isPicture5Open = false;
	private int picture5Size = 0;
	private bool isPicture6Open = false;
	private int picture6Size = 0;
	private bool isPicture7Open = false;
	private int picture7Size = 0;
	private bool isPicture8Open = false;
	private int picture8Size = 0;
	private bool isPicture9Open = false;
	private int picture9Size = 0;
	private bool isPicture10Open = false;
	private int picture10Size = 0;
	private bool isRoundTextureOpen = false;
	private bool isNumTextureOpen = false;
	
	//====================================================================================================
	// Method
	//====================================================================================================
	public override void OnInspectorGUI(){
		serializedObject.Update();
		this.DrowInspector();
		serializedObject.ApplyModifiedProperties();
	}
	
	//====================================================================================================
	// Custom Inspector
	//====================================================================================================
	private void DrowInspector ()
	{
		GinparaManager obj = target as GinparaManager;
		
		//----------------------------------------------------------------------------------------------------
		// backgroundTexture
		EditorGUILayout.HelpBox("背景画像一覧",MessageType.None);
		obj.backgroundTexture[0] = (Texture) EditorGUILayout.ObjectField("通常背景", obj.backgroundTexture[0], typeof(Texture), false);
		obj.backgroundTexture[1] = (Texture) EditorGUILayout.ObjectField("SP背景", obj.backgroundTexture[1], typeof(Texture), false);
		obj.backgroundTexture[2] = (Texture) EditorGUILayout.ObjectField("確変背景", obj.backgroundTexture[2], typeof(Texture), false);
		EditorGUILayout.Space();
		
		//----------------------------------------------------------------------------------------------------
		// bonus Picture
		EditorGUILayout.HelpBox ("ボーナス中に表示する図柄のアニメーション画像を設定.\n"
								+"ここで設定した順にアニメーション.\n"
		                         +"各図柄項目の左横にある▶をクリックする事で中身を確認.", MessageType.None);
		
		//----------------------------------------------------------------------------------------------------
		// picture1
		this.isPicture1Open = EditorGUILayout.Foldout (this.isPicture1Open, "１図柄アニメーション画像");
		if (this.isPicture1Open) {
			this.picture1Size = EditorGUILayout.IntField ("画像総数", obj.picture1.Count);
			
			if (obj.picture1.Count == 0 || this.picture1Size == 0)
				obj.picture1 = new List<Texture> ();
			
			if (obj.picture1.Count > this.picture1Size)
				obj.picture1.RemoveRange (this.picture1Size, obj.picture1.Count - this.picture1Size);
			
			for (int i = 0; i < this.picture1Size; ++i) {
				if (obj.picture1.Count == i)
					obj.picture1.Add (null);
				
				obj.picture1 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture1 [i] != null) ? obj.picture1 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture1.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture1.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture1[i] != null) ? obj.picture1 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		//----------------------------------------------------------------------------------------------------
		// picture2
		this.isPicture2Open = EditorGUILayout.Foldout (this.isPicture2Open, "2図柄アニメーション画像");
		if (this.isPicture2Open) {
			this.picture2Size = EditorGUILayout.IntField ("画像総数", obj.picture2.Count);
			
			if (obj.picture2.Count == 0 || this.picture2Size == 0)
				obj.picture2 = new List<Texture> ();
			
			if (obj.picture2.Count > this.picture2Size)
				obj.picture2.RemoveRange (this.picture2Size, obj.picture2.Count - this.picture2Size);
			
			for (int i = 0; i < this.picture2Size; ++i) {
				if (obj.picture2.Count == i)
					obj.picture2.Add (null);
				
				obj.picture2 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture2 [i] != null) ? obj.picture2 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture2.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture2.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture2[i] != null) ? obj.picture2 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		//----------------------------------------------------------------------------------------------------
		// picture3
		this.isPicture3Open = EditorGUILayout.Foldout (this.isPicture3Open, "3図柄アニメーション画像");
		if (this.isPicture3Open) {
			this.picture3Size = EditorGUILayout.IntField ("画像総数", obj.picture3.Count);
			
			if (obj.picture3.Count == 0 || this.picture3Size == 0)
				obj.picture3 = new List<Texture> ();
			
			if (obj.picture3.Count > this.picture3Size)
				obj.picture3.RemoveRange (this.picture3Size, obj.picture3.Count - this.picture3Size);
			
			for (int i = 0; i < this.picture3Size; ++i) {
				if (obj.picture3.Count == i)
					obj.picture3.Add (null);
				
				obj.picture3 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture3 [i] != null) ? obj.picture3 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture3.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture3.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture3[i] != null) ? obj.picture3 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		//----------------------------------------------------------------------------------------------------
		// picture4
		this.isPicture4Open = EditorGUILayout.Foldout (this.isPicture4Open, "4図柄アニメーション画像");
		if (this.isPicture4Open) {
			this.picture4Size = EditorGUILayout.IntField ("画像総数", obj.picture4.Count);
			
			if (obj.picture4.Count == 0 || this.picture4Size == 0)
				obj.picture4 = new List<Texture> ();
			
			if (obj.picture4.Count > this.picture4Size)
				obj.picture4.RemoveRange (this.picture4Size, obj.picture4.Count - this.picture4Size);
			
			for (int i = 0; i < this.picture4Size; ++i) {
				if (obj.picture4.Count == i)
					obj.picture4.Add (null);
				
				obj.picture4 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture4 [i] != null) ? obj.picture4 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture4.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture4.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture4[i] != null) ? obj.picture4 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		//----------------------------------------------------------------------------------------------------
		// picture5
		this.isPicture5Open = EditorGUILayout.Foldout (this.isPicture5Open, "5図柄アニメーション画像");
		if (this.isPicture5Open) {
			this.picture5Size = EditorGUILayout.IntField ("画像総数", obj.picture5.Count);
			
			if (obj.picture5.Count == 0 || this.picture5Size == 0)
				obj.picture5 = new List<Texture> ();
			
			if (obj.picture5.Count > this.picture5Size)
				obj.picture5.RemoveRange (this.picture5Size, obj.picture5.Count - this.picture5Size);
			
			for (int i = 0; i < this.picture5Size; ++i) {
				if (obj.picture5.Count == i)
					obj.picture5.Add (null);
				
				obj.picture5 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture5 [i] != null) ? obj.picture5 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture5.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture5.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture5[i] != null) ? obj.picture5 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		//----------------------------------------------------------------------------------------------------
		// picture6
		this.isPicture6Open = EditorGUILayout.Foldout (this.isPicture6Open, "6図柄アニメーション画像");
		if (this.isPicture6Open) {
			this.picture6Size = EditorGUILayout.IntField ("画像総数", obj.picture6.Count);
			
			if (obj.picture6.Count == 0 || this.picture6Size == 0)
				obj.picture6 = new List<Texture> ();
			
			if (obj.picture6.Count > this.picture6Size)
				obj.picture6.RemoveRange (this.picture6Size, obj.picture6.Count - this.picture6Size);
			
			for (int i = 0; i < this.picture6Size; ++i) {
				if (obj.picture6.Count == i)
					obj.picture6.Add (null);
				
				obj.picture6 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture6 [i] != null) ? obj.picture6 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture6.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture6.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture6[i] != null) ? obj.picture6 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		//----------------------------------------------------------------------------------------------------
		// picture7
		this.isPicture7Open = EditorGUILayout.Foldout (this.isPicture7Open, "7図柄アニメーション画像");
		if (this.isPicture7Open) {
			this.picture7Size = EditorGUILayout.IntField ("画像総数", obj.picture7.Count);
			
			if (obj.picture7.Count == 0 || this.picture7Size == 0)
				obj.picture7 = new List<Texture> ();
			
			if (obj.picture7.Count > this.picture7Size)
				obj.picture7.RemoveRange (this.picture7Size, obj.picture7.Count - this.picture7Size);
			
			for (int i = 0; i < this.picture7Size; ++i) {
				if (obj.picture7.Count == i)
					obj.picture7.Add (null);
				
				obj.picture7 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture7 [i] != null) ? obj.picture7 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture7.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture7.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture7[i] != null) ? obj.picture7 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		//----------------------------------------------------------------------------------------------------
		// picture8
		this.isPicture8Open = EditorGUILayout.Foldout (this.isPicture8Open, "8図柄アニメーション画像");
		if (this.isPicture8Open) {
			this.picture8Size = EditorGUILayout.IntField ("画像総数", obj.picture8.Count);
			
			if (obj.picture8.Count == 0 || this.picture8Size == 0)
				obj.picture8 = new List<Texture> ();
			
			if (obj.picture8.Count > this.picture8Size)
				obj.picture8.RemoveRange (this.picture8Size, obj.picture8.Count - this.picture8Size);
			
			for (int i = 0; i < this.picture8Size; ++i) {
				if (obj.picture8.Count == i)
					obj.picture8.Add (null);
				
				obj.picture8 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture8 [i] != null) ? obj.picture8 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture8.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture8.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture8[i] != null) ? obj.picture8 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		//----------------------------------------------------------------------------------------------------
		// picture9
		this.isPicture9Open = EditorGUILayout.Foldout (this.isPicture9Open, "9図柄アニメーション画像");
		if (this.isPicture9Open) {
			this.picture9Size = EditorGUILayout.IntField ("画像総数", obj.picture9.Count);
			
			if (obj.picture9.Count == 0 || this.picture9Size == 0)
				obj.picture9 = new List<Texture> ();
			
			if (obj.picture9.Count > this.picture9Size)
				obj.picture9.RemoveRange (this.picture9Size, obj.picture9.Count - this.picture9Size);
			
			for (int i = 0; i < this.picture9Size; ++i) {
				if (obj.picture9.Count == i)
					obj.picture9.Add (null);
				
				obj.picture9 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture9 [i] != null) ? obj.picture9 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture9.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture9.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture9[i] != null) ? obj.picture9 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		//----------------------------------------------------------------------------------------------------
		// picture10
		this.isPicture10Open = EditorGUILayout.Foldout (this.isPicture10Open, "10図柄アニメーション画像");
		if (this.isPicture10Open) {
			this.picture10Size = EditorGUILayout.IntField ("画像総数", obj.picture10.Count);
			
			if (obj.picture10.Count == 0 || this.picture10Size == 0)
				obj.picture10 = new List<Texture> ();
			
			if (obj.picture10.Count > this.picture10Size)
				obj.picture10.RemoveRange (this.picture10Size, obj.picture10.Count - this.picture10Size);
			
			for (int i = 0; i < this.picture10Size; ++i) {
				if (obj.picture10.Count == i)
					obj.picture10.Add (null);
				
				obj.picture10 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture10 [i] != null) ? obj.picture10 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture10.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture10.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture10[i] != null) ? obj.picture10 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}

		EditorGUILayout.Space ();
		
		//----------------------------------------------------------------------------------------------------
		// roundTexture
		this.isRoundTextureOpen = EditorGUILayout.Foldout (this.isRoundTextureOpen, "ボーナス中のRound表記画像");
		if (this.isRoundTextureOpen) {
			if (obj.roundtexture.Length < 16){
				Texture[] temp = new Texture[16];
				obj.roundtexture.CopyTo(temp, 0);
				obj.roundtexture = new Texture[16];
				temp.CopyTo (obj.roundtexture, 0);
			}
			
			for (int i = 0; i < 16; ++i) {
				obj.roundtexture [i] = (Texture)EditorGUILayout.ObjectField ((i + 1).ToString () + "Round", (obj.roundtexture [i] != null) ? obj.roundtexture [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.roundtexture.Length > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.roundtexture.Length; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.roundtexture[i] != null) ? obj.roundtexture [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		EditorGUILayout.Space ();
		
		//----------------------------------------------------------------------------------------------------
		// numTexture
		this.isNumTextureOpen = EditorGUILayout.Foldout (this.isNumTextureOpen, "ボーナス中の図柄に被せる数字の画像一覧");
		if (this.isNumTextureOpen) {
			if (obj.numTexture.Length < 10){
				Texture[] temp = new Texture[10];
				obj.numTexture.CopyTo(temp, 0);
				obj.numTexture = new Texture[10];
				temp.CopyTo (obj.numTexture, 0);
			}
			
			for (int i = 0; i < 10; ++i) {
				obj.numTexture [i] = (Texture)EditorGUILayout.ObjectField ("図柄"+(i + 1).ToString (), (obj.numTexture [i] != null) ? obj.numTexture [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.numTexture.Length > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.numTexture.Length; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.numTexture[i] != null) ? obj.numTexture [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		EditorGUILayout.Space ();

		
		//----------------------------------------------------------------------------------------------------
		EditorGUILayout.HelpBox("基本的に以下の項目は変更しない！", MessageType.Warning);
		obj.back = (UITextureManager) EditorGUILayout.ObjectField("back", obj.back, typeof(UITextureManager), true);
		obj.lamp1 = (UITextureManager) EditorGUILayout.ObjectField("lamp1", obj.lamp1, typeof(UITextureManager), true);
		obj.lamp6 = (UITextureManager) EditorGUILayout.ObjectField("lamp6", obj.lamp6, typeof(UITextureManager), true);
		obj.lamp7 = (UITextureManager) EditorGUILayout.ObjectField("lamp7", obj.lamp7, typeof(UITextureManager), true);
		obj.lamp8 = (UITextureManager) EditorGUILayout.ObjectField("lamp8", obj.lamp8, typeof(UITextureManager), true);
		obj.lampCircle2 = (UITextureManager) EditorGUILayout.ObjectField("lampCircle2", obj.lampCircle2, typeof(UITextureManager), true);
		obj.lampCircle3 = (UITextureManager) EditorGUILayout.ObjectField("lampCircle3", obj.lampCircle3, typeof(UITextureManager), true);
		obj.topRail = (Rail) EditorGUILayout.ObjectField("topRail", obj.topRail, typeof(Rail), true);
		obj.mediumRail = (Rail) EditorGUILayout.ObjectField("mediumRail", obj.mediumRail, typeof(Rail), true);
		obj.belowRail = (Rail) EditorGUILayout.ObjectField("belowRail", obj.belowRail, typeof(Rail), true);
		obj.railAreaAnchor = (UIAnchor) EditorGUILayout.ObjectField("railAreaAnchor", obj.railAreaAnchor, typeof(UIAnchor), true);
		obj.background = (UITexture) EditorGUILayout.ObjectField("background", obj.background, typeof(UITexture), true);
		obj.backgroundAnchor = (UIAnchor) EditorGUILayout.ObjectField("backgroundAnchor", obj.backgroundAnchor, typeof(UIAnchor), true);
		obj.bubbleNoticeAnchor = (UIAnchor) EditorGUILayout.ObjectField("bubbleNoticeAnchor", obj.bubbleNoticeAnchor, typeof(UIAnchor), true);
		obj.coralReefNoticeAnchor = (UIAnchor) EditorGUILayout.ObjectField("coralReefNoticeAnchor", obj.coralReefNoticeAnchor, typeof(UIAnchor), true);
		obj.marinNoticeCallAnchor = (UIAnchor) EditorGUILayout.ObjectField("marinNoticeCallAnchor", obj.marinNoticeCallAnchor, typeof(UIAnchor), true);
		obj.marinNoticeCallAnime = (TextureAnimation) EditorGUILayout.ObjectField("marinNoticeCallAnime", obj.marinNoticeCallAnime, typeof(TextureAnimation), true);
		obj.marinNoticeWinAnchor = (UIAnchor) EditorGUILayout.ObjectField("marinNoticeWinAnchor", obj.marinNoticeWinAnchor, typeof(UIAnchor), true);
		obj.marinNoticeWinAnime = (TextureAnimation) EditorGUILayout.ObjectField("marinNoticeWinAnime", obj.marinNoticeWinAnime, typeof(TextureAnimation), true);
		obj.marinNoticeLoseAnchor = (UIAnchor) EditorGUILayout.ObjectField("marinNoticeLoseAnchor", obj.marinNoticeLoseAnchor, typeof(UIAnchor), true);
		obj.marinNoticeLoseAnime = (TextureAnimation) EditorGUILayout.ObjectField("marinNoticeLoseAnime", obj.marinNoticeLoseAnime, typeof(TextureAnimation), true);
		obj.marinShakeHandAnchor = (UIAnchor) EditorGUILayout.ObjectField("marinShakeHandAnchor", obj.marinShakeHandAnchor, typeof(UIAnchor), true);
		obj.marinShakeHandAnime = (TextureAnimation) EditorGUILayout.ObjectField("marinShakeHandAnime", obj.marinShakeHandAnime, typeof(TextureAnimation), true);
		obj.marinBrownAnchor = (UIAnchor) EditorGUILayout.ObjectField("marinBrownAnchor", obj.marinBrownAnchor, typeof(UIAnchor), true);
		obj.marinSBrownAnime = (TextureAnimation) EditorGUILayout.ObjectField("marinBrownAnime", obj.marinSBrownAnime, typeof(TextureAnimation), true);
		obj.loseBubbleAnchor = (UIAnchor) EditorGUILayout.ObjectField("loseBubbleAnchor", obj.loseBubbleAnchor, typeof(UIAnchor), true);
		obj.loseBubbleAnime = (TextureAnimation) EditorGUILayout.ObjectField("loseBubbleAnime", obj.loseBubbleAnime, typeof(TextureAnimation), true);
		obj.lostStringAnchor = (UIAnchor) EditorGUILayout.ObjectField("lostStringAnchor", obj.lostStringAnchor, typeof(UIAnchor), true);
		obj.lostStringAnime = (TextureAnimation) EditorGUILayout.ObjectField("lostStringAnime", obj.lostStringAnime, typeof(TextureAnimation), true);
		obj.luckyStringAnime = (TextureAnimation) EditorGUILayout.ObjectField("lockyStringAnime", obj.luckyStringAnime, typeof(TextureAnimation), true);
		obj.marinPeaceAnchor = (UIAnchor) EditorGUILayout.ObjectField("marinPeaceAnchor", obj.marinPeaceAnchor, typeof(UIAnchor), true);
		obj.marinPeaceAnime = (TextureAnimation) EditorGUILayout.ObjectField("marinPeaceAnime", obj.marinPeaceAnime, typeof(TextureAnimation), true);
		obj.rollBubble = (TextureAnimation) EditorGUILayout.ObjectField("rollBubble", obj.rollBubble, typeof(TextureAnimation), true);
		obj.bonusPicture = (TextureAnimation) EditorGUILayout.ObjectField("bonusPicture", obj.bonusPicture, typeof(TextureAnimation), true);
		obj.bonusPictureNum = (UITexture) EditorGUILayout.ObjectField("bonusPictureNum", obj.bonusPictureNum, typeof(UITexture), true);
		obj.bonusPictureBase = (GameObject) EditorGUILayout.ObjectField("bonusPictureBase", obj.bonusPictureBase, typeof(GameObject), true);
		obj.bonusRound = (UITexture) EditorGUILayout.ObjectField("bonusRound", obj.bonusRound, typeof(UITexture), true);
		obj.bonusRoundBase = (UITexture) EditorGUILayout.ObjectField("bonusRoundBase", obj.bonusRoundBase, typeof(UITexture), true);
		obj.marinFinishAnchor = (UIAnchor) EditorGUILayout.ObjectField("marinFinishAnchor", obj.marinFinishAnchor, typeof(UIAnchor), true);
		obj.marinFinishAnime = (TextureAnimation) EditorGUILayout.ObjectField("marinFinishAnime", obj.marinFinishAnime, typeof(TextureAnimation), true);
		obj.bonusFinishBackground = (GameObject) EditorGUILayout.ObjectField("bonusFinishBackground", obj.bonusFinishBackground, typeof(GameObject), true);
		obj.bonusFinishLabel = (GameObject) EditorGUILayout.ObjectField("bonusFinishLabel", obj.bonusFinishLabel, typeof(GameObject), true);
	}
}
