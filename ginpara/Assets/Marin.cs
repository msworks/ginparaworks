using UnityEngine;
using System.Collections;

public class Marin : MonoBehaviour
{
    public GameObject Yobikomi;
    public Transform Goal;

    Vector3 from;
    Vector3 to;

    static Marin _instance;
    static public Marin Instance { get { return _instance; } }

    void Start()
    {
        _instance = this;
        from = Yobikomi.transform.position;
        to = Goal.transform.position;
    }

    public void display()
    {
        iTween.MoveTo(Yobikomi, iTween.Hash("y", to.y, "time", 2f));
    }

    public void hide()
    {
        iTween.MoveTo(Yobikomi, iTween.Hash("y", from.y, "time", 2f));
    }
}
