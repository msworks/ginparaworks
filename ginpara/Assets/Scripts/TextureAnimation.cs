using UnityEngine;
using System.Collections;

public class TextureAnimation : MonoBehaviour {
	//====================================================================================================
	// Field
	//====================================================================================================
	[SerializeField] private UITexture uiTexture = null;
	[SerializeField] private Texture[] textures = null;
	[SerializeField] private float intervalTime = 0;
	[SerializeField] private float totalTime = 0;
	[SerializeField] private bool isLoop = false;
	private int currentNum = 0;
	private bool isAnimating = false;

	//====================================================================================================
	// Priperty
	//====================================================================================================
	public bool IsAnimating{ get { return this.isAnimating; } }

	//====================================================================================================
	// Method
	//====================================================================================================
	public void Play(System.Action callback){
		this.isAnimating = true;
		StartCoroutine (this.TextureAnimating (callback));
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator TextureAnimating(System.Action callback){
		if(this.textures[this.currentNum] != null) this.uiTexture.mainTexture = this.textures[this.currentNum];
		++this.currentNum;
		float timeElapsed = 0;
		float recodeTime = 0;

		while(timeElapsed < this.totalTime){
			if(timeElapsed - recodeTime > this.intervalTime){
				recodeTime = timeElapsed;
				if(this.textures[this.currentNum] != null) this.uiTexture.mainTexture = this.textures[this.currentNum];
				if((this.textures.Length - 1) > this.currentNum)
					++this.currentNum;
				else if(this.isLoop)
					this.currentNum = 0;
			}
			timeElapsed += Time.deltaTime;
			yield return null;
		}

		this.isAnimating = false;
		if(callback != null) callback();
	}
}
