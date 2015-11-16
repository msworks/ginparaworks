using UnityEngine;
using TheOcean;

/// <summary>
/// 玉を消す
/// </summary>
public class Abandon : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();
        ball.DeleteBall(Route.Abandon);
        //Destroy(collision.gameObject);
    }
}
