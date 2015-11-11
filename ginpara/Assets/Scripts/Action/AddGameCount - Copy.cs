using UnityEngine;
using HutongGames.PlayMaker;

[ActionCategory("Ginpara")]
public class AddGameCount : FsmStateAction
{
	public override void OnEnter()
	{
        CasinoData.Instance.BB++;

        var KakuhenKaisu = MainLogic.Instance.KenriKaisu;
        Debug.Log("権利回数：" + KakuhenKaisu);

        if (KakuhenKaisu != 0)
        {
            CasinoData.Instance.RB++;
        }

        Finish();
    }
}
