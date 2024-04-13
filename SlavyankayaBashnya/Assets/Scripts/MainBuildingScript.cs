using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuildingScript : MonoBehaviour
{
    public int maxHealth = 50; // Максимальное количество жизней главного здания

    private int currentHealth; // Текущее количество жизней главного здания

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Уменьшаем жизни главного здания

        if (currentHealth <= 0)
        {
            // Если жизни закончились, сообщаем об окончании игры
            Debug.Log("Главное здание разрушено! Игра окончена!");
        }
    }
}
