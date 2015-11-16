using UnityEngine;
using HutongGames.PlayMaker;

/// <summary>
/// ‹Ê”­ŽË
/// </summary>
[ActionCategory("Ginpara")]
public class Shoot : FsmStateAction
{
    public GameObject Handle;
    public FsmFloat power;

    public override void OnEnter()
    {
        Handle.GetComponent<ShootBallTest>().ShootBall(power.Value);
        Finish();
    }
}
