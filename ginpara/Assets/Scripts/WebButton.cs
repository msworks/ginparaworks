using UnityEngine;
using System.Collections;

/// <summary>
/// ウェブボタン
/// </summary>
public class WebButton : MonoBehaviour {

    /// <summary>
    /// タップ時処理
    /// </summary>
    public void OnClick()
    {
        Debug.Log("Request Web View");
        var url = "http://www.yahoo.co.jp/";
        var webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) =>
        {
            if (msg == "clicked")
            {
                webViewObject.SetVisibility(false);
            }
        });
        webViewObject.LoadURL(url);
        webViewObject.SetMargins(50, 100, 50, 50);
        webViewObject.SetVisibility(true);
        webViewObject.EvaluateJS(
            "window.addEventListener('load', function() {" +
            "   window.addEventListener('click', function() {" +
            "       Unity.call('clicked');" +
            "   }, false);" +
            "}, false);");
    }
	
}
