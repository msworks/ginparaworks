using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;
using UnityEngine;
using TheOcean;
using Prefab = UnityEngine.GameObject;
using MaybeMonad;

public class Post : MonoBehaviour
{
    public static Post Instance { private set; get; }

    [SerializeField]
    Prefab BallPrefab;

    [SerializeField]
    GameObject BodyPath;

    [SerializeField]
    GameObject ShootPosition;

    enum RealDemoMode
    {
        Real,
        Demo,
    }

    enum Mode
    {
        Web,
        Desktop,
    }

    // WEB - 本番
    // DESKTOP - TEST MODE
    //MODE mode = MODE.WEB;
    Mode mode = Mode.Web;

    RealDemoMode realDemo = RealDemoMode.Real;

    static string serverHead = "../pachinko/";
    static string logicHead = "http://localhost:9876/";

    static Dictionary<string, string> verbsLogic = new Dictionary<string, string>()
    {
        {"config", "config"},
        {"init", "init"},
        {"play", "play"},
        {"collect", "collect"},
    };

    static Dictionary<string, string> verbsServer = new Dictionary<string, string>()
    {
        {"config", "config.html"},
        {"init", "init.html"},
        {"play", "play.html"},
        {"collect", "collect.html"},
    };

    string head = logicHead;
    Dictionary<string, string> verbs = verbsLogic;

    void Start()
    {
        Instance = this;

        if( mode==Mode.Web)
        {
            head = serverHead;
            verbs = verbsServer;
        }
        else if( mode == Mode.Desktop)
        {
            head = logicHead;
            verbs = verbsLogic;
        }
    }

    [ActionCategory("Ginpara")]
    public class Open : FsmStateAction
    {
        public Post post;
        public FsmEvent Demo;
        public FsmEvent Real;
        public FsmEvent failed;

        public override void OnEnter()
        {
            var events = new Dictionary<string, FsmEvent>()
            {
                { "Demo", Demo },
                { "Real", Real },
                { "failed", failed },
            };
            post._Open(events);
        }
    }

    [ActionCategory("Ginpara")]
    public class ConnectionFailed : FsmStateAction
    {
        public Post post;

        public override void OnEnter()
        {
            Application.ExternalCall("AlertByUnity", "ConnectionFailed");
        }
    }

    [ActionCategory("Ginpara")]
    public class Config : FsmStateAction
    {
        public Post post;

        public override void OnEnter()
        {
            post.PostConfig();
        }
    }

    [ActionCategory("Ginpara")]
    public class Init : FsmStateAction
    {
        public Post post;

        public override void OnEnter()
        {
            post.PostInit();
        }
    }

    [ActionCategory("Ginpara")]
    public class Play : FsmStateAction
    {
        public Post post;
        public FsmInt bet;
        public FsmInt power;

        public override void OnEnter()
        {
            post.PostPlay(bet.Value, power.Value);
        }
    }

    [ActionCategory("Ginpara")]
    public class Collect : FsmStateAction
    {
        public Post post;

        public override void OnEnter()
        {
            post.PostCollect();
        }
    }

    [ActionCategory("Ginpara")]
    public class Failed : FsmStateAction
    {
        public override void OnEnter()
        {
            // TODO エラーメッセージ
        }
    }

    /// <summary>
    /// サーバーにConfigコマンド発行
    /// </summary>
    public void PostConfig()
    {
        var verb = verbs["config"];
        var url = head + verb;
        var fsm = GetComponent<PlayMakerFSM>();

        var webParam = new Dictionary<string, string>()
        {
        };

        var desktopParam = new Dictionary<string, string>()
        {
            { "gameId", "1" },
            { "userId", "1" },
        };

        Action<WWW> failed = (www) =>
        {
            fsm.SendEvent("Failed");
        };

        Action<WWW> desktopAction = (www) =>
        {
            Debug.Log(www.text);
            var json = new JSONObject(www.text);
            var setting = json.GetField("setting").ToString().ParseInt();
            var reelleft = json.GetField("reelleft").ToString().ParseInt();
            var reelcenter = json.GetField("reelcenter").ToString().ParseInt();
            var reelright = json.GetField("reelright").ToString().ParseInt();
            var seed = json.GetField("seed").ToString().ParseInt();

            fsm.SendEvent("Succeed");
        };

        Action<WWW> webAction = (www) =>
        {
            Debug.Log(www.text);

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(www.text));
            var res = xmlDoc.GetElementsByTagName("response");
            var associate = new Dictionary<string, string>();
            foreach (XmlNode node in res[0].ChildNodes)
            {
                associate.Add(node.Name, node.InnerText);
            }

            var status = associate["status"].ToString();
            var balance = Decimal.Parse(associate["balance"].ToString());
            var setting = associate["setting"].ToString().ParseInt();
            var reelleft = associate["reelLeft"].ToString().ParseInt();
            var reelcenter = associate["reelCenter"].ToString().ParseInt();
            var reelright = associate["reelRight"].ToString().ParseInt();
            var seed = associate["seed"].ToString().ParseInt();

            CasinoData.Instance.Exchange = (Decimal)balance;

            if (status.Contains("error"))
            {
                fsm.SendEvent("Failed");
            }
            else
            {
                fsm.SendEvent("Succeed");
            }
        };

