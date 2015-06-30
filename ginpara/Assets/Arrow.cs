using HutongGames.PlayMaker;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 使い方
/// Arrowはシングルトンです。
/// 任意のgameObjectにアタッチして下さい。
/// 外部から操作する場合は、
/// Arrow.Instance.State = ArrowState.Left; // 左向き表示
/// Arrow.Instance.State = ArrowState.Hide; // 非表示
/// などとして下さい。
/// </summary>
public class Arrow : MonoBehaviour {

    static Arrow _instance;
    static public Arrow Instance { get { return _instance; } }

    ArrowState state;
    UITexture texture;

    // インスペクタから設定
    public Texture LeftTexture;
    public Texture RightTexture;
    public Texture DownTexture;

    class StateMapElement
    {
        public float Alpha;
        public Texture texture;
    }

    public enum ArrowState
    {
        Hide,
        Left,
        Right,
        Down,
    }

    public ArrowState State
    {
        set
        {
            var hash = new Dictionary<ArrowState, StateMapElement>(){
                { ArrowState.Hide, new StateMapElement(){ Alpha=0.0f, texture=LeftTexture } },
                { ArrowState.Left, new StateMapElement(){ Alpha=1.0f, texture=LeftTexture } },
                { ArrowState.Right, new StateMapElement(){ Alpha=1.0f, texture=RightTexture } },
                { ArrowState.Down, new StateMapElement(){ Alpha=1.0f, texture=DownTexture } },
            };

            var element = hash[value];

            if (element == null)
            {
                Debug.LogError("ArrowクラスでStateに" + value + "がセットされましたが対応していません");
            }

            texture.alpha = element.Alpha;
            texture.mainTexture = element.texture;
        }
    }

    public void LateHide(float time)
    {
        StartCoroutine(LateHideCore(time));
    }

    IEnumerator LateHideCore(float time)
    {
        yield return new WaitForSeconds(time);
        this.State = ArrowState.Hide;
    }

    void Start () {
        _instance = this;
        texture = this.GetComponent<UITexture>();
        this.State = ArrowState.Hide;
	}

    [ActionCategory("Ginpara")]
    public class Down : FsmStateAction
    {
        public override void OnEnter()
        {
            Arrow.Instance.State = ArrowState.Down;
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class Right : FsmStateAction
    {
        public override void OnEnter()
        {
            Arrow.Instance.State = ArrowState.Right;
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class Left : FsmStateAction
    {
        public override void OnEnter()
        {
            Arrow.Instance.State = ArrowState.Left;
            Arrow.Instance.LateHide(7.0f);
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class Hide : FsmStateAction
    {
        public override void OnEnter()
        {
            Arrow.Instance.State = ArrowState.Hide;
            Finish();
        }
    }

}
