using UnityEngine;
using HutongGames.PlayMaker;

public enum SliderMode
{
    Normal,
    Sequence,
}

/// <summary>
/// �X���C�_�[�̒l���擾����
/// </summary>
[ActionCategory("Ginpara")]
public class GetSliderValue : FsmStateAction
{
    public GameObject Slider;
    public FsmFloat   Value;
    public SliderMode Mode;

    static int seq = 0;

	public override void OnEnter()
	{
        Value.Value = Slider.GetComponent<UISlider>().value;

		Finish();
	}
}

/// <summary>
/// �X���C�_�[�̒l���擾����
/// </summary>
[ActionCategory("Ginpara")]
public class FloatPowerToInt : FsmStateAction
{
    public FsmFloat floatValue;
    public FsmInt intValue;

    static int seq = 0;

    public override void OnEnter()
    {
        var f = floatValue.Value;
        var i = ((int)(f * 256)).Clamp(0, 255);

        intValue.Value = i;

        Finish();
    }
}