        var param = mode == Mode.Web ? webParam : desktopParam;
        var success = mode == Mode.Web ? webAction : desktopAction;

        PostWWW(url, param, success, failed);
    }

    public void PostInit()
    {
        var verb = verbs["init"];
        var url = head + verb;
        var fsm = GetComponent<PlayMakerFSM>();
        var webParam = new Dictionary<string, string>()
        {
        };

        var desktopParam = new Dictionary<string, string>()
        {
            { "gameId", "1" },
            { "userId", "1" },
        };

        Action<WWW> failed = (www) =>
        {
            fsm.SendEvent("Failed");
        };

        Action<WWW> desktopAction = (www) =>
        {
            //Debug.Log(www.text);
            var json = new JSONObject(www.text);
            fsm.SendEvent("Succeed");
        };

        Action<WWW> webAction = (www) =>
        {
            Debug.Log(www.text);

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(www.text));
            var res = xmlDoc.GetElementsByTagName("response");
            var associate = new Dictionary<string, string>();
            foreach (XmlNode node in res[0].ChildNodes)
            {
                associate.Add(node.Name, node.InnerText);
            }

            var balance = Decimal.Parse(associate["balance"].ToString());

            fsm.SendEvent("Succeed");
        };

        var param = mode == Mode.Web ? webParam : desktopParam;
        var success = mode == Mode.Web ? webAction : desktopAction;

        PostWWW(url, param, success, failed);
    }

    public void PostPlay(int bet, int power)
    {
        var verb = verbs["play"];
        var url = head + verb;
        var fsm = GetComponent<PlayMakerFSM>();

        var betcount = bet;
        var rateCent = (Decimal)Rates.Rate;

        // レートの単位はドル
        var rate = rateCent / (Decimal)100;

        var webParam = new Dictionary<string, string>()
        {
            { "rate", rate.ToString() },
            { "betCount",betcount.ToString() },
            { "power", power.ToString() },
        };

        var desktopParam = new Dictionary<string, string>()
        {
            { "gameId", "1" },
            { "userId", "1" },
            { "betCount", betcount.ToString() },
            { "rate", rate.ToString() },
            { "power", power.ToString() },
        };

        Action<WWW> failed = (www) =>
        {
            fsm.SendEvent("Failed");
        };

        Action<WWW> desktopAction = (www) =>
        {
            var json = new JSONObject(www.text);
            var yaku = (Yaku)json.GetField("yaku").ToString().ParseInt();
            var route = (Route)json.GetField("route").ToString().ParseInt();

            if( route != Route.Abandon)
            {
                Debug.Log(String.Format("yaku:{0} route:{1}", yaku, route));
            }

            var ball = NGUITools.AddChild(BodyPath, BallPrefab);
            ball.transform.position = ShootPosition.transform.position;
            ball.GetComponent<UISprite>().depth = 980;

            var ballComponent = ball.GetComponent<Ball>();
            ballComponent.Power = power;
            ballComponent.Route = route;
            ballComponent.RouteMode = RouteMode.DefinedRoute;

            if (route == Route.Chacker || route == Route.Chacker7)
            {
                if (yaku == Yaku.Atari)
                {
                    MainLogic.Instance.Enqueue(true);
                }
                else
                {
                    MainLogic.Instance.Enqueue(false);
                }
            }

            fsm.SendEvent("Succeed");
        };

        Action<WWW> webAction = (www) =>
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(www.text));
            var res = xmlDoc.GetElementsByTagName("response");
            var associate = new Dictionary<string, string>();
            foreach (XmlNode node in res[0].ChildNodes)
            {
                associate.Add(node.Name, node.InnerText);
            }

            var yaku = (Yaku)associate["yaku"].ToString().ParseInt();
            var route = (Route)associate["route"].ToString().ParseInt();

            Debug.Log(String.Format("yaku:{0} route:{1}", yaku, route));

            var ball = NGUITools.AddChild(BodyPath, BallPrefab);
            ball.transform.position = ShootPosition.transform.position;
            ball.GetComponent<UISprite>().depth = 980;

            var ballComponent = ball.GetComponent<Ball>();
            ballComponent.Power = power;
            ballComponent.Route = route;
            ballComponent.RouteMode = RouteMode.DefinedRoute;

            if (route == Route.Chacker || route == Route.Chacker7)
            {
                if (yaku == Yaku.Atari)
                {
                    MainLogic.Instance.Enqueue(true);
                }
                else
                {
                    MainLogic.Instance.Enqueue(false);
                }
            }

            Debug.Log("Succeed");
            fsm.SendEvent("Succeed");
        };

        var param = mode == Mode.Web ? webParam : desktopParam;
        var success = mode == Mode.Web ? webAction : desktopAction;

        PostWWW(url, param, success, failed);

    }

    public void PostCollect()
    {
        var verb = verbs["collect"];
        var url = head + verb;
        var fsm = GetComponent<PlayMakerFSM>();

        var webParam = new Dictionary<string, string>()
        {
            { "reelStopLeft", "1" },
            { "reelStopCenter", "1" },
            { "reelStopRight", "1" },
            { "oshijun", "1" },
        };

        var desktopParam = new Dictionary<string, string>()
        {
            { "gameId", "1" },
            { "userId", "1" },
            { "reelStopLeft", "1" },
            { "reelStopCenter", "1" },
            { "reelStopRight", "1" },
            { "oshijun", "1" },
        };

        Action<WWW> failed = (www) =>
        {
            fsm.SendEvent("Failed");
        };

        Action<WWW> desktopAction = (www) =>
        {
            //Debug.Log(www.text);
            var json = new JSONObject(www.text);
            var result = json.GetField("result").ToString();
            //var winnings = Decimal.Parse(json.GetField("winnings").ToString());

            fsm.SendEvent("Succeed");
        };

        Action<WWW> webAction = (www) =>
        {
            Debug.Log(www.text);

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(www.text));
            var res = xmlDoc.GetElementsByTagName("response");
            var associate = new Dictionary<string, string>();
            foreach (XmlNode node in res[0].ChildNodes)
            {
                associate.Add(node.Name, node.InnerText);
            }

            var balance = Decimal.Parse(associate["balance"].ToString());
            var result = associate["result"].ToString();

            fsm.SendEvent("Succeed");
        };

        var param = mode == Mode.Web ? webParam : desktopParam;
        var success = mode == Mode.Web ? webAction : desktopAction;

        PostWWW(url, param, success, failed);
    }

    /// <summary>
    /// ログイン
    /// </summary>
    public void _Open(Dictionary<string, FsmEvent> events)
    {
        var fsm = GetComponent<PlayMakerFSM>();

        if (mode == Mode.Desktop)
        {
            var WalletApi = "http://web.ee-gaming.net/apis/wallet1_1/";
            var authenticate = WalletApi + "login.html";

            var msg = string.Format("gameId=1&userId=1&language=ja&operatorId=1&mode=1");

            var kvs = msg.Split('&')
                       .Select(query => query.Split('='))
                       .Select(strings => new KeyValuePair<string, string>(strings[0], strings[1]));

            var param = new Dictionary<string, string>();
            foreach (var kv in kvs)
            {
                param.Add(kv.Key, kv.Value);
            }

            PostOpen(param);
        }
        else if (mode == Mode.Web)
        {
            // Webページに対してパラメータ送信要求
            Application.ExternalCall("GetParameter");
        }
        else
        {
            fsm.SendEvent(events["Failed"].Name);
        }
    }

    public void PostOpen(Dictionary<string, string> param)
    {
        var fsm = GetComponent<PlayMakerFSM>();
        var url = head + "open.html";

        PostWWW(url, param,
            www => { fsm.SendEvent("Real"); },
            www => { fsm.SendEvent("Failed"); }
        );
    }

    /// <summary>
    /// Webページからのレスポンス
    /// </summary>
    /// <param name="msg">gameId=2&token=aaa&language=ja&operatorId=1&mode=1</param>
    public void Response(string msg)
    {
        // デバッグ用にアラートを出す
        //Application.ExternalCall("AlertByUnity", msg);

        var param = new Dictionary<string, string>();

        var kvs = msg.Split('&')
                     .Select(query => query.Split('='))
                     .Select(strings => new KeyValuePair<string, string>(strings[0], strings[1]));

        foreach (var kv in kvs)
        {
            param.Add(kv.Key, kv.Value);
        }

        if(param["mode"]=="0")
        {
            // デモモード
            realDemo = RealDemoMode.Demo;

            // 1000枚セット
            var coinCount = 1000;
        }

        var fsm = GetComponent<PlayMakerFSM>();
        fsm.SendEvent("Real");
    }

    Dictionary<string, string> HashCalculation(Dictionary<string, string> i, string himitsu)
    {
        Func<string> f = () =>
        {
            var list = new List<string>();
            foreach (var l in i)
            {
                list.Add(l.Key + "=" + l.Value);
            }
            return String.Join("&", list.ToArray());
        };

        var s = f() + himitsu;
        var data = System.Text.Encoding.UTF8.GetBytes(s);
        var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        var bs = md5.ComputeHash(data);
        md5.Clear();
        var result = new System.Text.StringBuilder();
        foreach (byte b in bs)
        {
            result.Append(b.ToString("x2"));
        }

        i.Add("hash", result.ToString());

        return i;
    }

    void PostWWW(
        string url,
        Dictionary<string, string> post,
        Action<WWW> success,
        Action<WWW> failed
    )
    {
        StartCoroutine(PostWWWCore(url, post, success, failed));
    }

    /// <summary>
    /// POSTのコア
    /// </summary>
    /// <param name="url"></param>
    /// <param name="post"></param>
    /// <param name="success"></param>
    /// <param name="failed"></param>
    /// <returns></returns>
    IEnumerator PostWWWCore(
        string url,
        Dictionary<string, string> post,
        Action<WWW> success,
        Action<WWW> failed)
    {
        //Debug.Log("POST:url=" + url);

        WWWForm form = new WWWForm();

        if (post != null)
        {
            foreach (KeyValuePair<string, string> post_arg in post)
            {
                form.AddField(post_arg.Key, post_arg.Value);
            }
        }

        WWW www = new WWW(url, form);

        yield return www;

        if (www.error == null)
        {
            success(www);
        }
        else
        {
            failed(www);
        }
    }

    Queue<Message> messageQueue = new Queue<Message>();

    public void Enqueue(Message message)
    {
        messageQueue.Enqueue(message);
    }

    public Option<Message> Dequeue()
    {
        if(messageQueue.Count() == 0)
        {
            return Option<Message>.None();
        }

        var message = messageQueue.Dequeue();

        return Option<Message>.Just(message);
    }

    [ActionCategory("Ginpara")]
    public class WaitMessage : FsmStateAction
    {
        public Post post;
        public FsmEvent Shoot;
        public FsmEvent Progress;

        public override void OnUpdate()
        {
            var message = post.Dequeue();

            if (!message.IsNone)
            {
                if(message.Value== Message.Shoot)
                {
                    Fsm.Event(Shoot);
                }
                else if(message.Value == Message.Progress)
                {
                    Fsm.Event(Progress);
                }
            }
        }
    }

    [ActionCategory("Ginpara")]
    public class CheckMessagePomp : FsmStateAction
    {
        public Post post;
        public FsmEvent ON;
        public FsmEvent OFF;

        public override void OnUpdate()
        {
            var count = post.messageQueue.Count();

            if (count<4)
            {
                Fsm.Event(ON);
            }
            else
            {
                Fsm.Event(OFF);
            }
        }
    }


    [ActionCategory("Ginpara")]
    public class Shoot : FsmStateAction
    {
        public override void OnEnter()
        {
            Post.Instance.Enqueue(Message.Shoot);
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class Progress : FsmStateAction
    {
        public override void OnEnter()
        {
            Post.Instance.Enqueue(Message.Progress);
            Finish();
        }
    }
}

public enum Message
{
    Shoot,
    Progress,
}

