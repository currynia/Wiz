using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Goblin : MonoBehaviour
{
    public float speed = 3f;
    private GameManager gameManager;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    private readonly float _health;
    public float health
    {
        get { return _health; }
        set
        {
            if (_health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void Start()
    {
        gameManager = GameManager.GetGameManager();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        IgnoreCollisions();
    }

    private void IgnoreCollisions()
    {
        foreach (Collider2D collider in gameManager.groundGrid.GetComponents<Collider2D>())
        {
            Physics2D.IgnoreCollision(
                GetComponent<Collider2D>(),
                collider
                );
        }
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var step = speed * Time.deltaTime;
        Vector3 movement = Vector3.MoveTowards(transform.position, Player.getPlayer().transform.position, step);
        spriteRenderer.flipX = movement.x < transform.position.x;
        animator.SetBool("isMoving", transform.position != movement);
        transform.position = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHitByAttack(collision);
    }

    private void HandleHitByAttack(Collision2D collision)
    {
        DamageSkill[] damageSkills = collision.gameObject.GetComponents<DamageSkill>();
        foreach (DamageSkill skill in damageSkills)
        {
            health -= skill.Damage();
        }
    }
}
