using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ginpara;

namespace Ginpara { 

/// <summary>
/// リールテーブル
/// </summary>
public struct ReelElement
{
    public String Tokuzu;   // 数字か貝
    public String Sizi;     // 指示No( 4-1 等 )
};

/// <summary>
/// リール管理クラス
/// </summary>
public class Reel
{
    static System.Random rnd = new System.Random(Environment.TickCount);
    const int CHUSEN_LEN = 65536;       // 抽選のサイズ

    /// <summary>
    /// 0～65535のランダム値を返す
    /// </summary>
    static int RndFFFF
    {
        get
        {
            return rnd.Next(CHUSEN_LEN);
        }
    }

    #region <<上段>>

    /// <summary>
    /// 上段
    /// </summary>
    static List<ReelElement> reel1 = new List<ReelElement>()
    {
        new ReelElement(){ Tokuzu="10",Sizi="4-1"},
        new ReelElement(){ Tokuzu="*", Sizi="4-2"},
        new ReelElement(){ Tokuzu="9", Sizi="4-3"},
        new ReelElement(){ Tokuzu="*", Sizi="4-4"},
        new ReelElement(){ Tokuzu="8", Sizi="4-5"},
        new ReelElement(){ Tokuzu="*", Sizi="4-6"},
        new ReelElement(){ Tokuzu="7", Sizi="4-7"},
        new ReelElement(){ Tokuzu="*", Sizi="4-8"},
        new ReelElement(){ Tokuzu="6", Sizi="4-9"},
        new ReelElement(){ Tokuzu="*", Sizi="4-10"},
        new ReelElement(){ Tokuzu="5", Sizi="4-11"},
        new ReelElement(){ Tokuzu="*", Sizi="4-12"},
        new ReelElement(){ Tokuzu="4", Sizi="4-13"},
        new ReelElement(){ Tokuzu="*", Sizi="4-14"},
        new ReelElement(){ Tokuzu="3", Sizi="4-15"},
        new ReelElement(){ Tokuzu="*", Sizi="4-16"},
        new ReelElement(){ Tokuzu="2", Sizi="4-17"},
        new ReelElement(){ Tokuzu="*", Sizi="4-18"},
        new ReelElement(){ Tokuzu="1", Sizi="4-19"},
        new ReelElement(){ Tokuzu="*", Sizi="4-20"},
    };

    /// <summary>
    /// 上段リールの無限シーケンス
    /// </summary>
    public static CycleSequence<ReelElement> CyclicReel1 = new CycleSequence<ReelElement>(reel1);

    /// <summary>
    /// 上段リールの配列
    /// </summary>
    static ReelElement[] reel1array = reel1.ToArray();

    #endregion

    #region <<中段>>

    /// <summary>
    /// 中段リール
    /// </summary>
    static List<ReelElement> reel2 = new List<ReelElement>()
    {
        new ReelElement(){ Tokuzu="1", Sizi="5-1"},
        new ReelElement(){ Tokuzu="*", Sizi="5-2"},
        new ReelElement(){ Tokuzu="2", Sizi="5-3"},
        new ReelElement(){ Tokuzu="*", Sizi="5-4"},
        new ReelElement(){ Tokuzu="3", Sizi="5-5"},
        new ReelElement(){ Tokuzu="*", Sizi="5-6"},
        new ReelElement(){ Tokuzu="4", Sizi="5-7"},
        new ReelElement(){ Tokuzu="*", Sizi="5-8"},
        new ReelElement(){ Tokuzu="5", Sizi="5-9"},
        new ReelElement(){ Tokuzu="*", Sizi="5-10"},
        new ReelElement(){ Tokuzu="6", Sizi="5-11"},
        new ReelElement(){ Tokuzu="*", Sizi="5-12"},
        new ReelElement(){ Tokuzu="7", Sizi="5-13"},
        new ReelElement(){ Tokuzu="*", Sizi="5-14"},
        new ReelElement(){ Tokuzu="8", Sizi="5-15"},
        new ReelElement(){ Tokuzu="*", Sizi="5-16"},
        new ReelElement(){ Tokuzu="9", Sizi="5-17"},
        new ReelElement(){ Tokuzu="*", Sizi="5-18"},
        new ReelElement(){ Tokuzu="10",Sizi="5-19"},
        new ReelElement(){ Tokuzu="*", Sizi="5-20"},
    };

