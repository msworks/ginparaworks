﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MainLogic : MonoBehaviour {

    // 保留オブジェクト
    public GameObject Horyu;
    const string ThroughChacker = "チャッカー通過";

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
    struct structReachLine
    {
        public int No;         // No
        public int Chusenti;   // 抽選値
        public int ReachLine;  // リーチライン
        public string Tokuzu;  // 枠内停止特図
    }

    // リーチパターン構造体
    struct structReachPattern
    {
        public int No;          // No
        public int Chusenti;    // 抽選値
        public string Name;     // リーチ名
    }

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
    structReachLine[] RL_Chusen;  // リーチライン抽選テーブル

    // リーチライン抽選リスト
    List<structReachLine> reachLines = new List<structReachLine> {
        new structReachLine{ No= 1, Chusenti=1000, ReachLine=2, Tokuzu="１タコ" },
        new structReachLine{ No= 2, Chusenti=1500, ReachLine=1, Tokuzu="2ハリセンボン/1タコ" },
        new structReachLine{ No= 3, Chusenti=1500, ReachLine=3, Tokuzu="2ハリセンボン/1タコ" },
        new structReachLine{ No= 4, Chusenti=2500, ReachLine=4, Tokuzu="2ハリセンボン/1タコ" },
        new structReachLine{ No= 5, Chusenti=1000, ReachLine=2, Tokuzu="2ハリセンボン" },
        new structReachLine{ No= 6, Chusenti=1500, ReachLine=1, Tokuzu="3カメ/2ハリセンボン" },
        new structReachLine{ No= 7, Chusenti=1500, ReachLine=3, Tokuzu="3カメ/2ハリセンボン" },
        new structReachLine{ No= 8, Chusenti=2500, ReachLine=4, Tokuzu="3カメ/2ハリセンボン" },
        new structReachLine{ No= 9, Chusenti=1000, ReachLine=2, Tokuzu="3カメ" },
        new structReachLine{ No= 10, Chusenti=1500, ReachLine=1, Tokuzu="4サメ/3カメ" },
        new structReachLine{ No= 11, Chusenti=1500, ReachLine=3, Tokuzu="4サメ/3カメ" },
        new structReachLine{ No= 12, Chusenti=3036, ReachLine=4, Tokuzu="4サメ/3カメ" },
        new structReachLine{ No= 13, Chusenti=1000, ReachLine=2, Tokuzu="4サメ" },
        new structReachLine{ No= 14, Chusenti=1500, ReachLine=1, Tokuzu="5エビ/4サメ" },
        new structReachLine{ No= 15, Chusenti=1500, ReachLine=3, Tokuzu="5エビ/4サメ" },
        new structReachLine{ No= 16, Chusenti=2500, ReachLine=4, Tokuzu="5エビ/4サメ" },
        new structReachLine{ No= 17, Chusenti=1000, ReachLine=2, Tokuzu="5エビ" },
        new structReachLine{ No= 18, Chusenti=1500, ReachLine=1, Tokuzu="6アンコウ/5エビ" },
        new structReachLine{ No= 19, Chusenti=1500, ReachLine=3, Tokuzu="6アンコウ/5エビ" },
        new structReachLine{ No= 20, Chusenti=2500, ReachLine=4, Tokuzu="6アンコウ/5エビ" },
        new structReachLine{ No= 21, Chusenti=1000, ReachLine=2, Tokuzu="6アンコウ" },
        new structReachLine{ No= 22, Chusenti=1500, ReachLine=1, Tokuzu="7ジュゴン/6アンコウ" },
        new structReachLine{ No= 23, Chusenti=1500, ReachLine=3, Tokuzu="7ジュゴン/6アンコウ" },
        new structReachLine{ No= 24, Chusenti=2500, ReachLine=4, Tokuzu="7ジュゴン/6アンコウ" },
        new structReachLine{ No= 25, Chusenti=1000, ReachLine=2, Tokuzu="7ジュゴン" },
        new structReachLine{ No= 26, Chusenti=1500, ReachLine=1, Tokuzu="8エンゼルフィッシュ/7ジュゴン" },
        new structReachLine{ No= 27, Chusenti=1500, ReachLine=3, Tokuzu="8エンゼルフィッシュ/7ジュゴン" },
        new structReachLine{ No= 28, Chusenti=2500, ReachLine=4, Tokuzu="8エンゼルフィッシュ/7ジュゴン" },
        new structReachLine{ No= 29, Chusenti=1000, ReachLine=2, Tokuzu="8エンゼルフィッシュ" },
        new structReachLine{ No= 30, Chusenti=1500, ReachLine=1, Tokuzu="9カニ/8エンゼルフィッシュ" },
        new structReachLine{ No= 31, Chusenti=1500, ReachLine=3, Tokuzu="9カニ/8エンゼルフィッシュ" },
        new structReachLine{ No= 32, Chusenti=2500, ReachLine=4, Tokuzu="9カニ/8エンゼルフィッシュ" },
        new structReachLine{ No= 33, Chusenti=1000, ReachLine=2, Tokuzu="9カニ" },
        new structReachLine{ No= 34, Chusenti=1500, ReachLine=1, Tokuzu="10カサゴ/9カニ" },
        new structReachLine{ No= 35, Chusenti=1500, ReachLine=3, Tokuzu="10カサゴ/9カニ" },
        new structReachLine{ No= 36, Chusenti=2500, ReachLine=4, Tokuzu="10カサゴ/9カニ" },
        new structReachLine{ No= 37, Chusenti=1000, ReachLine=2, Tokuzu="10カサゴ" },
        new structReachLine{ No= 38, Chusenti=1500, ReachLine=1, Tokuzu="1タコ/10カサゴ" },
        new structReachLine{ No= 39, Chusenti=1500, ReachLine=3, Tokuzu="1タコ/10カサゴ" },
        new structReachLine{ No= 40, Chusenti=2500, ReachLine=4, Tokuzu="1タコ/10カサゴ" }
    };

    // リーチパターン抽選テーブル関係
    structReachPattern[] RP_Chusen123;
    structReachPattern[] RP_Chusen4;

    // リーチパターン抽選①②③リスト
    List<structReachPattern> reachPattern123 = new List<structReachPattern>
    {
        new structReachPattern{ No= 9, Chusenti=7534, Name="ノーマル" },
        new structReachPattern{ No= 10, Chusenti=1000, Name="ノーマル＋再始動（+1）" },
        new structReachPattern{ No= 11, Chusenti=75, Name="ノーマル＋再始動（+2）" },
        new structReachPattern{ No= 12, Chusenti=75, Name="ノーマル＋再始動（+3）" },
        new structReachPattern{ No= 13, Chusenti=75, Name="ノーマル＋再始動（+4）" },
        new structReachPattern{ No= 14, Chusenti=75, Name="ノーマル＋再始動（+5）" },
        new structReachPattern{ No= 15, Chusenti=75, Name="ノーマル＋再始動（+6）" },
        new structReachPattern{ No= 16, Chusenti=75, Name="ノーマル＋再始動（+7）" },
        new structReachPattern{ No= 17, Chusenti=75, Name="ノーマル＋再始動（+8）" },
        new structReachPattern{ No= 18, Chusenti=75, Name="ノーマル＋再始動（+9）" },
        new structReachPattern{ No= 19, Chusenti=75, Name="ノーマル＋再始動（+10）" },
        new structReachPattern{ No= 20, Chusenti=75, Name="ノーマル＋再始動（+11）" },
        new structReachPattern{ No= 21, Chusenti=75, Name="ノーマル＋再始動（+12）" },
        new structReachPattern{ No= 22, Chusenti=75, Name="ノーマル＋再始動（+13）" },
        new structReachPattern{ No= 23, Chusenti=75, Name="ノーマル＋再始動（+14）" },
        new structReachPattern{ No= 24, Chusenti=75, Name="ノーマル＋再始動（+15）" },
        new structReachPattern{ No= 25, Chusenti=75, Name="ノーマル＋再始動（+16）" },
        new structReachPattern{ No= 26, Chusenti=75, Name="ノーマル＋再始動（+17）" },
        new structReachPattern{ No= 27, Chusenti=75, Name="ノーマル＋再始動（+18）" },
        new structReachPattern{ No= 28, Chusenti=75, Name="ノーマル＋再始動（+19）" },
        new structReachPattern{ No= 29, Chusenti=75, Name="ノーマル＋再始動（+20）" },
        new structReachPattern{ No= 30, Chusenti=8192, Name="泡+ノーマル" },
        new structReachPattern{ No= 31, Chusenti=1000, Name="泡＋ノーマル＋再始動（+1）" },
        new structReachPattern{ No= 32, Chusenti=75, Name="泡＋ノーマル＋再始動（+2）" },
        new structReachPattern{ No= 33, Chusenti=75, Name="泡＋ノーマル＋再始動（+3）" },
        new structReachPattern{ No= 34, Chusenti=75, Name="泡＋ノーマル＋再始動（+4）" },
        new structReachPattern{ No= 35, Chusenti=75, Name="泡＋ノーマル＋再始動（+5）" },
        new structReachPattern{ No= 36, Chusenti=75, Name="泡＋ノーマル＋再始動（+6）" },
        new structReachPattern{ No= 37, Chusenti=75, Name="泡＋ノーマル＋再始動（+7）" },
        new structReachPattern{ No= 38, Chusenti=75, Name="泡＋ノーマル＋再始動（+8）" },
        new structReachPattern{ No= 39, Chusenti=75, Name="泡＋ノーマル＋再始動（+9）" },
        new structReachPattern{ No= 40, Chusenti=75, Name="泡＋ノーマル＋再始動（+10）" },
        new structReachPattern{ No= 41, Chusenti=75, Name="泡＋ノーマル＋再始動（+11）" },
        new structReachPattern{ No= 42, Chusenti=75, Name="泡＋ノーマル＋再始動（+12）" },
        new structReachPattern{ No= 43, Chusenti=75, Name="泡＋ノーマル＋再始動（+13）" },
        new structReachPattern{ No= 44, Chusenti=75, Name="泡＋ノーマル＋再始動（+14）" },
        new structReachPattern{ No= 45, Chusenti=75, Name="泡＋ノーマル＋再始動（+15）" },
        new structReachPattern{ No= 46, Chusenti=75, Name="泡＋ノーマル＋再始動（+16）" },
        new structReachPattern{ No= 47, Chusenti=75, Name="泡＋ノーマル＋再始動（+17）" },
        new structReachPattern{ No= 48, Chusenti=75, Name="泡＋ノーマル＋再始動（+18）" },
        new structReachPattern{ No= 49, Chusenti=75, Name="泡＋ノーマル＋再始動（+19）" },
        new structReachPattern{ No= 50, Chusenti=75, Name="泡＋ノーマル＋再始動（+20）" },
        new structReachPattern{ No= 51, Chusenti=4192, Name="泡＋SP1（0）" },
        new structReachPattern{ No= 52, Chusenti=4000, Name="泡＋SP1（+1⇒戻り）" },
        new structReachPattern{ No= 53, Chusenti=4192, Name="泡＋SP2（0）" },
        new structReachPattern{ No= 54, Chusenti=4000, Name="泡＋SP2（+1⇒戻り）" },
        new structReachPattern{ No= 59, Chusenti=10288, Name="魚群＋SP1（0）" },
        new structReachPattern{ No= 60, Chusenti=4000, Name="魚群＋SP1（+1⇒戻り）" },
        new structReachPattern{ No= 61, Chusenti=10288, Name="魚群＋SP2（0）" },
        new structReachPattern{ No= 62, Chusenti=4000, Name="魚群＋SP2（+1⇒戻り）" }
    };

    // リーチパターン抽選④リスト
    List<structReachPattern> reachPattern4 = new List<structReachPattern>
    {
        new structReachPattern{ No= 9, Chusenti=7534, Name="ノーマル" },
        new structReachPattern{ No= 10, Chusenti=1000, Name="ノーマル＋再始動（+1）" },
        new structReachPattern{ No= 11, Chusenti=75, Name="ノーマル＋再始動（+2）" },
        new structReachPattern{ No= 12, Chusenti=75, Name="ノーマル＋再始動（+3）" },
        new structReachPattern{ No= 13, Chusenti=75, Name="ノーマル＋再始動（+4）" },
        new structReachPattern{ No= 14, Chusenti=75, Name="ノーマル＋再始動（+5）" },
        new structReachPattern{ No= 15, Chusenti=75, Name="ノーマル＋再始動（+6）" },
        new structReachPattern{ No= 16, Chusenti=75, Name="ノーマル＋再始動（+7）" },
        new structReachPattern{ No= 17, Chusenti=75, Name="ノーマル＋再始動（+8）" },
        new structReachPattern{ No= 18, Chusenti=75, Name="ノーマル＋再始動（+9）" },
        new structReachPattern{ No= 19, Chusenti=75, Name="ノーマル＋再始動（+10）" },
        new structReachPattern{ No= 20, Chusenti=75, Name="ノーマル＋再始動（+11）" },
        new structReachPattern{ No= 21, Chusenti=75, Name="ノーマル＋再始動（+12）" },
        new structReachPattern{ No= 22, Chusenti=75, Name="ノーマル＋再始動（+13）" },
        new structReachPattern{ No= 23, Chusenti=75, Name="ノーマル＋再始動（+14）" },
        new structReachPattern{ No= 24, Chusenti=75, Name="ノーマル＋再始動（+15）" },
        new structReachPattern{ No= 25, Chusenti=75, Name="ノーマル＋再始動（+16）" },
        new structReachPattern{ No= 26, Chusenti=75, Name="ノーマル＋再始動（+17）" },
        new structReachPattern{ No= 27, Chusenti=75, Name="ノーマル＋再始動（+18）" },
        new structReachPattern{ No= 28, Chusenti=75, Name="ノーマル＋再始動（+19）" },
        new structReachPattern{ No= 29, Chusenti=75, Name="ノーマル＋再始動（+20）" },
        new structReachPattern{ No= 30, Chusenti=8192, Name="泡+ノーマル" },
        new structReachPattern{ No= 31, Chusenti=1000, Name="泡＋ノーマル＋再始動（+1）" },
        new structReachPattern{ No= 32, Chusenti=75, Name="泡＋ノーマル＋再始動（+2）" },
        new structReachPattern{ No= 33, Chusenti=75, Name="泡＋ノーマル＋再始動（+3）" },
        new structReachPattern{ No= 34, Chusenti=75, Name="泡＋ノーマル＋再始動（+4）" },
        new structReachPattern{ No= 35, Chusenti=75, Name="泡＋ノーマル＋再始動（+5）" },
        new structReachPattern{ No= 36, Chusenti=75, Name="泡＋ノーマル＋再始動（+6）" },
        new structReachPattern{ No= 37, Chusenti=75, Name="泡＋ノーマル＋再始動（+7）" },
        new structReachPattern{ No= 38, Chusenti=75, Name="泡＋ノーマル＋再始動（+8）" },
        new structReachPattern{ No= 39, Chusenti=75, Name="泡＋ノーマル＋再始動（+9）" },
        new structReachPattern{ No= 40, Chusenti=75, Name="泡＋ノーマル＋再始動（+10）" },
        new structReachPattern{ No= 41, Chusenti=75, Name="泡＋ノーマル＋再始動（+11）" },
        new structReachPattern{ No= 42, Chusenti=75, Name="泡＋ノーマル＋再始動（+12）" },
        new structReachPattern{ No= 43, Chusenti=75, Name="泡＋ノーマル＋再始動（+13）" },
        new structReachPattern{ No= 44, Chusenti=75, Name="泡＋ノーマル＋再始動（+14）" },
        new structReachPattern{ No= 45, Chusenti=75, Name="泡＋ノーマル＋再始動（+15）" },
        new structReachPattern{ No= 46, Chusenti=75, Name="泡＋ノーマル＋再始動（+16）" },
        new structReachPattern{ No= 47, Chusenti=75, Name="泡＋ノーマル＋再始動（+17）" },
        new structReachPattern{ No= 48, Chusenti=75, Name="泡＋ノーマル＋再始動（+18）" },
        new structReachPattern{ No= 49, Chusenti=75, Name="泡＋ノーマル＋再始動（+19）" },
        new structReachPattern{ No= 50, Chusenti=75, Name="泡＋ノーマル＋再始動（+20）" },
        new structReachPattern{ No= 51, Chusenti=0, Name="泡＋SP1（0）" },
        new structReachPattern{ No= 52, Chusenti=0, Name="泡＋SP1（+1⇒戻り）" },
        new structReachPattern{ No= 53, Chusenti=0, Name="泡＋SP2（0）" },
        new structReachPattern{ No= 54, Chusenti=0, Name="泡＋SP2（+1⇒戻り）" },
        new structReachPattern{ No= 55, Chusenti=4192, Name="泡＋SP3（0）" },
        new structReachPattern{ No= 56, Chusenti=4000, Name="泡＋SP3（+1⇒戻り）" },
        new structReachPattern{ No= 57, Chusenti=4192, Name="泡＋SP3（+2）" },
        new structReachPattern{ No= 58, Chusenti=4000, Name="泡＋SP3（+3⇒戻り）" },
        new structReachPattern{ No= 63, Chusenti=10288, Name="魚群＋SP3（0）" },
        new structReachPattern{ No= 64, Chusenti=4000, Name="魚群＋SP3（+1⇒戻り）" },
        new structReachPattern{ No= 65, Chusenti=10288, Name="魚群＋SP3（+2）" },
        new structReachPattern{ No= 66, Chusenti=4000, Name="魚群＋SP3（+3⇒戻り）" }
    };

    // リーチ抽選ハズレテーブル関係
    const int H0_HAZURE_REACH = 9362;    // リーチ抽選（保留０）リーチ
    const int H0_HAZURE_HAZURE = 56174;  // リーチ抽選（保留０）ハズレ
    const int H12_HAZURE_REACH = 5461;   // リーチ抽選（保留１、２）リーチ
    const int H12_HAZURE_HAZURE = 60075; // リーチ抽選（保留１、２）ハズレ
    const int H3_HAZURE_REACH = 2527;    // リーチ抽選（保留３）リーチ
    const int H3_HAZURE_HAZURE = 63109;  // リーチ抽選（保留３）ハズレ

    bool[] H0_Chusen;   // リーチ抽選（保留０）テーブル
    bool[] H12_Chusen;  // リーチ抽選（保留１、２）テーブル
    bool[] H3_Chusen;   // リーチ抽選（保留３）テーブル

    // リーチパターン抽選（ハズレ）テーブル関係
    structReachPattern[] H_Reach_Chusen;
    List<structReachPattern> reachPatternHazure = new List<structReachPattern>
    {
        new structReachPattern{ No= 1, Chusenti=33500, Name="ノーマル" },
        new structReachPattern{ No= 2, Chusenti=25000, Name="泡+ノーマル" },
        new structReachPattern{ No= 3, Chusenti=2000, Name="泡＋SP1" },
        new structReachPattern{ No= 4, Chusenti=2000, Name="泡＋SP2" },
        new structReachPattern{ No= 5, Chusenti=1500, Name="泡＋SP3" },
        new structReachPattern{ No= 6, Chusenti=600, Name="魚群＋SP1" },
        new structReachPattern{ No= 7, Chusenti=600, Name="魚群＋SP2" },
        new structReachPattern{ No= 8, Chusenti=336, Name="魚群＋SP3" }
    };

	// 初期化
	void Start () {

        // 大当たり抽選テーブルの初期化
        var ATARI = Enumerable.Range(0, ATARI_NUM).Select(v => true);
        var HAZURE = Enumerable.Range(0, HAZURE_NUM).Select(v => false);
        NML_Chusen = ATARI.Concat(HAZURE).ToArray();

        // 大当たり（確変）抽選テーブルの初期化
        var KH_ATARI = Enumerable.Range(0, ATARI_NUM).Select(v => true);
        var KH_HAZURE = Enumerable.Range(0, HAZURE_NUM).Select(v => false);
        KH_Chusen = KH_ATARI.Concat(KH_HAZURE).ToArray();

        // リーチライン抽選テーブルの初期化
        // リーチライン抽選リストを65536個の配列に変換する
        RL_Chusen = reachLines.Select(rl=>RL2Sequence(rl)).SelectMany(rls=>rls).ToArray();

        // リーチパターン抽選テーブルの初期化
        RP_Chusen123 = reachPattern123.Select(rl => RP2Sequence(rl)).SelectMany(rls => rls).ToArray();
        RP_Chusen4 = reachPattern4.Select(rl => RP2Sequence(rl)).SelectMany(rls => rls).ToArray();

        // リーチ抽選（ハズレ）テーブルの初期化
        var H0_REACH = Enumerable.Range(0, H0_HAZURE_REACH).Select(v => true);
        var H0_HAZURE = Enumerable.Range(0, H0_HAZURE_HAZURE).Select(v => false);
        H0_Chusen = H0_REACH.Concat(H0_HAZURE).ToArray();

        var H12_REACH = Enumerable.Range(0, H12_HAZURE_REACH).Select(v => true);
        var H12_HAZURE = Enumerable.Range(0, H12_HAZURE_HAZURE).Select(v => false);
        H12_Chusen = H12_REACH.Concat(H12_HAZURE).ToArray();

        var H3_REACH = Enumerable.Range(0, H3_HAZURE_REACH).Select(v => true);
        var H3_HAZURE = Enumerable.Range(0, H3_HAZURE_HAZURE).Select(v => false);
        H3_Chusen = H3_REACH.Concat(H3_HAZURE).ToArray();

        // リーチパターン抽選（ハズレ）テーブルの初期化
        H_Reach_Chusen = reachPatternHazure.Select(rp => RP2Sequence(rp)).SelectMany(rps => rps).ToArray();

    }
	
    // リーチラインを抽選値の数のシーケンスに変換
    IEnumerable<structReachLine> RL2Sequence(structReachLine rl)
    {
        return Enumerable.Range(0, rl.Chusenti).Select(count => new structReachLine(){
                             No = rl.No,
                             Chusenti = rl.Chusenti,
                             ReachLine = rl.ReachLine,
                             Tokuzu = rl.Tokuzu }
               );
    }

    // リーチパターンを抽選値の数のシーケンスに変換
    IEnumerable<structReachPattern> RP2Sequence(structReachPattern rp)
    {
        return Enumerable.Range(0, rp.Chusenti)
                         .Select(count => new structReachPattern(){
                            No = rp.No,
                            Chusenti = rp.Chusenti,
                            Name = rp.Name });
    }


    //---------------//
	// チャッカー通過 //
    //---------------//
    public void NoticeChacker()
    {
        // 保留オブジェクトにチャッカー通過メッセージを送る
        Horyu.GetComponent<PlayMakerFSM>().SendEvent(ThroughChacker);
    }

    //----------------------
    // 大当たり抽選 
    // HoryuSu : 保留カウント
    // KenriKaisu : 権利回数（０でなければ確変中）
    public void DrawLot(int HoryuSu, int KenriKaisu)
    {
        var IsKakuhen = (KenriKaisu == 0) ? false : true;

        if (IsAtari(RndFFFF, IsKakuhen))
        {
            //---------//
            // 大当たり //
            //---------//

            // リーチライン抽選
            var rl = DrawLotReachLine(RndFFFF);

            // リーチパターン抽選
            Func<int, structReachPattern> DrawLotReachPattern;
            if (rl.ReachLine != 4) { DrawLotReachPattern = DrawLotReachPattern123; }
            else { DrawLotReachPattern = DrawLotReachPattern4; }

            var rp = DrawLotReachPattern(RndFFFF);

            // TODO 具体的にどうする
            Debug.Log("大当たり："+rp.Name);
        }
        else
        {
            Func<int, bool> DrawLotHazure;
            if (HoryuSu == 0)
            {
                DrawLotHazure = DrawLotHazureH0;
            }
            else if (HoryuSu == 1 || HoryuSu == 2)
            {
                DrawLotHazure = DrawLotHazureH12;
            }
            else
            {
                DrawLotHazure = DrawLotHazureH3;
            }

            // リーチ抽選
            var reach = DrawLotHazure(RndFFFF);

            if (reach)
            {
                var rp = DrawLotReachPatternHazure(RndFFFF);

                // TODO ハズレリーチ
                Debug.Log("ハズレリーチ：" + rp.Name);
            }
            else
            {
                // TODO ハズレ
                Debug.Log("ハズレ");
            }
        }
    }

    // 大当たり抽選
    bool IsAtari(int value, bool IsKakuhen)
    {
        var chusen = IsKakuhen ? KH_Chusen : NML_Chusen;
        return chusen[value];
    }

    // リーチライン抽選（大当たり）
    // 返却値:リーチラインの構造体
    // value:抽選値（ランダム）
    structReachLine DrawLotReachLine(int value)
    {
        return RL_Chusen[value];
    }

    // リーチパターン抽選①②③（大当たり）
    // 返却値：リーチパターンのNO
    // value:抽選値（ランダム）
    structReachPattern DrawLotReachPattern123(int value)
    {
        return RP_Chusen123[value];
    }

    // リーチパターン抽選④（大当たり）
    // 返却値：リーチパターンのNO
    // value:抽選値（ランダム）
    structReachPattern DrawLotReachPattern4(int value)
    {
        return RP_Chusen4[value];
    }

    // リーチ抽選（ハズレ）保留０
    // 返却値： true:リーチ　false:ハズレ
    // value:抽選値（ランダム）
    bool DrawLotHazureH0(int value)
    {
        return H0_Chusen[value];
    }

    // リーチ抽選（ハズレ）保留１、２
    // 返却値： true:リーチ　false:ハズレ
    // value:抽選値（ランダム）
    bool DrawLotHazureH12(int value)
    {
        return H12_Chusen[value];
    }

    // リーチ抽選（ハズレ）保留３
    // 返却値： true:リーチ　false:ハズレ
    // value:抽選値（ランダム）
    bool DrawLotHazureH3(int value)
    {
        return H3_Chusen[value];
    }

    // リーチパターン抽選（ハズレ）
    // 返却値：リーチパターンのNO
    // value:抽選値（ランダム）
    structReachPattern DrawLotReachPatternHazure(int value)
    {
        return H_Reach_Chusen[value];
    }
}
