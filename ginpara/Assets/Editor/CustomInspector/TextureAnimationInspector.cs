using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(TextureAnimation))]
public class TextureAnimationInspector : Editor {
	//====================================================================================================
	// Field
	//====================================================================================================
	private bool isTextureListOpen = false;
	private int textureListSize = 0;
	
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
		TextureAnimation obj = target as TextureAnimation;
		
		//----------------------------------------------------------------------------------------------------
		//uiTexture
		EditorGUILayout.HelpBox ("アニメーションを行うUITextureを設定", MessageType.None);
		obj.UiTexture = (UITexture)EditorGUILayout.ObjectField ("UITexture", obj.UiTexture, typeof(UITexture), true);
		EditorGUILayout.Space ();
		
		//----------------------------------------------------------------------------------------------------
		//textureList
		EditorGUILayout.HelpBox ("アニメーションさせる画像を設定.ここで設定した順に画像を表示.\n" +
		"項目「アニメーションする画像一覧」左横にある▶をクリックする事で中身を確認", MessageType.None);
		this.isTextureListOpen = EditorGUILayout.Foldout (this.isTextureListOpen, "アニメーションする画像一覧");
		if (this.isTextureListOpen) {
			this.textureListSize = EditorGUILayout.IntField ("画像総数", obj.TextureList.Count);
			
			/* case Array
			if (obj.TextureList.Length > 0) {
				Texture[] temp = new Texture[this.textureListSize];
				obj.TextureList.CopyTo(temp);
				obj.TextureList = new Texture[this.textureListSize];
				temp.CopyTo(obj.TextureList);
			}
			*/

			if (obj.TextureList.Count == 0 || this.textureListSize == 0)
				obj.TextureList = new List<Texture> ();
			
			if (obj.TextureList.Count > this.textureListSize)
				obj.TextureList.RemoveRange (this.textureListSize, obj.TextureList.Count - this.textureListSize);
			
			for (int i = 0; i < this.textureListSize; ++i) {
				if (obj.TextureList.Count == i)
					obj.TextureList.Add (null);
				
				obj.TextureList [i] = (Texture)EditorGUILayout.ObjectField ("画像" + (i + 1).ToString () + "枚目", (obj.TextureList [i] != null) ? obj.TextureList [i] : new Texture (), typeof(Texture), false);
			}
		}
		
		if (GUILayout.Button ("画像一覧に含まれるファイルの名前を確認")) {
			string log = obj.gameObject.name + "には、画像は一枚も設定されていません。";
			
			if (obj.TextureList.Count > 0) {
				log = "【以下、" + obj.gameObject.name + "に設定されている画像一覧】\n";
				for (int i = 0; i < obj.TextureList.Count; ++i) {
					log += (i + 1).ToString () + "枚目：" +( (obj.TextureList[i] != null) ? obj.TextureList [i].name : "(空)" )+ "\n";
				}
			}
			
			Debug.Log (log);
		}
		EditorGUILayout.Space ();
		
		//----------------------------------------------------------------------------------------------------
		//interval Time
		EditorGUILayout.HelpBox ("画像を切替える時間を指定(単位：秒)\n(例)\n１秒間で4枚分、画像を切替えるなら、\n1 / 4 = 0.25\nなので、「0.25」を指定", MessageType.None);
		obj.IntervalTime = EditorGUILayout.FloatField ("切り替え間隔", obj.IntervalTime);
		if (obj.IntervalTime <= 0)
			EditorGUILayout.HelpBox ("切り替え間隔に零以下を設定する事は出来ません！", MessageType.Error);
		EditorGUILayout.Space ();
		
		//----------------------------------------------------------------------------------------------------
		// totalTime
		EditorGUILayout.HelpBox ("アニメーションを表示する時間を指定(単位：秒)\n開始から、此処で指定した時間までアニメーションが行われます\nアニメーションを時間指定で終了させたくない、永久にアニメーションさせたくない場合は「-1」を指定.", MessageType.None);
		obj.TotalTime = EditorGUILayout.FloatField ("アニメーション再生時間", obj.TotalTime);
		if (obj.TotalTime < 0) {
			obj.TotalTime = -1;
			EditorGUILayout.HelpBox("アニメーションを永続再生する場合、基本的に「ループ再生」をチェックして下さい！", MessageType.Info);
		}
		if(obj.TotalTime == 0)
			EditorGUILayout.HelpBox("アニメーション再生時間に零を指定すると、アニメーションされる事無く終了する可能性があります！", MessageType.Warning);
		EditorGUILayout.Space();
		
		//----------------------------------------------------------------------------------------------------
		// isLoop
		EditorGUILayout.HelpBox("アニメーションをループ再生するならば、チェックを付ける", MessageType.None);
		obj.IsLoop = EditorGUILayout.Toggle("ループ再生", obj.IsLoop);
	}
}
