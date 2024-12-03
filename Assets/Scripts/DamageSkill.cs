using UnityEngine;

public interface DamageSkill
{
    float Damage();
    float CoolDown();

    GameObject GetGameObject();
}
