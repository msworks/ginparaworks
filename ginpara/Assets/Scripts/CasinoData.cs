using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CasinoData : MonoBehaviour {

    private string[,] sevenSegSpriteName = new string[,]{
        {"7segR0", "7segR1", "7segR2", "7segR3", "7segR4", "7segR5", "7segR6", "7segR7", "7segR8", "7segR9", "7segNone"},
        {"7segO0", "7segO1", "7segO2", "7segO3", "7segO4", "7segO5", "7segO6", "7segO7", "7segO8", "7segO9", "7segNone"},
        {
            "seg_34px_g_00",
            "seg_34px_g_01",
            "seg_34px_g_02",
            "seg_34px_g_03",
            "seg_34px_g_04",
            "seg_34px_g_05",
            "seg_34px_g_06",
            "seg_34px_g_07",
            "seg_34px_g_08",
            "seg_34px_g_09",
            "seg_34px_g_blank",
        },
//        {"7segG0", "7segG1", "7segG2", "7segG3", "7segG4", "7segG5", "7segG6", "7segG7", "7segG8", "7segG9", "7segNone"},
    };

    
    [SerializeField] private UISprite[] gameCounterSprites = null;
    private int gameCount = 0;
    private enum AVG_STATE
    {
        BB,
        RB,
        ATART
    }
    private AVG_STATE avgState = AVG_STATE.BB;
    [SerializeField] private UISprite onePerLabel = null;
    private string[] onePerSpriteName = new string[]{"1perR", "1perO", "1perG"};
    [SerializeField] private UISprite[] avgSprites = null;
    private int avg = 0;
    [SerializeField] private UISprite exchangeMark = null;
    public enum EXCHANGE
    {
        yen,
        gen,
        euro,
        dl
    }
    private EXCHANGE exchange;
    [SerializeField] private UISprite[] exchangeSprites = null;
    [SerializeField] private UISprite exchangeDotSprites = null;
    private float exchangeNum = 0;
    [SerializeField] private UISprite[] exchangeRateSprites = null;
    [SerializeField] private UISprite exchangeRateDotSprites = null;
    private float exchangeRateNum = 0;
    [SerializeField] private UISprite[] bbSprites = null;
    private int bbNum = 0;
    [SerializeField] private UISprite[] rbSprites = null;
    private int rbNum = 0;
    [SerializeField] private UISprite[] atSprites = null;
    private int atNum = 0;
    [SerializeField] private UISprite[] pre1BbSprites = null;
    private int pre1BbNum = 0;
    [SerializeField] private UISprite[] pre2BbSprites = null;
    private int pre2BbNum = 0;
    [SerializeField] private UISprite[] pre1RbSprites = null;
    private int pre1RbNum = 0;
    [SerializeField] private UISprite[] pre2RbSprites = null;
    private int pre2RbNum = 0;
    [SerializeField] private UISprite[] pre1AtSprites = null;
    private int pre1AtNum = 0;
    [SerializeField] private UISprite[] pre2AtSprites = null;
    private int pre2AtNum = 0;
    [SerializeField] private UISprite[] historySprites = null;
    private List<int> history = new List<int>();
    private string[] historySpriteName = new string[]{"level0", "level1", "level2", "level3", "level4", "level5", "level6", "level7", "level8", "level9"};
    
    //====================================================================================================
    //Property
    //====================================================================================================
    /// UI-ゲームカウンターを操作する.4桁を超える数字は9999に置換して表示.
    public int GameCount { get { return this.gameCount; } set { this.gameCount = (value > 9999) ? 9999 : value; this.UpdateGameCounter(); } }
    
    //----------------------------------------------------------------------------------------------------
    /// UI-AVGを操作する.4桁を超える数字は9999に置換して表示.
    public int AVG { get { return this.avg; } set { this.avg = (value > 9999) ? 9999 : value; this.UpdateAVG(); } }
    
    //----------------------------------------------------------------------------------------------------
    /// UI-BBを操作する.3桁を超える数字は999に置換して表示.
    public int BB { get { return this.bbNum; } set { this.bbNum = (value > 999) ? 999 : value; this.UpdateBB(); } }
    
    //----------------------------------------------------------------------------------------------------
    /// UI-RBを操作する.3桁を超える数字は999に置換して表示.
    public int RB { get { return this.rbNum; } set { this.rbNum = (value > 999) ? 999 : value; this.UpdateRB(); } }
    
    //----------------------------------------------------------------------------------------------------
    /// UI-RBを操作する.3桁を超える数字は999に置換して表示.
//    public int AT { get { return this.atNum; } set { this.atNum = (value > 999) ? 999 : value; this.UpdateAT(); } }
    
    //----------------------------------------------------------------------------------------------------
    /// UI-Exchangeを操作する.5桁を超える数字は99999に置換し,小数点は第1位のみを表示.
    public float Exchange { get { return this.exchangeNum; } set { this.exchangeNum = (value > 999999.99f) ? 999999.99f : value; this.UpdateExchange(); } }
    
    //----------------------------------------------------------------------------------------------------
    /// UI-Exchangeを操作する.2桁を超える数字は99に置換し,小数点は第1位のみを表示.
    public float ExchangeRate { get { return this.exchangeRateNum; } set { this.exchangeRateNum = (value > 99.9f) ? 99.9f : value; this.UpdateExchangeRate(); } }

    static private CasinoData _instance;

    static public CasinoData Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }

    //====================================================================================================
    //Method
    //====================================================================================================
    void Start()
    {
        this.UpdateGameCounter();
        //this.Update1Per();
        this.ChangeExchangeMark(EXCHANGE.dl);
    }

    //----------------------------------------------------------------------------------------------------
	void Update()
	{
        /*
        GameCount += 1;
        AVG += 1;
        ExchangeRate += 0.1f;
        PushDataButton();
        PushDispButton();
         */
        /*
        Exchange += 0.01f;
        BB += 1;
        RB += 1;
         */
        //AT += 1;
        /*
        UpdatePastBB(BB, BB);
        UpdatePastRB(BB, BB);
        */
        //UpdatePastAT(BB, BB);
        /*
        AddHistory(GameCount % 10);
*/
    }

    //----------------------------------------------------------------------------------------------------
    private void UpdateGameCounter()
    {
        string count = string.Empty;
        int digit = this.gameCount.ToString().Length;
        if (digit < 4)
        {
            for(int i = 0; i < (4 - digit); ++i){
                count += "0";
            }
        }
        count += this.gameCount.ToString();
        for (int i = 0; i < 4; ++i)
        {
            if(4 - digit > i)
                this.gameCounterSprites[i].spriteName = this.sevenSegSpriteName[2, 10];
            else
                this.gameCounterSprites[i].spriteName = this.sevenSegSpriteName[2, int.Parse(count[i].ToString())];
        }
    }

    //----------------------------------------------------------------------------------------------------
    private void Update1Per()
    {
        this.onePerLabel.spriteName = this.onePerSpriteName [(int)this.avgState];
    }
    
    //----------------------------------------------------------------------------------------------------
    /// Dataボタン押下時の処理.
    public void PushDataButton()
    {
        if ((int)this.avgState == 2)
            this.avgState = 0;
        else
            ++this.avgState;

        this.Update1Per();
        this.UpdateAVG();
    }
    
    //----------------------------------------------------------------------------------------------------
    private void UpdateAVG()
    {
        string count = string.Empty;
        int digit = this.avg.ToString().Length;
        if (digit < 4)
        {
            for(int i = 0; i < (4 - digit); ++i){
                count += "0";
            }
        }
        count += this.avg.ToString();
        for (int i = 0; i < 4; ++i)
        {
            if(4 - digit > i)
                this.avgSprites[i].spriteName = this.sevenSegSpriteName[(int)this.avgState, 10];
            else
                this.avgSprites[i].spriteName = this.sevenSegSpriteName[(int)this.avgState, int.Parse(count[i].ToString())];
        }
    }

    /// <summary>
    /// 7セグ表示内容を更新
    /// </summary>
    /// <param name="updateSprites"></param>
    /// <param name="num"></param>
    private void Update7Seg(UISprite[] updateSprites, int num)
    {
        var str = string.Format("{0, 3}", num).Reverse();
        var i = 0;
        foreach (var c in str)
        {
            var spriteName = "";
            if (c == ' ')
            {
                spriteName = this.sevenSegSpriteName[2, 10];
            }
            else
            {
                spriteName = this.sevenSegSpriteName[2, int.Parse(c.ToString())];
            }
            updateSprites[i].spriteName = spriteName;

            i++;
        }
    }

    /// <summary>
    /// 大当たり回数
    /// </summary>
    private void UpdateBB()
    {
        Update7Seg(bbSprites, bbNum);
    }

    /// <summary>
    /// 確変回数
    /// </summary>
    private void UpdateRB()
    {
        Update7Seg(rbSprites, rbNum);
    }
    
    /// <summary>
    /// 回転数をシフト
    /// 今回→前回にシフト、前回→前々回にシフト、今回→クリア
    /// </summary>
    public void ShiftKaitensu()
    {
        pre2BbNum = pre1BbNum;
        pre1BbNum = bbNum;
        bbNum = 0;

        pre2RbNum = pre1RbNum;
        pre1RbNum = rbNum;
        rbNum = 0;

        Update7Seg(bbSprites, bbNum);
        Update7Seg(pre1BbSprites, pre1BbNum);
        Update7Seg(pre2BbSprites, pre2BbNum);

        Update7Seg(rbSprites, rbNum);
        Update7Seg(pre1RbSprites, pre1RbNum);
        Update7Seg(pre2RbSprites, pre2RbNum);
    }
    
    public void ChangeExchangeMark(EXCHANGE exchange)
    {
        this.exchangeMark.spriteName = exchange.ToString();
    }
    
    public void PushDispButton()
    {
        if ((int)this.exchange == 3)
            this.exchange = 0;
        else
            ++this.exchange;

        this.exchangeMark.spriteName = this.exchange.ToString();
    }

    /// <summary>
    /// Exchangeを表示
    /// </summary>
    private void UpdateExchange()
    {
        var str = string.Format("{0, 8}", (int)(exchangeNum*100)).Reverse();
        var i = 0;
        foreach (var c in str)
        {
            var spriteName = "";
            if (c == ' ')
            {
                spriteName = this.sevenSegSpriteName[2, 10];
            }
            else
            {
                spriteName = this.sevenSegSpriteName[2, int.Parse(c.ToString())];
            }
            exchangeSprites[i].spriteName = spriteName;

            i++;
        }
    
    }
    
    //----------------------------------------------------------------------------------------------------
    private void UpdateExchangeRate()
    {
        if (this.exchangeRateNum == 0)
        {
            this.exchangeRateSprites [0].spriteName = this.sevenSegSpriteName [2, 10];
            this.exchangeRateSprites [1].spriteName = this.sevenSegSpriteName [2, 10];
            this.exchangeRateSprites [2].spriteName = this.sevenSegSpriteName [2, 10];
            this.exchangeRateDotSprites.color = new Color(1, 1, 1, 0.05f);
        }
        else
        {
            this.exchangeRateDotSprites.color = Color.white;
            if(this.exchangeRateNum < 1){
                this.exchangeRateSprites [0].spriteName = this.sevenSegSpriteName [2, 10];
                this.exchangeRateSprites [1].spriteName = this.sevenSegSpriteName [2, 0];
                this.exchangeRateSprites [2].spriteName = this.sevenSegSpriteName [2, int.Parse(this.exchangeRateNum.ToString()[2].ToString())];
            }else{
                string count = string.Empty;
                bool dot = false;
                foreach(char c in this.exchangeRateNum.ToString()){
                    if(c.ToString() == ".")
                        dot = true;
                }
                int digit = ((int)this.exchangeRateNum).ToString().Length;
                if (digit < 2)
                {
                    for(int i = 0; i < (2 - digit); ++i){
                        count += "0";
                    }
                }
                count += this.exchangeRateNum.ToString();
                if(dot){
                    for (int i = 0; i < 4; ++i)
                    {
                        if(i < 2){
                            if(2 - digit > i)
                                this.exchangeRateSprites[i].spriteName = this.sevenSegSpriteName[2, 10];
                            else
                                this.exchangeRateSprites[i].spriteName = this.sevenSegSpriteName[2, int.Parse(count[i].ToString())];
                        }else if(i == 3){
                            this.exchangeRateSprites[i - 1].spriteName = this.sevenSegSpriteName[2, int.Parse(count[i].ToString())];
                        }
                    }
                }else{
                    for (int i = 0; i < 2; ++i)
                    {
                        if(2 - digit > i)
                            this.exchangeRateSprites[i].spriteName = this.sevenSegSpriteName[2, 10];
                        else{
                            this.exchangeRateSprites[i].spriteName = this.sevenSegSpriteName[2, int.Parse(count[i].ToString())];
                        }
                    }
                    this.exchangeRateSprites [2].spriteName = this.sevenSegSpriteName [2, 0];
                }
            }
        }
    }

    //----------------------------------------------------------------------------------------------------
    /// UI-履歴を追加する.
    public void AddHistory (int num)
    {
        if (num > 9)
            this.history.Add(9);
        else
            this.history.Add(num);

        if (this.history.Count > 10)
            this.history.RemoveAt(0);

        for (int i = 0; i < this.history.Count; ++i)
        {
            this.historySprites[i].spriteName = this.historySpriteName[this.history[i]];
        }
    }

}
