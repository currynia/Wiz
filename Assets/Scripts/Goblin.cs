using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Goblin : MonoBehaviour
{
    public float speed = 3f;
    private GameManager gameManager;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    public GameObject attackPoint;

    public float attackRaidus;
    private readonly float _health;

    public float attackRange;

    public LayerMask playerLayer;
    public float Health
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

    private Vector3 position;

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


        if (Vector3.Magnitude(transform.position - Player.GetPlayer().transform.position) <= attackRange)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
            Move();
        }
    }

    private void Move()
    {
        var step = speed * Time.deltaTime;
        Vector3 movement = Vector3.MoveTowards(transform.position, Player.GetPlayer().transform.position, step);
        position = movement;
        bool isFacingLeft = movement.x < transform.position.x;
        spriteRenderer.flipX = isFacingLeft;
        Vector3 attackPointLocalPosition = attackPoint.transform.localPosition;
        attackPointLocalPosition.x = Mathf.Abs(attackPointLocalPosition.x) * (isFacingLeft ? -1 : 1);
        attackPoint.transform.localPosition = attackPointLocalPosition;

        animator.SetBool("isMoving", transform.position != movement);
        transform.position = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHitByAttack(collision);
    }

    private void Attack()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRaidus, playerLayer);
        foreach (Collider2D p in player)
        {
            print("Player hit");
        }
    }

    private void HandleHitByAttack(Collision2D collision)
    {
        DamageSkill[] damageSkills = collision.gameObject.GetComponents<DamageSkill>();
        foreach (DamageSkill skill in damageSkills)
        {
            Health -= skill.Damage();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRaidus);
    }
}
