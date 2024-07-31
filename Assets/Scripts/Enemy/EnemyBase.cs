using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Create a new enemy")]
public class EnemyBase : ScriptableObject
{
    [Space(10)]
    [Header("Enemy Name")]
    [SerializeField] string name;

    [Space(10)]
    [Header("Enemy Sprite")]
    [SerializeField] Sprite enemySprite;
    [SerializeField] Sprite deathEnemySprite;
    [SerializeField] bool hasDeathSprite;

    [Space(10)]
    [Header("Description")]
    [TextArea]
    [SerializeField] string description;

    [Space(10)]
    [Header("Enemy Stats")]
    [SerializeField] int attack;
    [SerializeField] int speed;
    [SerializeField] int maxHp;

    public string Name
    {
        get { return name; }
    }

    public Sprite EnemySprite
    {
        get { return enemySprite; }
    }

    public Sprite DeathEnemySprite
    {
        get { return deathEnemySprite; }
    }

    public bool HasDeathSprite
    {
        get { return hasDeathSprite; }
    }

    public string Description
    {
        get { return description; }
    }

    public int MaxHp
    {
        get { return maxHp; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Speed
    {
        get { return speed; }
    }
}
