using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ground;
    private BoxCollider2D groundCollider;

    private static GameManager reference;

    void Awake()
    {
        groundCollider = ground.GetComponent<BoxCollider2D>();
        reference = this;

    }

    public BoxCollider2D GetGroundCollider()
    {
        return groundCollider;
    }

    public static GameManager GetGameManager()
    {
        return reference;
    }

    public float GetLeftBoundary()
    {
        return groundCollider.bounds.min.x;
    }

    public float GetRightBoundary()
    {
        return groundCollider.bounds.size.x;
    }

    public float GetTopBoundary()
    {
        return groundCollider.bounds.size.y;
    }

    public float GetBottomBoundary()
    {
        return groundCollider.bounds.min.y;
    }
}
