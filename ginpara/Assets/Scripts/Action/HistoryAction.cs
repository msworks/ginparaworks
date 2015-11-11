using HutongGames.PlayMaker;

/// <summary>
/// ヒストリーを１増加する
/// </summary>
[ActionCategory("Ginpara")]
public class AddHistory : FsmStateAction
{
    public override void OnEnter()
    {
        History.Instance.Add();
        Finish();
    }
}

/// <summary>
/// ヒストリーを右にシフトする
/// </summary>
[ActionCategory("Ginpara")]
public class ShiftHistory : FsmStateAction
{
    public override void OnEnter()
    {
        History.Instance.Shift();
        Finish();
    }
}

