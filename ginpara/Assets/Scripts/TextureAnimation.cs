using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureAnimation : MonoBehaviour {
	//====================================================================================================
	// Field
	//====================================================================================================
	[SerializeField] private UITexture uiTexture = null;
	[SerializeField] private List<Texture> textureList = null;
	[SerializeField] private float intervalTime = 0;
	[SerializeField] private float totalTime = 0;
	[SerializeField] private bool isLoop = false;
	private int currentNum = 0;
	private bool isAnimating = false;

	//====================================================================================================
	// Priperty
	//====================================================================================================
	public bool IsAnimating{ get { return this.isAnimating; } }
	public float IntervalTime { set { this.intervalTime = value; } }
	public float TotalTime { set { this.totalTime = value; } }
	public bool IsLoop { set { this.isLoop = value;} }
	public List<Texture> TextureList { get { return this.textureList; } set { this.textureList = value; } }

	//====================================================================================================
	// Method
	//====================================================================================================
	public void Play(System.Action callback){
		this.isAnimating = true;
		StartCoroutine (this.TextureAnimating (callback));
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator TextureAnimating(System.Action callback){
		if(this.textureList[this.currentNum] != null) this.uiTexture.mainTexture = this.textureList[this.currentNum];
		++this.currentNum;
		float timeElapsed = 0;
		float recodeTime = 0;

		while(timeElapsed < this.totalTime  ||  this.totalTime == -1){
			if(timeElapsed - recodeTime > this.intervalTime){
				recodeTime = timeElapsed;
				if(this.textureList.Count != this.currentNum  &&  this.textureList[this.currentNum] != null) this.uiTexture.mainTexture = this.textureList[this.currentNum];
				if((this.textureList.Count - 1) > this.currentNum)
					++this.currentNum;
				else if(this.isLoop)
					this.currentNum = 0;
			}
			timeElapsed += Time.deltaTime;
			yield return null;
		}

		this.currentNum = 0;
		this.isAnimating = false;
		this.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
}