    /// <summary>
    /// 中段リールの配列
    /// </summary>
    static ReelElement[] reel2array = reel2.ToArray();

    /// <summary>
    /// 中段リールの無限シーケンス
    /// </summary>
    public static CycleSequence<ReelElement> CyclicReel2 = new CycleSequence<ReelElement>(reel2);

    /// <summary>
    /// 中段リールリーチはずし確率テーブル（リーチライン１，２，３）
    /// </summary>
    static List<int> Reel2ReachHazusiChusen123 = new List<int>()
    {
        0,409,3276,3276,3276,3276,3276,3276,3276,3276,3276,3276,1638,836,6552,6552,6552,6552,3276,409
    };


    /// <summary>
    /// 中段リールノーマルリーチリスト
    /// </summary>
    public static List<ReelElement> reel2normal = new List<ReelElement>()
    {
        new ReelElement(){ Tokuzu="1", Sizi="7-1"},
        new ReelElement(){ Tokuzu="*", Sizi="7-2"},
        new ReelElement(){ Tokuzu="2", Sizi="7-3"},
        new ReelElement(){ Tokuzu="*", Sizi="7-4"},
        new ReelElement(){ Tokuzu="3", Sizi="7-5"},
        new ReelElement(){ Tokuzu="*", Sizi="7-6"},
        new ReelElement(){ Tokuzu="4", Sizi="7-7"},
        new ReelElement(){ Tokuzu="*", Sizi="7-8"},
        new ReelElement(){ Tokuzu="5", Sizi="7-9"},
        new ReelElement(){ Tokuzu="*", Sizi="7-10"},
        new ReelElement(){ Tokuzu="6", Sizi="7-11"},
        new ReelElement(){ Tokuzu="*", Sizi="7-12"},
        new ReelElement(){ Tokuzu="7", Sizi="7-13"},
        new ReelElement(){ Tokuzu="*", Sizi="7-14"},
        new ReelElement(){ Tokuzu="8", Sizi="7-15"},
        new ReelElement(){ Tokuzu="*", Sizi="7-16"},
        new ReelElement(){ Tokuzu="9", Sizi="7-17"},
        new ReelElement(){ Tokuzu="*", Sizi="7-18"},
        new ReelElement(){ Tokuzu="10",Sizi="7-19"},
        new ReelElement(){ Tokuzu="*", Sizi="7-20"},
    };

    /// <summary>
    /// 中段リールの配列
    /// </summary>
    static ReelElement[] reel2normalarray = reel2normal.ToArray();

    /// <summary>
    /// 中段リールの無限シーケンス
    /// </summary>
    public static CycleSequence<ReelElement> CyclicReel2normal = new CycleSequence<ReelElement>(reel2normal);


    /// <summary>
    /// 中段リールリーチはずし確率テーブル（リーチライン４）
    /// </summary>
    static List<int> Reel2ReachHazusiChusen4 = new List<int>()
    {
        309,3276,3276,3276,3276,3276,3276,3276,1638,836,6552,6552,6552,6552,6552,6552,309,0,200,0
    };

