using UnityEngine;

public class Goblin : MonoBehaviour
{
    public float speed = 3f;
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.GetGameManager();
    }
    void Start()
    {
        Physics2D.IgnoreCollision(
            GetComponent<Collider2D>(),
            gameManager.GetGroundCollider().GetComponent<Collider2D>());
    }
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.getPlayer().transform.position, step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("LOL");
    }
}
