using UnityEngine;
using UnityEngine.PlayerLoop;

public class Goblin : MonoBehaviour
{
    public float speed = 3f;
    private GameManager gameManager;

    public float health = 1f;

    void Awake()
    {
        gameManager = GameManager.GetGameManager();
    }
    void Start()
    {
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
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.getPlayer().transform.position, step);
        Death();
    }

    private void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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