    /// <summary>
    /// 中段リールSPリーチリスト（－１）
    /// </summary>
    public static List<ReelElement> reel2SP_RIGHT = new List<ReelElement>()
    {
        new ReelElement(){ Tokuzu="1", Sizi="8-1"},
        new ReelElement(){ Tokuzu="*", Sizi="8-2"},
        new ReelElement(){ Tokuzu="2", Sizi="8-3"},
        new ReelElement(){ Tokuzu="*", Sizi="8-4"},
        new ReelElement(){ Tokuzu="3", Sizi="8-5"},
        new ReelElement(){ Tokuzu="*", Sizi="8-6"},
        new ReelElement(){ Tokuzu="4", Sizi="8-7"},
        new ReelElement(){ Tokuzu="*", Sizi="8-8"},
        new ReelElement(){ Tokuzu="5", Sizi="8-9"},
        new ReelElement(){ Tokuzu="*", Sizi="8-10"},
        new ReelElement(){ Tokuzu="6", Sizi="8-11"},
        new ReelElement(){ Tokuzu="*", Sizi="8-12"},
        new ReelElement(){ Tokuzu="7", Sizi="8-13"},
        new ReelElement(){ Tokuzu="*", Sizi="8-14"},
        new ReelElement(){ Tokuzu="8", Sizi="8-15"},
        new ReelElement(){ Tokuzu="*", Sizi="8-16"},
        new ReelElement(){ Tokuzu="9", Sizi="8-17"},
        new ReelElement(){ Tokuzu="*", Sizi="8-18"},
        new ReelElement(){ Tokuzu="10",Sizi="8-19"},
        new ReelElement(){ Tokuzu="*", Sizi="8-20"},
    };

    /// <summary>
    /// 中段リールSPリーチリスト（０）
    /// </summary>
    public static List<ReelElement> reel2SP_CENTER = new List<ReelElement>()
    {
        new ReelElement(){ Tokuzu="1", Sizi="8-21"},
        new ReelElement(){ Tokuzu="*", Sizi="8-22"},
        new ReelElement(){ Tokuzu="2", Sizi="8-23"},
        new ReelElement(){ Tokuzu="*", Sizi="8-24"},
        new ReelElement(){ Tokuzu="3", Sizi="8-25"},
        new ReelElement(){ Tokuzu="*", Sizi="8-26"},
        new ReelElement(){ Tokuzu="4", Sizi="8-27"},
        new ReelElement(){ Tokuzu="*", Sizi="8-28"},
        new ReelElement(){ Tokuzu="5", Sizi="8-29"},
        new ReelElement(){ Tokuzu="*", Sizi="8-30"},
        new ReelElement(){ Tokuzu="6", Sizi="8-31"},
        new ReelElement(){ Tokuzu="*", Sizi="8-32"},
        new ReelElement(){ Tokuzu="7", Sizi="8-33"},
        new ReelElement(){ Tokuzu="*", Sizi="8-34"},
        new ReelElement(){ Tokuzu="8", Sizi="8-35"},
        new ReelElement(){ Tokuzu="*", Sizi="8-36"},
        new ReelElement(){ Tokuzu="9", Sizi="8-37"},
        new ReelElement(){ Tokuzu="*", Sizi="8-38"},
        new ReelElement(){ Tokuzu="10",Sizi="8-39"},
        new ReelElement(){ Tokuzu="*", Sizi="8-40"},
    };

    /// <summary>
    /// 中段リールSPリーチリスト（－１）
    /// </summary>
    public static List<ReelElement> reel2SP_LEFT = new List<ReelElement>()
    {
        new ReelElement(){ Tokuzu="1", Sizi="8-41"},
        new ReelElement(){ Tokuzu="*", Sizi="8-42"},
        new ReelElement(){ Tokuzu="2", Sizi="8-43"},
        new ReelElement(){ Tokuzu="*", Sizi="8-44"},
        new ReelElement(){ Tokuzu="3", Sizi="8-45"},
        new ReelElement(){ Tokuzu="*", Sizi="8-46"},
        new ReelElement(){ Tokuzu="4", Sizi="8-47"},
        new ReelElement(){ Tokuzu="*", Sizi="8-48"},
        new ReelElement(){ Tokuzu="5", Sizi="8-49"},
        new ReelElement(){ Tokuzu="*", Sizi="8-50"},
        new ReelElement(){ Tokuzu="6", Sizi="8-51"},
        new ReelElement(){ Tokuzu="*", Sizi="8-52"},
        new ReelElement(){ Tokuzu="7", Sizi="8-53"},
        new ReelElement(){ Tokuzu="*", Sizi="8-54"},
        new ReelElement(){ Tokuzu="8", Sizi="8-55"},
        new ReelElement(){ Tokuzu="*", Sizi="8-56"},
        new ReelElement(){ Tokuzu="9", Sizi="8-57"},
        new ReelElement(){ Tokuzu="*", Sizi="8-58"},
        new ReelElement(){ Tokuzu="10",Sizi="8-59"},
        new ReelElement(){ Tokuzu="*", Sizi="8-60"},
    };

