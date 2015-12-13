using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TheOcean;
using System;
using System.Linq;
using System.IO;
using System.Xml;

public enum RouteMode
{
    Physical,
    DefinedRoute,
}

/// <summary>
/// 生成するときにPowerを設定すること
/// ソースが汚くなりすぎた。要リファクタリング
/// </summary>
public class Ball : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();

    public static int Syokyu15Count = 0;

    /// <summary>
    /// Power min:0 max:255
    /// </summary>
    public int Power
    {
        get; set;
    }

    public RouteMode RouteMode
    {
        set
        {
            if( value == RouteMode.DefinedRoute)
            {
                //this.gameObject.GetComponent<Rigidbody2D>().Sleep();
                StartCoroutine(routing());
            }
        }
    }

    public Route Route
    {
        set; get;
    }

    IEnumerator routing()
    {
        var r1 = Routes.Where(r => r.route == Route);

        if(r1.Count() == 0)
        {
            Debug.Log(String.Format("NO ROUTE:{0}",Route));
            yield break;
        }

        var r2 = r1.Where(r => r.power == Power);

        var direction = 1;

        while(r2.Count() == 0)
        {
            Power += direction;

            if (Power == 256)
            {
                direction = -1;
            }

            if(Power==0 && direction == -1)
            {
                Debug.Log(String.Format("NO ROUTE:{0} POWER{1}", Route, Power));
                yield break;
            }

            r2 = r1.Where(r => r.power == Power);
        }

        var c = r2.Count();
        var route = r2.ToArray()[rnd.Next(0, c-1)];

        foreach(var p in route.positions)
        {
            this.transform.position = p;
            yield return new WaitForSeconds(2f/60f);
        }

        var lastPosition = route.positions.Last();

        // ルートに応じたイベント発生
        {
            var Uchidashi = GameObject.Find("Uchidashi");
            var Kenri = GameObject.Find("Kenri");
            var Horyu = GameObject.Find("Horyu");
            var Kaitentai = GameObject.Find("KaitenTai");
            var MainLogic = GameObject.Find("MainLogic");
            var Atacker = GameObject.Find("Atacker");

            if (Route == Route.Abandon)
            {
                // なにもしない
            }
            else if( Route==Route.Syokyu7)
            {
                AudioManager.Instance.PlaySE(19);
                Uchidashi.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmInt("tama").Value += 7;
            }
            else if(Route==Route.Syokyu15)
            {
                AudioManager.Instance.PlaySE(19);
                Uchidashi.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmInt("tama").Value += 7;

                Syokyu15Count++;
                if (Syokyu15Count >= 10)
                {
                    // ラウンド終了メッセージを送信
                    Kenri.GetComponent<PlayMakerFSM>().SendEvent("ラウンド終了");
                    Syokyu15Count = 0;
                }
            }
            else if(Route==Route.Chacker)
            {
                Horyu.GetComponent<PlayMakerFSM>().SendEvent("チャッカー通過");
            }
            else if(Route==Route.Chacker7)
            {
                Horyu.GetComponent<PlayMakerFSM>().SendEvent("チャッカー通過");
                AudioManager.Instance.PlaySE(19);
                Uchidashi.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmInt("tama").Value += 7;
            }
            else if(Route==Route.Kaitenti)
            {
                Kaitentai.gameObject.GetComponent<PlayMakerFSM>().SendEvent("玉通過");
            }
            else if(Route==Route.Atacker)
            {
                // アタッカー待ちか？
                if(Atacker.GetComponent<PlayMakerFSM>().ActiveStateName == "９秒開放")
                {
                    // アタッカーに入った→権利獲得
                    MainLogic.GetComponent<PlayMakerFSM>().SendEvent("権利獲得成功");
                    //OpenAtacker.GetComponent<PlayMakerFSM>().SendEvent("入賞");

                    Kenri.GetComponent<PlayMakerFSM>().SendEvent("権利発生");

                    Atacker.GetComponent<PlayMakerFSM>().SendEvent("権利獲得成功");

                    Post.Instance.Enqueue(Message.Progress);
                }
            }
            else if(Route==Route.Nothing)
            {
                // ここにはこないはず
            }
        }

        DeleteBall();

    }

    void DeleteBall()
    {
        Destroy(this.gameObject);
    }

    public void DeleteBall(Route route)
    {
        // 軌道と力と結果を保存

        if( route != Route.Abandon)
        {
            BallRouteSerializer.Add(
                new BallRoute
                {
                    power = Power,
                    route = route,
                    positions = positions
                }
            );
        }

        Destroy(this.gameObject);
    }

    void Start ()
    {
        Count++;

        // 30秒経っても玉が残っている場合は玉を消す
        StartCoroutine(DeleteBall(30f));
    }

    void Update()
    {
        positions.Add(transform.position);
    }

    IEnumerator DeleteBall(float time)
    {
        // タイムアウトした玉の軌道は保存しない
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        Count--;
    }

    //-- static

    static public int Count
    {
        get; private set;
    }

    static List<BallRoute> Routes = new List<BallRoute>();

    static System.Random rnd;

    /// <summary>
    /// 静的コンストラクタ
    /// </summary>
    public static void LoadBall()
    {
        var seed = (int)(System.DateTime.Now.Ticks & 0xFFFF);
        rnd = new System.Random(seed);

        var dic = new Dictionary<string, int>()
        {
            { "Abandon"  , 0x0000 },
            { "Chacker"  , 0x0100 },
            { "Chacker7" , 0x1107 },
            { "Syokyu7"  , 0x1007 },
            { "Syokyu15" , 0x100F },
            { "Kaitenti" , 0x0200 },
            { "Atacker"  , 0x0300 },
        };

        // 静的コンストラクタ内だとWebPlayerの場合
        // Resources.Loadで落ちる 

        var stageTextAsset = Resources.Load("ballRouteA") as TextAsset;
        var routeData = stageTextAsset.text;
        var reader = new StringReader(routeData);
        var xmlDoc = new XmlDocument();

        xmlDoc.Load(reader);

        var res = xmlDoc.GetElementsByTagName("Routes");

        var associate = new Dictionary<string, string>();

        var rts = new List<BallRoute>();

        foreach (XmlNode node in res[0].ChildNodes)
        {
            var power = node.ChildNodes
                .Enumerable()
                .Where(n => n.Name == "power")
                .Select(n => int.Parse(n.InnerText))
                .FirstOrDefault();

            var route = node.ChildNodes
                .Enumerable()
                .Where(n => n.Name == "route")
                .Select(n => (Route)dic[n.InnerText])
                .FirstOrDefault();

            var positions = node.ChildNodes
                .Enumerable()
                .Where(n => n.Name == "positions")
                .Select(n => n.ChildNodes
                              .Enumerable()
                              .Select(e => new Vector3()
                              {
                                  x = float.Parse(e.ChildNodes[0].InnerText),
                                  y = float.Parse(e.ChildNodes[1].InnerText),
                                  z = float.Parse(e.ChildNodes[2].InnerText)
                              })
                       )
                .FirstOrDefault()
                .ToList();

            var rt = new BallRoute()
            {
                power = power,
                route = route,
                positions = positions
            };

            Routes.Add(rt);
        }

        reader.Close();
    }
}

static class XmlNodeListExtension
{
    static public IEnumerable<XmlNode> Enumerable(this XmlNodeList source)
    {
        foreach (XmlNode node in source)
        {
            yield return node;
        }
    }
}
