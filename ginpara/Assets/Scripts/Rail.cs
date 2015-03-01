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
	public float anchorValue = 0;
	[SerializeField]private float preAnchorValue = 0;
	private float originValue = 0;
	private bool isRolling = false;

	//====================================================================================================
	// Property
	//====================================================================================================

	//====================================================================================================
	// Method
	//====================================================================================================
	void Start(){
		this.Initialize (1);
	}
	
	//----------------------------------------------------------------------------------------------------
	void Update(){
		if(this.isRolling)
			this.anchorValue += Time.deltaTime * 28f;

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
				StartCoroutine (this.RailStart ());
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
	private IEnumerator RailStart(){
		if(this.railAnimation.isPlaying)
			this.railAnimation.Stop ();

		this.railAnimation.clip = this.anims[0];
		this.originValue = this.anchorValue;
		this.anchorValue = 0;
		this.railAnimation.Play ();
		while(this.railAnimation.isPlaying){
			yield return null;
		}

		this.anchorValue = this.preAnchorValue = (this.anchorValue + this.originValue) % this.railPanels.Length;
		this.originValue = 0;
		this.isRolling = true;
		yield break;
	}
}