    /// <summary>
    /// 中段リールSPリーチリスト（－１）の無限シーケンス
    /// </summary>
    public static CycleSequence<ReelElement> CyclicReel2SP_RIGHT = new CycleSequence<ReelElement>(reel2SP_RIGHT);

    /// <summary>
    /// 中段リールSPリーチリスト（０）の無限シーケンス
    /// </summary>
    public static CycleSequence<ReelElement> CyclicReel2SP_CENTER = new CycleSequence<ReelElement>(reel2SP_CENTER);

    /// <summary>
    /// 中段リールSPリーチリスト（＋１）の無限シーケンス
    /// </summary>
    public static CycleSequence<ReelElement> CyclicReel2SP_LEFT = new CycleSequence<ReelElement>(reel2SP_LEFT);

    /// <summary>
    /// ＳＰリーチシフト数抽選構造体
    /// </summary>
    struct ShiftReel
    {
        public int ShiftNum;    // シフト数
        public int Chusenti;    // 抽選値
    }

    /// <summary>
    /// 泡確率テーブル（ＳＰ１、ＳＰ２）
    /// </summary>
    static List<ShiftReel> ChusenAwaSP12 = new List<ShiftReel>()
    {
        new ShiftReel { ShiftNum = -1, Chusenti= 49152},
        new ShiftReel { ShiftNum = +1, Chusenti= 16384},
    };

    /// <summary>
    /// 魚群確率テーブル（ＳＰ１、ＳＰ２）
    /// </summary>
    static List<ShiftReel> ChusenGyogunSP12 = new List<ShiftReel>()
    {
        new ShiftReel { ShiftNum = -1, Chusenti= 16384 },
        new ShiftReel { ShiftNum = +1, Chusenti= 49152 },
    };

    /// <summary>
    /// 確率テーブル（ＳＰ３）
    /// </summary>
    static List<ShiftReel> ChusenSP3 = new List<ShiftReel>()
    {
        new ShiftReel { ShiftNum = -1, Chusenti= 16384},
        new ShiftReel { ShiftNum = +1, Chusenti= 16384},
        new ShiftReel { ShiftNum = +3, Chusenti= 32768},
    };

    /// <summary>
    /// 泡確率抽選テーブル（ＳＰ１、ＳＰ２）
    /// </summary>
    static ShiftReel[] ChusenAwaSP12Array = ChusenAwaSP12.Select(ca => SR2Sequence(ca)).SelectMany(cas => cas).ToArray();

    /// <summary>
    /// 泡確率抽選テーブル（ＳＰ１、ＳＰ２）
    /// </summary>
    static ShiftReel[] ChusenGyogunSP12Array = ChusenGyogunSP12.Select(ca => SR2Sequence(ca)).SelectMany(cas => cas).ToArray();

    /// <summary>
    /// 確率抽選テーブル（ＳＰ３）
    /// </summary>
    static ShiftReel[] ChusenSP3Array = ChusenSP3.Select(ca => SR2Sequence(ca)).SelectMany(cas => cas).ToArray();

#endregion <<中段>>

