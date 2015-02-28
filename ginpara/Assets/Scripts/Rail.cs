using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rail : MonoBehaviour {
	//====================================================================================================
	// Field
	//====================================================================================================
	[SerializeField] private UITexture[] panelTextures = null;
	[SerializeField] private UIAnchor[] panelAnchors = null;
	public float anchorValue = 0;
	public float preAnchorValue = 0;

	//====================================================================================================
	// Property
	//====================================================================================================

	//====================================================================================================
	// Method
	//====================================================================================================
	void Update(){
		if ((int)this.anchorValue != (int)this.preAnchorValue) {
			for (int i = 0; i < this.panelAnchors.Length; ++i) {
				this.panelAnchors [i].relativeOffset = new Vector2 (4f - ((this.anchorValue + i) % 5), 0);
			}
			this.preAnchorValue = this.anchorValue;
		}
	}
	//セットは5->1


	//====================================================================================================
	// Field
	//====================================================================================================
//    [SerializeField] private float panel = 0;
//    [SerializeField] private Animation railAnimation = null;
//    [SerializeField] private AnimationClip[] anims = null;
//    [SerializeField] private UISprite[] panelSprites = null;
//	
//	[SerializeField] private UITexture[] panelTextures = null;
//	[SerializeField] private Texture[] picture0Textures = null;
//	[SerializeField] private Texture[] picture1Textures = null;
//	[SerializeField] private Texture[] picture2Textures = null;
//	[SerializeField] private Texture[] picture3Textures = null;
//	[SerializeField] private Texture[] picture4Textures = null;
//	[SerializeField] private Texture[] picture5Textures = null;
//	[SerializeField] private Texture[] picture6Textures = null;
//	[SerializeField] private Texture[] picture7Textures = null;
//	[SerializeField] private Texture[] picture8Textures = null;
//	[SerializeField] private Texture[] picture9Textures = null;
//	[SerializeField] private Texture[] picture10Textures = null;
//	private Texture picture0 = null;
//	private Texture picture1 = null;
//	private Texture picture2 = null;
//	private Texture picture3 = null;
//	private Texture picture4 = null;
//	private Texture picture5 = null;
//	private Texture picture6 = null;
//	private Texture picture7 = null;
//	private Texture picture8 = null;
//	private Texture picture9 = null;
//	private Texture picture10 = null;
//	private Texture[] pictureTextures = null;
//	
//    [SerializeField] private UIAnchor[] panelAnchors = null;
//    public float patternAddingValue = 0;
//    private string[] spriteNames = {"b_a", "1_a", "2_a", "3_a", "4_a", "5_a", "6_a", "7_a", "8_a", "9_a", "10_a"};
//    private float pattern = 0;
//    private float prePattern = 0;
//    
//    //====================================================================================================
//    // Property
//    //====================================================================================================
//    /// 左端に位置する図柄を取得
//    public int Pattern { get { return (int)this.pattern; } }
//    
//    //====================================================================================================
//    // Method
//    //====================================================================================================
//    void Start()
//    {
//		this.picture0 = this.picture0Textures[0];
//		this.picture1 = this.picture1Textures[0];
//		this.picture2 = this.picture2Textures[0];
//		this.picture3 = this.picture3Textures[0];
//		this.picture4 = this.picture4Textures[0];
//		this.picture5 = this.picture5Textures[0];
//		this.picture6 = this.picture6Textures[0];
//		this.picture7 = this.picture7Textures[0];
//		this.picture8 = this.picture8Textures[0];
//		this.picture9 = this.picture9Textures[0];
//		this.picture10 = this.picture10Textures[0];
//		this.pictureTextures = new Texture[]{this.picture0, this.picture1, this.picture2, this.picture3, this.picture4, this.picture5, this.picture6, this.picture7, this.picture8, this.picture9, this.picture10};
//        this.SetPattern(1);
//    }
//
//    //----------------------------------------------------------------------------------------------------
//    void Update ()
//	{
//		//TestCode
//		{
////			this.pattern += Time.deltaTime * 30f;
//			this.pattern += 0.05f;
//		}
//
//
//		if (this.patternAddingValue < 0) {
//			this.pattern += Time.deltaTime * 30f;
//		} else if (this.patternAddingValue > 0) {
//		}
//        
//        if (this.pattern < 1)
//        {
//            this.pattern = 11f - (1f - this.pattern);
//        } else if (this.pattern >= 11f)
//        {
//            this.pattern = this.pattern - 10f;
//        }
//        
//        if (this.prePattern != this.pattern) this.panel += (((((this.pattern > this.prePattern) ? (this.pattern - this.prePattern) : ((this.pattern + 10f) - this.prePattern)) * 1000f) % 500f) / 500);
//
//        if (this.panel < 0)
//        {
//            this.panel = 4 - this.panel;
//        } else if (this.panel >= 4)
//        {
//            this.panel = this.panel - 4;
//        }
//
//        this.SetupPanel();
//
//        this.SetupPattern();
//    }
//    
//    //----------------------------------------------------------------------------------------------------
//    /// <para>左端に位置する図柄を指定し,それを基準として表示図柄を設定.</para>
//    /// <para>指定範囲は(1-10)</para>
//    public void SetPattern(int value)
//    {
//        if (value < 1 || value > 10)
//            return;
//
//        this.pattern = this.prePattern = (float)value;
//        this.panelSprites[(int)this.panel].spriteName = this.spriteNames[(int)this.pattern];
//        this.panelSprites[((int)this.panel + 1) > 3 ? (int)this.panel - 3 : (int)this.panel + 1].spriteName = this.spriteNames[0];
//        this.panelSprites[((int)this.panel + 2) > 3 ? (int)this.panel - 2 : (int)this.panel + 2].spriteName = this.spriteNames[(int)this.pattern + 1];
//        this.panelSprites[((int)this.panel + 3) > 3 ? (int)this.panel - 1 : (int)this.panel + 3].spriteName = this.spriteNames[0];
//    }
//    
//    //----------------------------------------------------------------------------------------------------
//    private void SetupPattern ()
//    {
//        if ((int)(this.prePattern * 2) != (int)(this.pattern * 2))
//        {
//            this.panelSprites[((int)this.panel - 1 < 0) ? (int)panel + 3 : (int)this.panel - 1].spriteName = this.spriteNames[((int)(((((int)(this.pattern * 2)) % 2) != 0) ? ((((int)this.pattern + 2) > 10) ? (int)this.pattern - 8 : (int)this.pattern + 2) : 0))];
////            this.panelSprites[(int)this.panel].spriteName = this.spriteNames[((int)(((((int)(this.pattern * 2)) % 2) == 0) ? this.pattern : 0))];
////            this.panelSprites[(int)(((this.panel + 1) > 3) ? (this.panel - 3) : (this.panel + 1))].spriteName = this.spriteNames[((int)(((((int)((this.pattern * 2) + 1)) % 2) == 0) ? (((this.pattern + 1) > 10.5f) ? (this.pattern - 8) : (this.pattern + 1)) : 0))];
////            this.panelSprites[(int)(((this.panel + 2) > 3) ? (this.panel - 2) : (this.panel + 2))].spriteName = this.spriteNames[((int)(((((int)((this.pattern * 2) + 2)) % 2) == 0) ? (((this.pattern + 1) > 10.5f) ? (this.pattern - 8) : (this.pattern + 1)) : 0))];
//        }
//        this.prePattern = this.pattern;
//    }
//    
//    //----------------------------------------------------------------------------------------------------
//    private void SetupPanel ()
//    {
//        this.panelAnchors [0].relativeOffset = new Vector2((this.panel <= 1) ? 0 - this.panel : 4 - this.panel, 0);
//        this.panelAnchors [1].relativeOffset = new Vector2((this.panel <= 2) ? 1 - this.panel : 5 - this.panel, 0);
//        this.panelAnchors [2].relativeOffset = new Vector2((this.panel <= 3) ? 2 - this.panel : 6 - this.panel, 0);
//        this.panelAnchors [3].relativeOffset = new Vector2((this.panel < 4) ? 3 - this.panel : 7 - this.panel, 0);
//    }
}
