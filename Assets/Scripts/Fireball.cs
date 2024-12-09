using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour, DamageSkill
{
    private Vector3 direction;

    private SpriteRenderer spriteRenderer;

    public static float speed = 2f;

    private GameManager gameManager;

    public float coolDown = 1f;

    public float damage = 1f;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        direction = Vector3.Normalize(Input.mousePosition - Player.GetPlayer().transform.position);
        transform.Rotate(0, 0, Vector3.SignedAngle(Vector3.right, direction, new Vector3(0, 0, 1)));


        gameManager = GameManager.GetGameManager();
    }
    void Update()
    {
        MoveFireball();
    }

    private void MoveFireball()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public float Damage()
    {
        return damage;
    }

    public float CoolDown()
    {
        return coolDown;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
    }
}
