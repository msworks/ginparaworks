using UnityEngine;
using HutongGames.PlayMaker;

public enum SliderMode
{
    Normal,
    Sequence,
}

/// <summary>
/// スライダーの値を取得する
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
        if( Mode == SliderMode.Sequence)
        {
            seq++;
            if( seq >= 4096)
            {
                Value.Value = 0f;
            }
            else
            {
                var s = (float)seq;
                Value.Value = s / 4096f;
            }

            Slider.GetComponent<UISlider>().value = Value.Value;
        }
        else if( Mode == SliderMode.Normal)
        {
            Value.Value = Slider.GetComponent<UISlider>().value;
        }

		Finish();
	}
}
