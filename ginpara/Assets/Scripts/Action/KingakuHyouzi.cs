using HutongGames.PlayMaker;

/// <summary>
/// 円表示
/// </summary>
[ActionCategory("Ginpara")]
public class YenHyozi : FsmStateAction
{
    public FsmInt Yen;
	
	public override void OnEnter()
	{
        Fsm.GameObject.GetComponent<CasinoData>().Exchange = (float)Yen.Value;
		Finish();
	}
}

/// <summary>
/// ドル表示
/// </summary>
[ActionCategory("Ginpara")]
public class DollerHyozi : FsmStateAction
{
    public FsmInt Yen;

    public override void OnEnter()
    {
        // レート変換
        var doller = (float)Yen.Value / 120f;
        Fsm.GameObject.GetComponent<CasinoData>().Exchange = doller;
        Finish();
    }
}