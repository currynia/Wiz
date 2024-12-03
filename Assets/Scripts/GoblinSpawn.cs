using System.Collections;
using UnityEngine;

public class GoblinSpwan : MonoBehaviour
{
    public GameObject prefab;

    public GameManager gameManager;

    public float rate = 3f;

    public float timeAfter = 2f;
    public float offset = 0.2f;
    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnGoblin), timeAfter, rate);
    }

    private void SpawnGoblin()
    {
        //0 to spawn from x axis 
        //1 to spawn from y axis

        bool isSpawnFromXBoundary = Random.Range(0, 2) == 1;

        GameObject goblin = Instantiate(prefab);
        if (isSpawnFromXBoundary)
        {
            bool isSpwanFromNegativeEdge = Random.Range(0, 2) == 1;
            goblin.transform.position = new Vector3(
               isSpwanFromNegativeEdge ?
               gameManager.GetLeftBoundary() - offset :
               gameManager.GetRightBoundary() + offset,
               Random.Range(gameManager.GetBottomBoundary(), gameManager.GetTopBoundary()),
               transform.position.z);

        }

        else
        {
            bool isSpwanFromNegativeEdge = Random.Range(0, 2) == 1;
            goblin.transform.position = new Vector3(
              Random.Range(gameManager.GetLeftBoundary(), gameManager.GetRightBoundary()),
              isSpwanFromNegativeEdge ?
              gameManager.GetBottomBoundary() - offset :
              gameManager.GetTopBoundary() + offset,
              transform.position.z);
        }

    }
}