    #region <<下段>>
    /// <summary>
    /// 下段リール
    /// </summary>
    static List<ReelElement> reel3 = new List<ReelElement>()
    {
        new ReelElement(){ Tokuzu="1", Sizi="6-1"},
        new ReelElement(){ Tokuzu="*", Sizi="6-2"},
        new ReelElement(){ Tokuzu="2", Sizi="6-3"},
        new ReelElement(){ Tokuzu="*", Sizi="6-4"},
        new ReelElement(){ Tokuzu="3", Sizi="6-5"},
        new ReelElement(){ Tokuzu="*", Sizi="6-6"},
        new ReelElement(){ Tokuzu="4", Sizi="6-7"},
        new ReelElement(){ Tokuzu="*", Sizi="6-8"},
        new ReelElement(){ Tokuzu="5", Sizi="6-9"},
        new ReelElement(){ Tokuzu="*", Sizi="6-10"},
        new ReelElement(){ Tokuzu="6", Sizi="6-11"},
        new ReelElement(){ Tokuzu="*", Sizi="6-12"},
        new ReelElement(){ Tokuzu="7", Sizi="6-13"},
        new ReelElement(){ Tokuzu="*", Sizi="6-14"},
        new ReelElement(){ Tokuzu="8", Sizi="6-15"},
        new ReelElement(){ Tokuzu="*", Sizi="6-16"},
        new ReelElement(){ Tokuzu="9", Sizi="6-17"},
        new ReelElement(){ Tokuzu="*", Sizi="6-18"},
        new ReelElement(){ Tokuzu="10",Sizi="6-19"},
        new ReelElement(){ Tokuzu="*", Sizi="6-20"},
    };

    /// <summary>
    /// 下段リールの無限シーケンス
    /// </summary>
    public static CycleSequence<ReelElement> CyclicReel3 = new CycleSequence<ReelElement>(reel3);

    struct BarakemePattern
    {
        public ReelElement elem;
        public int chusenti;
    };
    #endregion <<下段>>

    /// <summary>
    /// バラケ目（リーチ不成立時）停止テーブル
    /// </summary>
    static List<BarakemePattern> Barakeme = new List<BarakemePattern>()
    {
        new BarakemePattern {elem = reel1array[0], chusenti=3000},   // 10
        new BarakemePattern {elem = reel1array[1], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[2], chusenti=3000},   // 9
        new BarakemePattern {elem = reel1array[3], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[4], chusenti=3000},   // 8
        new BarakemePattern {elem = reel1array[5], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[6], chusenti=3000},   // 7
        new BarakemePattern {elem = reel1array[7], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[8], chusenti=3000},   // 6
        new BarakemePattern {elem = reel1array[9], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[10], chusenti=3000},   // 5
        new BarakemePattern {elem = reel1array[11], chusenti=3868},   // *
        new BarakemePattern {elem = reel1array[12], chusenti=3600},   // 4
        new BarakemePattern {elem = reel1array[13], chusenti=3868},   // *
        new BarakemePattern {elem = reel1array[14], chusenti=3000},   // 3
        new BarakemePattern {elem = reel1array[15], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[16], chusenti=3000},   // 2
        new BarakemePattern {elem = reel1array[17], chusenti=3400},   // *
        new BarakemePattern {elem = reel1array[18], chusenti=3000},   // 1
        new BarakemePattern {elem = reel1array[19], chusenti=3400},   // *
    };

    /// <summary>
    /// バラケ目抽選テーブル
    /// </summary>
    static BarakemePattern[] BarakemeChusen = Barakeme.Select(br => BR2Sequence(br)).SelectMany(brs => brs).ToArray();

