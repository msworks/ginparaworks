using HutongGames.PlayMaker;
using System;

/// <summary>
/// �~�\��
/// </summary>
[ActionCategory("Ginpara")]
public class YenHyozi : FsmStateAction
{
    public FsmInt Yen;
	
	public override void OnEnter()
	{
        Fsm.GameObject.GetComponent<CasinoData>().Exchange = (Decimal)Yen.Value;
		Finish();
	}
}

/// <summary>
/// �h���\��
/// </summary>
[ActionCategory("Ginpara")]
public class DollerHyozi : FsmStateAction
{
    public FsmInt Yen;

    public override void OnEnter()
    {
        // ���[�g�ϊ�
        var doller = (Decimal)Yen.Value / 120m;
        Fsm.GameObject.GetComponent<CasinoData>().Exchange = doller;
        Finish();
    }
}