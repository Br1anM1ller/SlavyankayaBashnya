using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public int maxHealth = 40;
    private int currentHealth;

    // Добавляем событие для оповещения о разрушении стены
    public delegate void WallDestroyed();
    public static event WallDestroyed OnWallDestroyed;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Debug.Log("Стена разрушена!");
            if (OnWallDestroyed != null)
            {
                OnWallDestroyed(); // Сообщаем о разрушении стены
            }
            Destroy(gameObject);
        }
    }

    public bool IsDestroyed()
    {
        return currentHealth <= 0;
    }
}
