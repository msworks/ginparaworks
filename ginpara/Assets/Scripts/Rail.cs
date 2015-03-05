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
	private float preAnchorValue = 0;
	private float originValue = 0;
	private bool isRolling = false;

	//====================================================================================================
	// Property
	//====================================================================================================
	public bool IsAnimating { get { return this.railAnimation.isPlaying; } }

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
	private void ResetAnchor(int pictureNum){
		this.anchorValue = this.preAnchorValue = 0;
		for (int i = 0; i < this.railPanels.Length; ++i) {
			this.railPanels [(this.railPanels.Length - 1) - i].Anchor.relativeOffset = new Vector2 ((this.railPanels.Length - 1) - ((this.anchorValue + i + this.originValue) % this.railPanels.Length), 0);
			this.railPanels [(this.railPanels.Length - 1) - i].Reset();
		}
		
		Dictionary<int, Texture> dic = this.pictureManager.Initialize (pictureNum, this.railPanels);
		
		foreach(RailPanel panel in this.railPanels){
			panel.MainTexture = dic[(int)panel.Anchor.relativeOffset.x];
		}
	}
	
	//----------------------------------------------------------------------------------------------------
	void Update(){
		if(this.isRolling){
			this.anchorValue += Time.deltaTime * 32f;
		}
		
		if ((this.anchorValue + this.originValue) != this.preAnchorValue  &&  (this.anchorValue + this.originValue) > this.preAnchorValue) {
			for (int i = 0; i < this.railPanels.Length; ++i) {
				this.railPanels [(this.railPanels.Length - 1) - i].Anchor.relativeOffset = new Vector2 ((this.railPanels.Length - 1) - ((this.anchorValue + i + this.originValue) % this.railPanels.Length), 0);
			}
			this.preAnchorValue = this.anchorValue + this.originValue;
		}
		if(this.isRolling  &&  this.anchorValue > 5f)
			this.anchorValue = this.preAnchorValue = 0;
	}

    //----------------------------------------------------------------------------------------------------
	void Initialize(int pictureNum){
		this.anchorValue = this.preAnchorValue = 0;

		this.railPanels[0].Anchor.relativeOffset = new Vector2(0, 0);
		this.railPanels[1].Anchor.relativeOffset = new Vector2(1, 0);
		this.railPanels[2].Anchor.relativeOffset = new Vector2(2, 0);
		this.railPanels[3].Anchor.relativeOffset = new Vector2(3, 0);
		this.railPanels[4].Anchor.relativeOffset = new Vector2(4, 0);
		this.railPanels[5].Anchor.relativeOffset = new Vector2(5, 0);
		
		Dictionary<int, Texture> dic = this.pictureManager.Initialize (pictureNum, this.railPanels);
		
		foreach(RailPanel panel in this.railPanels){
			panel.MainTexture = dic[(int)panel.Anchor.relativeOffset.x];
		}
		
		Debug.Log (this.gameObject.name+"を"+pictureNum.ToString()+"で初期化");
	}
	
	//----------------------------------------------------------------------------------------------------
	public IEnumerator RailStart(System.Action callback){
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
	public IEnumerator RailStop(int targetNum, System.Action callback){
		while(this.railAnimation.isPlaying){
			yield return null;
		}

		this.ResetAnchor(this.pictureManager.StopStartNum(targetNum));
		this.isRolling = false;
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
	
	//----------------------------------------------------------------------------------------------------
	public IEnumerator RailReach(int targetNum, System.Action callback){
		while(this.railAnimation.isPlaying){
			yield return null;
		}
		
		this.ResetAnchor(targetNum);
		this.isRolling = false;
		this.railAnimation.clip = this.anims[2];
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
	
	//----------------------------------------------------------------------------------------------------
	public IEnumerator RailSuperReach(int targetNum, System.Action callback){
		while(this.railAnimation.isPlaying){
			yield return null;
		}
		
		this.ResetAnchor(targetNum);
		this.isRolling = false;
		this.railAnimation.clip = this.anims[3];
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
	
	//----------------------------------------------------------------------------------------------------
	public IEnumerator RailVitaStop(int moveNum, System.Action callback){
		while(this.railAnimation.isPlaying){
			yield return null;
		}
		
		this.isRolling = false;
		this.railAnimation.clip = this.anims[3 + moveNum];
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
	
	//----------------------------------------------------------------------------------------------------
	public void StartAnime(int pictureNum){
		this.pictureManager.StartAnime (pictureNum);
	}
	
	//----------------------------------------------------------------------------------------------------
	public void ChangeHitPicture(int pictureNum){
		this.pictureManager.ChangeHitPicture(pictureNum);
	}
	
	//----------------------------------------------------------------------------------------------------
	public int[] RecodePanelNum { get { return this.pictureManager.RecodePanelNum; } }
}