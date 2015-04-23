using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ヒストリー管理クラス
/// </summary>
public class History : MonoBehaviour {

    public UISprite[] Sprites;
    public UISprite[] LabelSprites;

    private static History _instance;
    public static History Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }

    int[] data = new int[10];

    /// <summary>
    /// 表示中のヒストリーのインデックス（０～９）
    /// </summary>
    int current = 0;

    /// <summary>
    /// データ取得プロパティ
    /// </summary>
    public int[] Data
    {
        get
        {
            return data;
        }
    }

    /// <summary>
    /// 選択中のヒストリーのゲーム数を表示する
    /// </summary>
    public void DisplayGameRound()
    {
        CasinoData.Instance.GameCount = data[current];
    }

    /// <summary>
    /// 表示中のヒストリーをシフトする
    /// </summary>
    /// <param name="index"></param>
    public void ShiftDisplayHistory()
    {
        current++;
        if (current >= 10)
        {
            current = 0;
        }

        DisplayGameRound();

        // シフト時に点滅するようにする
        time = hz;
        sw = false;
    }

    /// <summary>
    /// ヒストリーを右にシフトする
    /// 大当たりしたときにヒストリー１を０に、
    /// ヒストリー２はヒストリー１の値に、
    /// ヒストリー３はヒストリー２の値に、
    /// ということをヒストリー９まで行う。
    /// ヒストリー１０の内容は捨てる
    /// </summary>
    public void Shift()
    {
        for (int i = 8; i > 0; i--)
        {
            data[i + 1] = data[i];
        }
        data[0] = 0;
        DisplayGameRound();
    }

    /// <summary>
    /// ヒストリーを１増加する
    /// </summary>
    public void Add()
    {
        data[0]++;
        DisplayGameRound();
    }

    float time = 0f;
    float hz = 1f / 3f;  // 3Hz
    bool sw = true;

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        time += Time.deltaTime;
        if (time > hz) time -= hz;
        else return;

        //-------------------------------------//
        // 処理を重くしないよう、リターンしておく 
        //-------------------------------------//

        // スイッチをフリップ
        sw = (sw == true) ? false : true;

        for (int i = 0; i < 10; ++i)
        {
            var level = 0;
            var h = Data[i];
            if (h == 0)
            {
                level = 0;
            }
            else
            {
                level = (h - h % 100 + 100) / 100;
            }

            if (level >= 10)
            {
                // 点滅
                if (sw)
                {
                    Sprites[i].GetComponent<UISprite>().spriteName = "level9";
                }
                else
                {
                    Sprites[i].GetComponent<UISprite>().spriteName = "level8";
                }
            }
            else
            {
                // 点灯
                Sprites[i].GetComponent<UISprite>().spriteName = "level" + level.ToString();
            }

            // ラベルを点灯
            if (current == i)
            {
                if (sw)
                {
                    LabelSprites[i].GetComponent<UISprite>().spriteName = "level_num_r_" + string.Format("{0:00}", i + 1);
                }
                else
                {
                    LabelSprites[i].GetComponent<UISprite>().spriteName = "nothing";
                }
            }
            else
            {
                LabelSprites[i].GetComponent<UISprite>().spriteName = "level_num_r_" + string.Format("{0:00}", i + 1);
            }
        }
    }
}