    /// <summary>
    /// 中段リーチ外しリスト
    /// リーチライン２に１が来ない配列を基準にしている
    /// リーチライン１に１が来ないようにするには、
    /// 
    /// </summary>
    static List<BarakemePattern> ChudanReachHazushi= new List<BarakemePattern>()
    {
        new BarakemePattern {elem = reel2array[0], chusenti=0},      // *
        new BarakemePattern {elem = reel2array[1], chusenti=409},    // 1
        new BarakemePattern {elem = reel2array[2], chusenti=3276},   // *
        new BarakemePattern {elem = reel2array[3], chusenti=3276},   // 2
        new BarakemePattern {elem = reel2array[4], chusenti=3276},   // *
        new BarakemePattern {elem = reel2array[5], chusenti=3276},   // 3
        new BarakemePattern {elem = reel2array[6], chusenti=3276},   // *
        new BarakemePattern {elem = reel2array[7], chusenti=3276},   // 4
        new BarakemePattern {elem = reel2array[8], chusenti=3276},   // *
        new BarakemePattern {elem = reel2array[9], chusenti=3276},   // 5
        new BarakemePattern {elem = reel2array[10], chusenti=3276},  // *
        new BarakemePattern {elem = reel2array[11], chusenti=3276},  // 6
        new BarakemePattern {elem = reel2array[12], chusenti=3276},  // *
        new BarakemePattern {elem = reel2array[13], chusenti=1638},  // 7
        new BarakemePattern {elem = reel2array[14], chusenti=836},   // *
        new BarakemePattern {elem = reel2array[15], chusenti=6552},  // 8
        new BarakemePattern {elem = reel2array[16], chusenti=6552},  // *
        new BarakemePattern {elem = reel2array[17], chusenti=6552},  // 9
        new BarakemePattern {elem = reel2array[18], chusenti=3276},  // *
        new BarakemePattern {elem = reel2array[19], chusenti=409},   // 10
    };

    /// <summary>
    /// static コンストラクタ
    /// </summary>
    static Reel()
    {
    }

    /// <summary>
    /// バラケ目テーブルを抽選値の数のシーケンスに変換
    /// </summary>
    /// <param name="br"></param>
    /// <returns></returns>
    static IEnumerable<BarakemePattern> BR2Sequence(BarakemePattern br)
    {
        return Enumerable.Range(0, br.chusenti).Select(count => new BarakemePattern()
        {
            elem = br.elem,
            chusenti = br.chusenti
        });
    }

    /// <summary>
    /// 確率抽選テーブルを抽選値の数のシーケンスに変換
    /// </summary>
    /// <param name="br"></param>
    /// <returns></returns>
    static IEnumerable<ShiftReel> SR2Sequence(ShiftReel sr)
    {
        return Enumerable.Range(0, sr.Chusenti).Select(count => new ShiftReel()
        {
            ShiftNum = sr.ShiftNum,
            Chusenti = sr.Chusenti
        });
    }

    /// <summary>
    /// リールを抽選（均等）
    /// </summary>
    /// <param name="reel"></param>
    /// <returns></returns>
    static ReelElement GetElement(List<ReelElement> reel)
    {
        return reel.ToArray()[UnityEngine.Random.Range(0, reel.Count)];
    }

    /// <summary>
    /// 止まる位置を取得（ＳＰリーチ）
    /// </summary>
    /// <param name="ReachLine">リーチライン①～④</param>
    /// <param name="Tokuzu">特図の番号１～１０</param>
    /// <returns></returns>
    static public ReelElement[] ChooseSP(int ReachLine, int Tokuzu, string ReachPatternName)
    {
        // 上段、中段、下段の止まる位置を仮固定
        var r1 = reel1.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();
        var r2 = reel2.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();
        var r3 = reel3.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();

        // リーチラインに応じて、上段、下段の位置をずらす
        if (ReachLine == 1)
        {
            // ずらさない
        }
        else if (ReachLine == 2)
        {
            // 上段ずらす
            r1 = CyclicReel1.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(19)
                            .First();

            // 下段ずらす
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(19)
                            .First();

        }
        else if (ReachLine == 3)
        {
            // 上段ずらす
            r1 = CyclicReel1.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();

            // 下段ずらす
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();
        }
        else if (ReachLine == 4)
        {
            // 上段ずらさないで、下段ずらす
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();
        }

        // =========
        // 中段を抽選
        // =========
        // -1, +1, +3の抽選を行い、（-1が右側、+1が左側）
        // 循環テーブルを停止特図分シフト（スキップ）し、
        // リーチライン分シフト（スキップ）し、
        var CyclicReel = CyclicReel2SP_RIGHT;

        var SkipReachLine = 20; // 一回転

        if (ReachLine == 1)
        {
        }
        else if( ReachLine == 2 )
        {
            SkipReachLine -= 1;
        }
        else if (ReachLine == 3)
        {
            SkipReachLine -= 2;
        }
        else if (ReachLine == 4)
        {
            SkipReachLine -= 1;
        }


        // SP1, SP2は泡、魚群に応じて＋１、－１を抽選する
        // SP3は＋１、－１、＋３を抽選する
        var shiftnum = 0;
        if (ReachPatternName.Contains("SP1") || ReachPatternName.Contains("SP2"))
        {
            if (ReachPatternName.Contains("泡"))
            {
                shiftnum = ChusenAwaSP12Array[RndFFFF].ShiftNum;
            }
            else
            {
                shiftnum = ChusenGyogunSP12Array[RndFFFF].ShiftNum;
            }
        }
        else
        {
            // SP3
            shiftnum += ChusenSP3Array[RndFFFF].ShiftNum;
        }

        SkipReachLine += shiftnum;

        var CyclicReel2 = CyclicReel2SP_CENTER;
        if (shiftnum < 0)
        {
            CyclicReel2 = CyclicReel2SP_RIGHT;
        }
        else if( shiftnum > 0)
        {
            CyclicReel2 = CyclicReel2SP_LEFT;
        }

        var Chudan = CyclicReel2.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                                .Skip(SkipReachLine)
                                .First();

        r2 = Chudan;

        var reels = new ReelElement[] { r1, r2, r3 };

        return reels;
    }

