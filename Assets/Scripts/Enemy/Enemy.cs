using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int maxHp;
    int enemiesDefeated;
    public bool died = false;

    public event Action OnDie = null;

    public SpriteRenderer spriteRenderer;

    public EnemyBase _enemyBase;
    public EnemyBase Base
    {
        get { return _enemyBase; }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = GameObject.Find("Player");  //Set the position reference
        spriteRenderer.sprite = Base.EnemySprite;
        maxHp = Base.MaxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.instance.gameOver == false && died == false)
        {
            EnemyMovement();
        }
    }

    void EnemyMovement()
    {
        Vector3 distance = (GameManager.instance.player.transform.position - transform.position);  //Direction of the movement
        transform.Translate(distance * Base.Speed * Time.deltaTime * 0.01f);  //The movement
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            var controller = GameManager.instance;

            maxHp -= controller.weaponDamage;
            Debug.Log(maxHp);
            
            if (maxHp <= 0)
            {
                died = true;

                if (Base.HasDeathSprite)
                {
                    spriteRenderer.sprite = Base.DeathEnemySprite; //Spawn of the death enemy
                    spriteRenderer.color = Color.gray;
                }

                StartCoroutine(Wait(1.5f));

                enemiesDefeated++;
                controller.wavesNumber.text = "Enemies defeated: " + enemiesDefeated;  //Keeps the number of waves defeated
            }
        }
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);  //Death of the enemy

        if (OnDie != null)
            OnDie();
    }
}
