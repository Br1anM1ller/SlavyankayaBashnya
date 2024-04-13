using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Уничтожаем стену

            // После разрушения стены вызываем метод PathIsClear() у всех мобов
            EnemyScript[] enemies = FindObjectsOfType<EnemyScript>();
            foreach (EnemyScript enemy in enemies)
            {
                enemy.PathIsClear();
            }
        }
    }
}
