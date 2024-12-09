using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.2f;
    private SpriteRenderer spriteRenderer;

    public Fireball fireball;
    private static Player reference;
    private float lastFireballTime;

    private Animator animator;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        reference = this;
    }
    private void Update()
    {
        MoveSprite();
        ThrowFireball();
    }

    public static Player GetPlayer()
    {
        return reference;
    }

    private void ThrowFireball()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time - lastFireballTime >= fireball.CoolDown())
        {
            GameObject newFireball = Instantiate(fireball.GetGameObject(), transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), newFireball.GetComponent<Collider2D>());
            lastFireballTime = Time.time;
        }

    }

    private void MoveSprite()
    {

        Vector3 movement = Vector3.zero;
        Boolean isMoving;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
            movement += Vector3.right;
        }

        if (movement != Vector3.zero)
        {
            isMoving = true;
            gameObject.transform.position += movement.normalized * speed * Time.deltaTime;
        }
        else
        {
            isMoving = false;
        }

        animator.SetBool("isMoving", isMoving);

    }

}
