//using UnityEngine;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ginpara;

/// <summary>
/// ノーマルリーチ単体テスト
/// </summary>
[TestFixture]
[Category("Sample Tests")]
internal class ReachTests
{

    /// <summary>
    /// SP3リーチのテスト
    /// 当たっちゃわないかテスト
    /// </summary>
    /// <param name="ReachLine">リーチライン</param>
    /// <param name="Tokuzu">特図</param>
    [Test]
    [Category("Reach Tests")]
    public void SP3ReachTest(
        [Values(4)]  int ReachLine,
        [Range(1, 10)] int Tokuzu
    )
    {
        var reels = Reel.ChooseSP(ReachLine, Tokuzu, "泡＋SP3");

        Assert.AreEqual(IsReach(reels), true);
    }


    /// <summary>
    /// ノーマルリーチのテスト
    /// 当たっちゃわないかテスト
    /// </summary>
    /// <param name="ReachLine">リーチライン</param>
    /// <param name="Tokuzu">特図</param>
    [Test]
    [Category("Reach Tests")]
    public void NormalReachTest(
        [Range(1, 4)]  int ReachLine,
        [Range(1, 10)] int Tokuzu
    )
    {
        var reels = Reel.Choose(ReachLine, Tokuzu);

        Assert.AreEqual(IsReach(reels), true);
    }

    [Test]
    [Category("Reach Tests")]
    public void NotOoatariTest(
        [Range(1, 4)]  int ReachLine,
        [Range(1, 10)] int Tokuzu
    )
    {
        for (int i = 0; i < 100; i++)
        {

            var reels = Reel.Choose(ReachLine, Tokuzu);

            Assert.AreEqual(IsOoatari(reels), false,
                "{0} {1} {2}:RL{3} TZ{4}", reels[0].Tokuzu, reels[1].Tokuzu, reels[2].Tokuzu,
                ReachLine, Tokuzu);

        }

    }

    [Test]
    [Category("Reach Tests")]
    public void NotOoatariTestSP3(
        [Range(4, 4)]  int ReachLine,
        [Range(1, 10)] int Tokuzu
    )
    {
        for (int i = 0; i < 100; i++)
        {

            var reels = Reel.ChooseSP(ReachLine, Tokuzu, "泡＋SP3");

            Assert.AreEqual(IsOoatari(reels), false,
                "{0} {1} {2}:RL{3} TZ{4}", reels[0].Tokuzu, reels[1].Tokuzu, reels[2].Tokuzu,
                ReachLine, Tokuzu);

        }

    }


    /// <summary>
    /// 大当たりしているか調査
    /// </summary>
    /// <param name="reels"></param>
    /// <returns></returns>
    public bool IsOoatari(ReelElement[] reels)
    {
        var cr1 = Ginpara.Reel.CyclicReel1;
        var cr2 = Ginpara.Reel.CyclicReel2;
        var cr3 = Ginpara.Reel.CyclicReel3;

        var cr2List = new List<List<ReelElement>>() {
            Ginpara.Reel.reel2normal,
            Ginpara.Reel.reel2SP_RIGHT,
            Ginpara.Reel.reel2SP_CENTER,
            Ginpara.Reel.reel2SP_LEFT
        };

        foreach (var cr2e in cr2List)
        {
            if (cr2e.Contains(reels[1]))
            {
                cr2 = new CycleSequence<ReelElement>(cr2e);
            }
        }

        var r1 = cr1.SkipWhile(elem => !elem.Sizi.Equals(reels[0].Sizi))
                    .Take(3).ToArray();
        var r2 = cr2.SkipWhile(elem => !elem.Sizi.Equals(reels[1].Sizi))
                    .Take(3).ToArray();
        var r3 = cr3.SkipWhile(elem => !elem.Sizi.Equals(reels[2].Sizi))
                    .Take(3).ToArray();

        var line1 = new String[] { r1[0].Tokuzu, r2[0].Tokuzu, r3[0].Tokuzu };
        var line2 = new String[] { r1[1].Tokuzu, r2[1].Tokuzu, r3[1].Tokuzu };
        var line3 = new String[] { r1[2].Tokuzu, r2[2].Tokuzu, r3[2].Tokuzu };
        var line41 = new String[] { r1[0].Tokuzu, r2[1].Tokuzu, r3[2].Tokuzu };
        var line42 = new String[] { r1[2].Tokuzu, r2[1].Tokuzu, r3[0].Tokuzu };

        var lines = new List<String[]> { line1, line2, line3, line41, line42 };

        var result = false;

        lines.ForEach(line =>
        {
            if (line[0].Equals(line[1]) && line[1].Equals(line[2]))
            {
                if (!line[0].Equals("*"))
                {
                    result = true;
                }
            }
        });

        return result;
    }

    /// <summary>
    /// リーチしているか調査
    /// </summary>
    /// <param name="reels"></param>
    /// <returns></returns>
    public bool IsReach(ReelElement[] reels)
    {
        var a = new List<String>();
        for (int i = 10; i > 0; i--)
        {
            a.Add(i.ToString());
            a.Add("*");
        }

        var cr1 = new CycleSequence<String>(a);

        var b = new List<String>();
        for (int i = 1; i <= 10; i++)
        {
            b.Add(i.ToString());
            b.Add("*");
        }

        var cr2 = new CycleSequence<String>(b);
        var cr3 = new CycleSequence<String>(b);

        var r1 = cr1.SkipWhile(elem => !elem.Equals(reels[0].Tokuzu))
                    .Take(3).ToArray();
        var r2 = cr2.SkipWhile(elem => !elem.Equals(reels[1].Tokuzu))
                    .Take(3).ToArray();
        var r3 = cr3.SkipWhile(elem => !elem.Equals(reels[2].Tokuzu))
                    .Take(3).ToArray();

        var line1 = new String[] { r1[0], r2[0], r3[0] };
        var line2 = new String[] { r1[1], r2[1], r3[1] };
        var line3 = new String[] { r1[2], r2[2], r3[2] };
        var line41 = new String[] { r1[0], r2[1], r3[2] };
        var line42 = new String[] { r1[2], r2[1], r3[0] };

        var lines = new List<String[]> { line1, line2, line3, line41, line42 };

        var result = false;

        lines.ForEach(line =>
        {
            if (line[0].Equals(line[1]) ||
                line[1].Equals(line[2]) ||
                line[0].Equals(line[2])
            )
            {
                result = true;
            }
        });

        return result;
    }

}

