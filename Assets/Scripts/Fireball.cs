using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour, DamageSkill
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite[] sprites;
    private int spriteIndex = 0;

    private Vector3 direction;

    private SpriteRenderer spriteRenderer;

    public static float speed = 2f;

    private GameManager gameManager;

    public float coolDown = 1f;

    public float damage = 1f;


    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        direction = Vector3.Normalize(Input.mousePosition - Player.getPlayer().transform.position);
        gameManager = GameManager.GetGameManager();
    }
    void Update()
    {
        AnimateSprite();
        MoveFireball();
    }

    private void MoveFireball()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
        spriteIndex++;
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
