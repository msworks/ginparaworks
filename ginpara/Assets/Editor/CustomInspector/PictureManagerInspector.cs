using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(PictureManager))]
public class PictureManagerInspector : Editor {
	//====================================================================================================
	// Field
	//====================================================================================================
	private bool isPicture0Open = false;
	private bool isPicture1Open = false;
	private bool isPicture2Open = false;
	private bool isPicture3Open = false;
	private bool isPicture4Open = false;
	private bool isPicture5Open = false;
	private bool isPicture6Open = false;
	private bool isPicture7Open = false;
	private bool isPicture8Open = false;
	private bool isPicture9Open = false;
	private bool isPicture10Open = false;
	private int picture0Size = 0;
	private int picture1Size = 0;
	private int picture2Size = 0;
	private int picture3Size = 0;
	private int picture4Size = 0;
	private int picture5Size = 0;
	private int picture6Size = 0;
	private int picture7Size = 0;
	private int picture8Size = 0;
	private int picture9Size = 0;
	private int picture10Size = 0;

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
		PictureManager obj = target as PictureManager;
		
		//----------------------------------------------------------------------------------------------------
		// animeIntervalTime
		obj.animeIntervalTime = EditorGUILayout.FloatField("アニメーション間隔時間", obj.animeIntervalTime);
		if(obj.animeIntervalTime < 0)
			obj.animeIntervalTime = 0;
		EditorGUILayout.Space();
		
		//----------------------------------------------------------------------------------------------------
		// pictures
		EditorGUILayout.HelpBox ("アニメーションさせる画像を設定.ここで設定した順に画像を表示.\n" +
		                         "項目「アニメーションする画像一覧」左横にある▶をクリックする事で中身を確認", MessageType.None);
		
		//----------------------------------------------------------------------------------------------------
		// picture0
		this.isPicture0Open = EditorGUILayout.Foldout (this.isPicture0Open, "図柄0");
		if (this.isPicture0Open) {
			this.picture0Size = EditorGUILayout.IntField ("画像総数", obj.picture0.Count);
			
			if (obj.picture0.Count == 0 || this.picture0Size == 0)
				obj.picture0 = new List<Texture>();
			
			if (obj.picture0.Count > this.picture0Size)
				obj.picture0.RemoveRange (this.picture0Size, obj.picture0.Count - this.picture0Size);
			
			for (int i = 0; i < this.picture0Size; ++i) {
				if (obj.picture0.Count == i)
					obj.picture0.Add (null);
				
				obj.picture0 [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.picture0 [i] != null) ? obj.picture0 [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.picture0.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.picture0.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.picture0[i] != null) ? obj.picture0 [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		
		//----------------------------------------------------------------------------------------------------
		// picture1
		this.isPicture1Open = EditorGUILayout.Foldout (this.isPicture1Open, "図柄１");
		if (this.isPicture1Open) {
			this.picture1Size = EditorGUILayout.IntField ("画像総数", obj.picture1.Count);

			if (obj.picture1.Count == 0 || this.picture1Size == 0)
				obj.picture1 = new List<Texture>();
			
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
		this.isPicture2Open = EditorGUILayout.Foldout (this.isPicture2Open, "図柄2");
		if (this.isPicture2Open) {
			this.picture2Size = EditorGUILayout.IntField ("画像総数", obj.picture2.Count);
			
			if (obj.picture2.Count == 0 || this.picture2Size == 0)
				obj.picture2 = new List<Texture>();
			
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
		this.isPicture3Open = EditorGUILayout.Foldout (this.isPicture3Open, "図柄3");
		if (this.isPicture3Open) {
			this.picture3Size = EditorGUILayout.IntField ("画像総数", obj.picture3.Count);
			
			if (obj.picture3.Count == 0 || this.picture3Size == 0)
				obj.picture3 = new List<Texture>();
			
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
		this.isPicture4Open = EditorGUILayout.Foldout (this.isPicture4Open, "図柄4");
		if (this.isPicture4Open) {
			this.picture4Size = EditorGUILayout.IntField ("画像総数", obj.picture4.Count);
			
			if (obj.picture4.Count == 0 || this.picture4Size == 0)
				obj.picture4 = new List<Texture>();
			
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
		this.isPicture5Open = EditorGUILayout.Foldout (this.isPicture5Open, "図柄5");
		if (this.isPicture5Open) {
			this.picture5Size = EditorGUILayout.IntField ("画像総数", obj.picture5.Count);
			
			if (obj.picture5.Count == 0 || this.picture5Size == 0)
				obj.picture5 = new List<Texture>();
			
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
		this.isPicture6Open = EditorGUILayout.Foldout (this.isPicture6Open, "図柄6");
		if (this.isPicture6Open) {
			this.picture6Size = EditorGUILayout.IntField ("画像総数", obj.picture6.Count);
			
			if (obj.picture6.Count == 0 || this.picture6Size == 0)
				obj.picture6 = new List<Texture>();
			
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
		this.isPicture7Open = EditorGUILayout.Foldout (this.isPicture7Open, "図柄7");
		if (this.isPicture7Open) {
			this.picture7Size = EditorGUILayout.IntField ("画像総数", obj.picture7.Count);
			
			if (obj.picture7.Count == 0 || this.picture7Size == 0)
				obj.picture7 = new List<Texture>();
			
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
		this.isPicture8Open = EditorGUILayout.Foldout (this.isPicture8Open, "図柄8");
		if (this.isPicture8Open) {
			this.picture8Size = EditorGUILayout.IntField ("画像総数", obj.picture8.Count);
			
			if (obj.picture8.Count == 0 || this.picture8Size == 0)
				obj.picture8 = new List<Texture>();
			
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
		this.isPicture9Open = EditorGUILayout.Foldout (this.isPicture9Open, "図柄9");
		if (this.isPicture9Open) {
			this.picture9Size = EditorGUILayout.IntField ("画像総数", obj.picture9.Count);
			
			if (obj.picture9.Count == 0 || this.picture9Size == 0)
				obj.picture9 = new List<Texture>();
			
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
		this.isPicture10Open = EditorGUILayout.Foldout (this.isPicture10Open, "図柄１0");
		if (this.isPicture10Open) {
			this.picture10Size = EditorGUILayout.IntField ("画像総数", obj.picture10.Count);
			
			if (obj.picture10.Count == 0 || this.picture10Size == 0)
				obj.picture10 = new List<Texture>();
			
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
	}
}