    #region <<ノーマルリーチ>>
    /// <summary>
    /// 止まる位置を取得（リーチ）
    /// </summary>
    /// <param name="ReachLine">リーチライン①～④</param>
    /// <param name="Tokuzu">特図の番号１～１０</param>
    /// <returns></returns>
    static public ReelElement[] Choose(int ReachLine, int Tokuzu)
    {
        // 上段の止まる位置を決定
        var r1 = reel1.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();
        var r2 = reel2.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();
        var r3 = reel3.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();

        // リーチラインに応じて、上段、下段の位置をずらす
        if (ReachLine == 1)
        {
            // ずらさない
        }
        else if (ReachLine == 2)
        {
            // 上段ずらす
            r1 = CyclicReel1.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(19)
                            .First();

            // 下段ずらす
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(19)
                            .First();

        }else if(ReachLine == 3)
        {
            // 上段ずらす
            r1 = CyclicReel1.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();

            // 下段ずらす
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();
        }
        else if (ReachLine == 4)
        {
            // 上段ずらさないで、下段ずらす
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();
        }

        // =========
        // 中段を抽選
        // =========
        // 循環テーブルを停止特図分シフト（スキップ）し、
        // リーチライン分シフト（スキップ）し、
        // 抽選テーブルとZIP(統合)し、
        // 抽選値の数だけ平坦化し、
        // 乱数で抽選する。

        var SkipReachLine = 20; // 一回転
        var ChusenTable = Reel2ReachHazusiChusen123;

        switch (ReachLine)
        {
            case 1:
                break;
            case 2:
                SkipReachLine -= 1;
                break;
            case 3:
                SkipReachLine -= 2;
                break;
            case 4:
                ChusenTable = Reel2ReachHazusiChusen4;
                break;
        }

        var Chudan = CyclicReel2normal.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                                .Skip(SkipReachLine)
                                .Take(20)
                                .Select((e, index) => new BarakemePattern() {
                                    elem = e, chusenti = ChusenTable[index]
                                 })
                                .Select(br => BR2Sequence(br))
                                .SelectMany(brs => brs)
                                .ToArray();

        r2 = Chudan[RndFFFF].elem;

        var reels = new ReelElement[] { r1, r2, r3 };

        return reels;
    }
    #endregion <<ノーマルリーチ>>

    #region <<バラケ目>>
    /// <summary>
    /// 止まる位置を取得（バラケ目）
    /// </summary>
    /// <returns>指示No 上段、中段、下段( 4-1 等 )</returns>
    static public ReelElement[] Choose()
    {
        // 上段の止まる位置を抽選
        var r1 = BarakemeChusen[RndFFFF].elem;

        ReelElement r2, r3;

        // 下段の止まる位置を抽選
        r3 = GetElement(reel3);

        // テンパイを避けて均等に停止させる
        // テンパイすることになったら＋１してズラす
        while (IsTenpai(r1, r3))
        {
            r3 = CyclicReel3.SkipWhile(elem => !elem.Sizi.Equals(r3.Sizi))
                            .Take(2)
                            .ToArray()[1];
        }

        // 中段を抽選
        r2 = GetElement(reel2);

        var reels = new ReelElement[] { r1, r2, r3 };

        return reels;
    }

