using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MainLogic : MonoBehaviour {

    // TODO シード値にTickCountってAndroidで取れるか？
    System.Random rnd = new System.Random(Environment.TickCount);

    // 0～65535のランダム値を返す
    int RndFFFF
    {
        get
        {
            return rnd.Next(CHUSEN_LEN);
        }
    }

    // リーチライン構造体
    struct ReachLine
    {
        public int No;         // No
        public int Chusenti;   // 抽選値
        public int ReachLine;  // リーチライン
        public string Tokuzu;  // 枠内停止特図
    }

	PlayMakerFSM fsm;
	string ChackerEvent = "Chacker";

    //--------------------------------------
    // 抽選の方法
    // 65536個の要素からなるテーブルを用意しておき、
    // 配列の添え字を渡すことで抽選を行う
    //--------------------------------------

    // 大当たり抽選テーブル関係
    bool[] NML_Chusen;  // 通常時抽選テーブル
    bool[] KH_Chusen;   // 確変時抽選テーブル
    const int ATARI_NUM = 202;          // 大当たり
    const int HAZURE_NUM = 65334;       // はずれ
    const int KH_ATARI_NUM = 2029;      // 確率変動時大当たり
    const int KH_HAZURE_NUM = 63507;    // 確率変動時はずれ
    const int CHUSEN_LEN = 65536;       // 抽選のサイズ

    // リーチライン抽選テーブル関係
    ReachLine[] RL_Chusen;  // リーチライン抽選テーブル

    // リーチライン抽選リスト
    List<ReachLine> reachLines = new List<ReachLine> {
        new ReachLine{ No= 1, Chusenti=1000, ReachLine=2, Tokuzu="１タコ" },
        new ReachLine{ No= 2, Chusenti=1500, ReachLine=1, Tokuzu="2ハリセンボン/1タコ" },
        new ReachLine{ No= 3, Chusenti=1500, ReachLine=3, Tokuzu="2ハリセンボン/1タコ" },
        new ReachLine{ No= 4, Chusenti=2500, ReachLine=4, Tokuzu="2ハリセンボン/1タコ" },
        new ReachLine{ No= 5, Chusenti=1000, ReachLine=2, Tokuzu="2ハリセンボン" },
        new ReachLine{ No= 6, Chusenti=1500, ReachLine=1, Tokuzu="3カメ/2ハリセンボン" },
        new ReachLine{ No= 7, Chusenti=1500, ReachLine=3, Tokuzu="3カメ/2ハリセンボン" },
        new ReachLine{ No= 8, Chusenti=2500, ReachLine=4, Tokuzu="3カメ/2ハリセンボン" },
        new ReachLine{ No= 9, Chusenti=1000, ReachLine=2, Tokuzu="3カメ" },
        new ReachLine{ No= 10, Chusenti=1500, ReachLine=1, Tokuzu="4サメ/3カメ" },
        new ReachLine{ No= 11, Chusenti=1500, ReachLine=3, Tokuzu="4サメ/3カメ" },
        new ReachLine{ No= 12, Chusenti=3036, ReachLine=4, Tokuzu="4サメ/3カメ" },
        new ReachLine{ No= 13, Chusenti=1000, ReachLine=2, Tokuzu="4サメ" },
        new ReachLine{ No= 14, Chusenti=1500, ReachLine=1, Tokuzu="5エビ/4サメ" },
        new ReachLine{ No= 15, Chusenti=1500, ReachLine=3, Tokuzu="5エビ/4サメ" },
        new ReachLine{ No= 16, Chusenti=2500, ReachLine=4, Tokuzu="5エビ/4サメ" },
        new ReachLine{ No= 17, Chusenti=1000, ReachLine=2, Tokuzu="5エビ" },
        new ReachLine{ No= 18, Chusenti=1500, ReachLine=1, Tokuzu="6アンコウ/5エビ" },
        new ReachLine{ No= 19, Chusenti=1500, ReachLine=3, Tokuzu="6アンコウ/5エビ" },
        new ReachLine{ No= 20, Chusenti=2500, ReachLine=4, Tokuzu="6アンコウ/5エビ" },
        new ReachLine{ No= 21, Chusenti=1000, ReachLine=2, Tokuzu="6アンコウ" },
        new ReachLine{ No= 22, Chusenti=1500, ReachLine=1, Tokuzu="7ジュゴン/6アンコウ" },
        new ReachLine{ No= 23, Chusenti=1500, ReachLine=3, Tokuzu="7ジュゴン/6アンコウ" },
        new ReachLine{ No= 24, Chusenti=2500, ReachLine=4, Tokuzu="7ジュゴン/6アンコウ" },
        new ReachLine{ No= 25, Chusenti=1000, ReachLine=2, Tokuzu="7ジュゴン" },
        new ReachLine{ No= 26, Chusenti=1500, ReachLine=1, Tokuzu="8エンゼルフィッシュ/7ジュゴン" },
        new ReachLine{ No= 27, Chusenti=1500, ReachLine=3, Tokuzu="8エンゼルフィッシュ/7ジュゴン" },
        new ReachLine{ No= 28, Chusenti=2500, ReachLine=4, Tokuzu="8エンゼルフィッシュ/7ジュゴン" },
        new ReachLine{ No= 29, Chusenti=1000, ReachLine=2, Tokuzu="8エンゼルフィッシュ" },
        new ReachLine{ No= 30, Chusenti=1500, ReachLine=1, Tokuzu="9カニ/8エンゼルフィッシュ" },
        new ReachLine{ No= 31, Chusenti=1500, ReachLine=3, Tokuzu="9カニ/8エンゼルフィッシュ" },
        new ReachLine{ No= 32, Chusenti=2500, ReachLine=4, Tokuzu="9カニ/8エンゼルフィッシュ" },
        new ReachLine{ No= 33, Chusenti=1000, ReachLine=2, Tokuzu="9カニ" },
        new ReachLine{ No= 34, Chusenti=1500, ReachLine=1, Tokuzu="10カサゴ/9カニ" },
        new ReachLine{ No= 35, Chusenti=1500, ReachLine=3, Tokuzu="10カサゴ/9カニ" },
        new ReachLine{ No= 36, Chusenti=2500, ReachLine=4, Tokuzu="10カサゴ/9カニ" },
        new ReachLine{ No= 37, Chusenti=1000, ReachLine=2, Tokuzu="10カサゴ" },
        new ReachLine{ No= 38, Chusenti=1500, ReachLine=1, Tokuzu="1タコ/10カサゴ" },
        new ReachLine{ No= 39, Chusenti=1500, ReachLine=3, Tokuzu="1タコ/10カサゴ" },
        new ReachLine{ No= 40, Chusenti=2500, ReachLine=4, Tokuzu="1タコ/10カサゴ" }
    };

    // リーチパターン抽選テーブル関係

    // リーチパターン抽選①②③リスト

	// 初期化
	void Start () {
		fsm = GetComponent<PlayMakerFSM>();

        // 大当たり抽選テーブルの初期化
        var ATARI = Enumerable.Range(0, ATARI_NUM).Select(v => true);
        var HAZURE = Enumerable.Range(0, HAZURE_NUM).Select(v => false);
        var KH_ATARI = Enumerable.Range(0, ATARI_NUM).Select(v => true);
        var KH_HAZURE = Enumerable.Range(0, HAZURE_NUM).Select(v => false);
        NML_Chusen = ATARI.Concat(HAZURE).ToArray();
        KH_Chusen = KH_ATARI.Concat(KH_HAZURE).ToArray();

        // リーチライン抽選テーブルの初期化
        // リーチライン抽選リストを65536個の配列に変換する
        RL_Chusen = reachLines.Select(rl=>RL2Sequence(rl)).SelectMany(rls=>rls).ToArray();
	}
	
    // リーチラインを抽選値の数のリストに変換
    IEnumerable<ReachLine> RL2Sequence(ReachLine rl)
    {
        return Enumerable.Range(0, rl.Chusenti).Select(count => new ReachLine(){
                             No = rl.No,
                             Chusenti = rl.Chusenti,
                             ReachLine = rl.ReachLine,
                             Tokuzu = rl.Tokuzu }
               );
    }

	// チャッカー通過
	public void NoticeChacker(){

        // 大当たり抽選
        var IsKakuhen = false;  // TODO 確変ではないでとりあえず固定

        if (IsAtari(RndFFFF, IsKakuhen))
        {
            // リーチライン抽選
            var rl = DrawLotReachLine(RndFFFF);
            // リーチパターン抽選
            var rp = DrawLotReachPattern(RndFFFF);
        }
        else
        {
            // リーチ抽選
        }
    }

    // 大当たり抽選
    bool IsAtari(int value, bool IsKakuhen)
    {
        var chusen = IsKakuhen ? NML_Chusen : KH_Chusen;
        var isAtari = chusen[value];
        return false;
    }

    // リーチライン抽選（大当たり）
    // 返却値:リーチラインの構造体
    // value:抽選値（ランダム）
    ReachLine DrawLotReachLine(int value)
    {
        return RL_Chusen[value];
    }

    // リーチパターン抽選（大当たり）
    // 返却値：リーチパターンのNO
    // value:抽選値（ランダム）
    int DrawLotReachPattern(int value)
    {
        return -1;
    }


}
