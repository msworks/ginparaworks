using UnityEngine;
using System.Collections;

public struct GPDirection
{
    public string sizi;
    public float time;

    public GPDirection(string s, float t)
    {
        sizi = s;
        time = t;
    }
};

public class ReelController : MonoBehaviour {

    public GameObject GinparaManager;

    Queue _Direction = new Queue();

    public Queue Direction { get { return _Direction; } }

    public Queue EnqueueDirection( string sizi, float time )
    {
        _Direction.Enqueue(new GPDirection(sizi, time));
        return _Direction;
    }

}
