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

    ArrowState state = ArrowState.Hide;
    UITexture texture;
    Vector3 originalPosition;

    // インスペクタから設定
    public Texture LeftTexture;
    public Texture RightTexture;
    public Texture DownTexture;

    class StateMapElement
    {
        public float Alpha;
        public Texture texture;
        public Vector3 moveTo;
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
            var element = hash[value];

            if (element == null)
            {
                Debug.LogError("ArrowクラスでStateに" + value + "がセットされましたが対応していません");
            }

            texture.alpha = element.Alpha;
            texture.mainTexture = element.texture;
            texture.gameObject.transform.position = originalPosition;

            state = value;
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

    Dictionary<ArrowState, StateMapElement> hash;
    Hashtable origin;

    void Start ()
    {
        _instance = this;
        texture = this.GetComponent<UITexture>();
        originalPosition = this.transform.position;

        hash = new Dictionary<ArrowState, StateMapElement>(){
            { ArrowState.Hide, new StateMapElement(){ Alpha=0.0f, texture=LeftTexture, moveTo = Vector3.zero } },
            { ArrowState.Left, new StateMapElement(){ Alpha=1.0f, texture=LeftTexture, moveTo = Vector3.left } },
            { ArrowState.Right, new StateMapElement(){ Alpha=1.0f, texture=RightTexture, moveTo = Vector3.right } },
            { ArrowState.Down, new StateMapElement(){ Alpha=1.0f, texture=DownTexture, moveTo = Vector3.down } },
        };

        this.State = ArrowState.Hide;
	}

    float time;
    float hz = 0.5f;
    float length = 0.03f;

    void Update()
    {
        time += Time.deltaTime;

        var delta = length * Mathf.Sin(Mathf.PI * time / hz);
        gameObject.transform.position = originalPosition + hash[state].moveTo * delta;

        if (time > hz)
        {
            time = 0;
        }
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
