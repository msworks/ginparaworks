using UnityEngine;
using System.Collections;

public class Rail : MonoBehaviour {
    //====================================================================================================
    // Field
    //====================================================================================================
    [SerializeField] private float panel = 0;
    [SerializeField] private Animation railAnimation = null;
    [SerializeField] private UISprite[] panelSprites = null;
    [SerializeField] private UIAnchor[] panelAnchors = null;
//    [SerializeField] private AnimationClip[] anims = null;
    public float patternAddingValue = 0;
    private string[] spriteNames = {"b_a", "1_a", "2_a", "3_a", "4_a", "5_a", "6_a", "7_a", "8_a", "9_a", "10_a"};
    private float pattern = 0;
    private float prePattern = 0;
    
    //====================================================================================================
    // Property
    //====================================================================================================
    /// 左端に位置する図柄を取得
    public int Pattern { get { return (int)this.pattern; } }
    
    //====================================================================================================
    // Method
    //====================================================================================================
    void Start()
    {
        this.SetPattern(1);
    }

    //----------------------------------------------------------------------------------------------------
    void Update()
    {
        //TestCode
        {
            this.pattern += 0.05f;
        }


        if (this.railAnimation.isPlaying)
            this.pattern += this.patternAddingValue;
        
        if (this.pattern < 1)
        {
            this.pattern = 11f - (1f - this.pattern);
        } else if (this.pattern >= 11f)
        {
            this.pattern = this.pattern - 10f;
        }
        
        if (this.prePattern != this.pattern) this.panel += (((((this.pattern > this.prePattern) ? (this.pattern - this.prePattern) : ((this.pattern + 10f) - this.prePattern)) * 1000f) % 500f) / 500);

        if (this.panel < 0)
        {
            this.panel = 4 - this.panel;
        } else if (this.panel >= 4)
        {
            this.panel = this.panel - 4;
        }

        this.SetupPanel();

        this.SetupPattern();
    }
    
    //----------------------------------------------------------------------------------------------------
    /// <para>左端に位置する図柄を指定し,それを基準として表示図柄を設定.</para>
    /// <para>指定範囲は(1-10)</para>
    public void SetPattern(int value)
    {
        if (value < 1 || value > 10)
            return;

        this.pattern = this.prePattern = (float)value;
        this.panelSprites[(int)this.panel].spriteName = this.spriteNames[(int)this.pattern];
        this.panelSprites[((int)this.panel + 1) > 3 ? (int)this.panel - 3 : (int)this.panel + 1].spriteName = this.spriteNames[0];
        this.panelSprites[((int)this.panel + 2) > 3 ? (int)this.panel - 2 : (int)this.panel + 2].spriteName = this.spriteNames[(int)this.pattern + 1];
        this.panelSprites[((int)this.panel + 3) > 3 ? (int)this.panel - 1 : (int)this.panel + 3].spriteName = this.spriteNames[0];
    }
    
    //----------------------------------------------------------------------------------------------------
    private void SetupPattern ()
    {
        if ((int)(this.prePattern * 2) != (int)(this.pattern * 2))
        {
            this.panelSprites[((int)this.panel - 1 < 0) ? (int)panel + 3 : (int)this.panel - 1].spriteName = this.spriteNames[((int)(((((int)(this.pattern * 2)) % 2) != 0) ? ((((int)this.pattern + 2) > 10) ? (int)this.pattern - 8 : (int)this.pattern + 2) : 0))];
//            this.panelSprites[(int)this.panel].spriteName = this.spriteNames[((int)(((((int)(this.pattern * 2)) % 2) == 0) ? this.pattern : 0))];
//            this.panelSprites[(int)(((this.panel + 1) > 3) ? (this.panel - 3) : (this.panel + 1))].spriteName = this.spriteNames[((int)(((((int)((this.pattern * 2) + 1)) % 2) == 0) ? (((this.pattern + 1) > 10.5f) ? (this.pattern - 8) : (this.pattern + 1)) : 0))];
//            this.panelSprites[(int)(((this.panel + 2) > 3) ? (this.panel - 2) : (this.panel + 2))].spriteName = this.spriteNames[((int)(((((int)((this.pattern * 2) + 2)) % 2) == 0) ? (((this.pattern + 1) > 10.5f) ? (this.pattern - 8) : (this.pattern + 1)) : 0))];
        }
        this.prePattern = this.pattern;
    }
    
    //----------------------------------------------------------------------------------------------------
    private void SetupPanel ()
    {
        this.panelAnchors [0].relativeOffset = new Vector2((this.panel <= 1) ? 0 - this.panel : 4 - this.panel, 0);
        this.panelAnchors [1].relativeOffset = new Vector2((this.panel <= 2) ? 1 - this.panel : 5 - this.panel, 0);
        this.panelAnchors [2].relativeOffset = new Vector2((this.panel <= 3) ? 2 - this.panel : 6 - this.panel, 0);
        this.panelAnchors [3].relativeOffset = new Vector2((this.panel < 4) ? 3 - this.panel : 7 - this.panel, 0);
    }
}
