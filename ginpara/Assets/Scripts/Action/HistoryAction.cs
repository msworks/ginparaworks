using HutongGames.PlayMaker;

/// <summary>
/// �q�X�g���[���P��������
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
/// �q�X�g���[���E�ɃV�t�g����
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