    /// <summary>
    /// テンパイしているか返す
    /// </summary>
    /// <param name="r1">リール</param>
    /// <param name="r3">リール</param>
    /// <returns>true:テンパイしている false:テンパイしていない</returns>
    static private bool IsTenpai( ReelElement r1, ReelElement r3 )
    {
        // テンパイしているか調査
        if (r1.Tokuzu == r3.Tokuzu) return true;

        // リール取得
        var Jodan = CyclicReel1.SkipWhile(elem => !elem.Sizi.Equals(r1.Sizi))
                               .Take(3).ToArray();

        var Gedan = CyclicReel3.SkipWhile(elem => !elem.Sizi.Equals(r3.Sizi))
                               .Take(3).ToArray();

        // 垂直方向のチェック
        if (Jodan[0].Tokuzu.Equals(Gedan[0].Tokuzu)) { return true; }
        if (Jodan[1].Tokuzu.Equals(Gedan[1].Tokuzu)) { return true; }
        if (Jodan[2].Tokuzu.Equals(Gedan[2].Tokuzu)) { return true; }

        // ナナメのチェック
        if (Jodan[0].Tokuzu.Equals(Gedan[2].Tokuzu)) { return true; }
        if (Jodan[2].Tokuzu.Equals(Gedan[0].Tokuzu)) { return true; }

        // テンパイしていないを返却
        return false;
    }
    #endregion <<バラケ目>>

    /// <summary>
    /// 大当たりの止まる位置を取得
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    static public ReelElement[] ChooseOoatari(DrawLotResult result)
    {
        var Tokuzu = result.tokuzu;
        var ReachLine = result.reachLine;

        Debug.Log("特図：" + Tokuzu);
        Debug.Log("リーチライン：" + ReachLine);

        // 上段、中段、下段の止まる位置を仮固定
        var r1 = reel1.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();
        var r2 = reel2.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();
        var r3 = reel3.Where(r => r.Tokuzu.Equals(Tokuzu.ToString())).First();

        // リーチラインに応じて、上段、下段の位置をずらす
        if (ReachLine == 1)
        {
            // ずらさない
        }
        else if (ReachLine == 2)
        {
            // 上段ずらす
            r1 = CyclicReel1.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(19)
                            .First();

            // 下段ずらす
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(19)
                            .First();

        }
        else if (ReachLine == 3)
        {
            // 上段ずらす
            r1 = CyclicReel1.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();

            // 下段ずらす
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();
        }
        else if (ReachLine == 4)
        {
            // 上段ずらさないで、下段ずらす
            r3 = CyclicReel3.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();
        }

        //--------------------------------------------------------------------
        // 中段を決める
        // TODO
        // 9-1 ～ 28-19 を使うはずなのだが、どういう基準で使うのかがよく分からない。
        // とりあえずははずれちゃった絵を出す
        // と思ったけど味気なさすぎなので、当たった絵面は出す
        //--------------------------------------------------------------------

        // リーチラインに応じて、中段の位置をずらす
        if (ReachLine == 1)
        {
            // ずらさない
        }
        else if (ReachLine == 2)
        {
            r2 = CyclicReel2.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(19)
                            .First();
        }
        else if (ReachLine == 3)
        {
            r2 = CyclicReel2.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(18)
                            .First();
        }
        else if (ReachLine == 4)
        {
            r2 = CyclicReel2.SkipWhile(elem => !elem.Tokuzu.Equals(Tokuzu.ToString()))
                            .Skip(19)
                            .First();
        }

        var reels = new ReelElement[] { r1, r2, r3 };

        return reels;
    }

}

}