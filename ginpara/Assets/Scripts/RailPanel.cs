using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RailPanel : MonoBehaviour {
	//====================================================================================================
	// Field
	//====================================================================================================
	[SerializeField] private UIAnchor anchorPanel = null;
	[SerializeField] private UITexture texturePanel = null;
	[SerializeField] private PictureManager pictureManager = null;
	private float preAnchorValue = 0;

	//====================================================================================================
	// Property
	//====================================================================================================
	public UIAnchor Anchor { get { return this.anchorPanel; } }
	public Texture MainTexture { set { this.texturePanel.mainTexture = value; } }

	//====================================================================================================
	// Method
	//====================================================================================================
	void Start(){
		this.preAnchorValue = this.anchorPanel.relativeOffset.x;
	}

    //----------------------------------------------------------------------------------------------------
	void Update(){
		float anchorValue = this.anchorPanel.relativeOffset.x;
		if(anchorValue > this.preAnchorValue){
			this.MainTexture = this.pictureManager.GetTexture ();
		}

		this.preAnchorValue = anchorValue;
	}
	
	//----------------------------------------------------------------------------------------------------
	public void SetAnchor(float value){
	}
}
