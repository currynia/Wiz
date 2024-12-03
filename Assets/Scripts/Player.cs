using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] sprites;
    public float speed = 0.2f;
    private SpriteRenderer spriteRenderer;

    public Fireball fireball;
    private static Player reference;
    private float lastFireballTime;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        reference = this;
    }

    private void Update()
    {
        MoveSprite();
        ThrowFireball();
    }

    public static Player getPlayer()
    {
        return reference;
    }

    private void ThrowFireball()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time - lastFireballTime >= fireball.CoolDown())
        {
            Instantiate(fireball.GetGameObject(), transform.position, Quaternion.identity);
            lastFireballTime = Time.time;
        }

    }

    private void MoveSprite()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            spriteRenderer.sprite = sprites[0];
            gameObject.transform.position += Vector3.up * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = sprites[0];
            gameObject.transform.position += Vector3.down * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = sprites[1];
            gameObject.transform.position += Vector3.left * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = sprites[2];
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;

        }

    }
}
