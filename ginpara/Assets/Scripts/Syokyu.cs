using UnityEngine;
using System.Collections;

/// <summary>
/// 賞球クラス
/// </summary>
public class Syokyu : MonoBehaviour {

    public GameObject Uchidashi;
    public int Syokyusu;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);

            Uchidashi.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmInt("tama").Value += Syokyusu;


        }
    }
}
