using HutongGames.PlayMaker;
using UnityEngine;

public class Excange : MonoBehaviour
{
    static Excange _instance;
    static public Excange Instance { get { return _instance; } }

	void Start ()
    {
        _instance = this;
	}

    [ActionCategory("Ginpara")]
    public class CheckTama : FsmStateAction
    {
        public FsmEvent On;
        public FsmEvent Off;

        public override void OnEnter()
        {
            var hasCent = (int)(CasinoData.Instance.Exchange * 100);
            var rateCent = (int)Rates.Rate;

            if( rateCent <= hasCent )
            {
                var doller = ((float)(hasCent - rateCent)) / 100.0f;
                CasinoData.Instance.Exchange = doller;
                Fsm.Event(On);
            }
            else
            {
                Fsm.Event(Off);
            }

            Finish();
        }
    }
}
