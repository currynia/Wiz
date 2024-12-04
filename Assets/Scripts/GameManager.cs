using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public GameObject groundGrid;
    private Renderer groundRenderer;

    private static GameManager reference;

    void Awake()
    {
        groundRenderer = groundGrid.GetComponentInChildren<Renderer>();
        reference = this;


    }

    public Renderer GetGroundRenderer()
    {
        return groundRenderer;
    }

    public GameObject GetGroundGrid()
    {
        return groundGrid;
    }

    public static GameManager GetGameManager()
    {
        return reference;
    }

    public float GetLeftBoundary()
    {
        return groundRenderer.bounds.min.x;
    }

    public float GetRightBoundary()
    {
        return groundRenderer.bounds.size.x;
    }

    public float GetTopBoundary()
    {
        return groundRenderer.bounds.size.y;
    }

    public float GetBottomBoundary()
    {
        return groundRenderer.bounds.min.y;
    }
}
