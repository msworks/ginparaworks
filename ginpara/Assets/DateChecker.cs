using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 日付チェッカー
/// </summary>
public class DateChecker : MonoBehaviour {

    static private DateChecker _instance;

    static public DateChecker Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }

    static DateTime start = DateTime.Now;

	void Start () {
        StartCoroutine(Check());
	}

    /// <summary>
    /// 日付を監視し、日付が変わったら回転数を入れ替える
    /// </summary>
    /// <returns></returns>
    IEnumerator Check()
    {
        while (true)
        {
            var time = DateTime.Now;
            var day = time.Day;
            var startDay = start.Day;

            if (day != startDay)
            {
                start = DateTime.Now;
                CasinoData.Instance.ShiftKaitensu();
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    /// <summary>
    /// 開始日付更新(デバッグ用)
    /// </summary>
    /// <param name="dt"></param>
    public void SetStartDate(DateTime dt)
    {
        start = dt;
    }

    /// <summary>
    /// 前日をセットする
    /// </summary>
    [ActionCategory("Ginpara")]
    public class SetPreDate : FsmStateAction
    {
        public override void OnEnter()
        {
            var dt = DateTime.Now;
            var predt = dt.AddDays(-1);
            DateChecker.Instance.SetStartDate(predt);
            Finish();
        }
    }
}
