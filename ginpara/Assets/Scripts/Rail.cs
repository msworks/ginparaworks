using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rail : MonoBehaviour {
	//====================================================================================================
	// Field
	//====================================================================================================
	[SerializeField] private RailPanel[] railPanels = null;
	[SerializeField] private PictureManager pictureManager = null;
	[SerializeField] private Animation railAnimation = null;
	[SerializeField] private AnimationClip[] anims = null;
	[SerializeField] private UIStretch[] stretchs = null;
	public float anchorValue = 0;
	[SerializeField]private float preAnchorValue = 0;
	private float originValue = 0;
	private int targetNum = 0;
	private bool isRolling = false;
	private bool isStoping = false;
	private System.Action callBack = null;

	//====================================================================================================
	// Property
	//====================================================================================================

	//====================================================================================================
	// Method
	//====================================================================================================
	void Start(){
		this.Initialize (1);
		StartCoroutine (this.ResetStretch ());
	}
	
	//----------------------------------------------------------------------------------------------------
	private IEnumerator ResetStretch(){
		yield return new WaitForSeconds(1);
		foreach(UIStretch str in this.stretchs){
			str.enabled = true;
		}
	}
	
	//----------------------------------------------------------------------------------------------------
	void Update(){
		if(this.targetNum != 0){
			if(this.isStoping  &&  this.targetNum == this.pictureManager.PictureNum  &&  this.anchorValue - (float)((int)this.anchorValue) < 0.3f){
				this.isRolling = false;
				this.isStoping = false;
				StartCoroutine (this.RailStopping(this.targetNum, this.callBack));
			}
		}

		if(this.isRolling){
			this.anchorValue += Time.deltaTime * 14f;
		}

		if ((this.anchorValue + this.originValue) != this.preAnchorValue  &&  (this.anchorValue + this.originValue) > this.preAnchorValue) {
			for (int i = 0; i < this.railPanels.Length; ++i) {
				this.railPanels [(this.railPanels.Length - 1) - i].Anchor.relativeOffset = new Vector2 ((this.railPanels.Length - 1) - ((this.anchorValue + i + this.originValue) % this.railPanels.Length), 0);
			}
			this.preAnchorValue = this.anchorValue + this.originValue;
		}

		if(this.isRolling  &&  this.anchorValue > 4f)
			this.anchorValue = this.preAnchorValue = 0;

		//tes
		{
			if(Input.GetMouseButtonDown(0)){
//				StartCoroutine (this.RailStop (-8, null));
			}
		}
	}

    //----------------------------------------------------------------------------------------------------
	void Initialize(int pictureNum){
		this.anchorValue = this.preAnchorValue = 0;
		for (int i = 0; i < this.railPanels.Length; ++i) {
			this.railPanels [(this.railPanels.Length - 1) - i].Anchor.relativeOffset = new Vector2 ((this.railPanels.Length - 1) - ((this.anchorValue + i) % this.railPanels.Length), 0);
		}

		Dictionary<int, Texture> dic = this.pictureManager.Initialize (pictureNum);

		foreach(RailPanel panel in this.railPanels){
			panel.MainTexture = dic[(int)panel.Anchor.relativeOffset.x];
		}

		Debug.Log (this.gameObject.name+"を"+pictureNum.ToString()+"で初期化");
	}
	
	//----------------------------------------------------------------------------------------------------
	public IEnumerator RailStart(System.Action callback){
//		while(this.railAnimation.isPlaying){
//			yield return null;
//		}
//		
		this.railAnimation.clip = this.anims[0];
		this.originValue = this.anchorValue;
		this.anchorValue = 0;
		this.railAnimation.Play ();
		while(this.railAnimation.isPlaying){
			yield return null;
		}
		this.anchorValue = (this.anchorValue + this.originValue);
		this.originValue = 0;
		this.isRolling = true;
		if(callback != null) callback();
		yield break;
	}
	
	//----------------------------------------------------------------------------------------------------
	public void RailStop(int targetNum, System.Action callback){
		this.callBack = callback;
		this.targetNum = this.pictureManager.StopStartNum(targetNum);
		this.isStoping = true;
	}
	public IEnumerator RailStopping(int targetNum, System.Action callback){
//		while(this.railAnimation.isPlaying){
//			yield return null;
//		}

//		int target = this.pictureManager.StopStartNum(targetNum);
//		while((target != this.pictureManager.PictureNum)  ||  this.anchorValue - (float)((int)this.anchorValue) > 0.3f){
//			yield return null;
//		}
//		this.isRolling = false;
		this.railAnimation.clip = this.anims[1];
		this.originValue = (int)this.anchorValue;
		this.anchorValue = 0;
		this.railAnimation.Play ();
		while(this.railAnimation.isPlaying){
			yield return null;
		}
		
		this.anchorValue = (this.anchorValue + this.originValue);
		this.originValue = 0;
		if(callback != null) callback();
		yield break;
	}
}
