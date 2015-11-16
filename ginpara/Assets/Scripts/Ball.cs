using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TheOcean;

/// <summary>
/// 生成するときにPowerを設定すること
/// </summary>
public class Ball : MonoBehaviour
{
    static public int Count
    {
        get; private set;
    }

    List<Vector3> positions = new List<Vector3>();

    /// <summary>
    /// Power min:0 max:255
    /// </summary>
    public int Power
    {
        get; set;
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

    public void DeleteBall(Route route)
    {
        // 軌道と力と結果を保存

        Debug.Log(string.Format("[Delete Ball]Power:{0} Route:{1}", Power, route));

        Destroy(this.gameObject);
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
}
