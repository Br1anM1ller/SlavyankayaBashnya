using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuildingScript : MonoBehaviour
{
    public int health = 100; // Количество жизней главного здания

    public void TakeDamage(int damage)
    {
        health -= damage; // Уменьшаем количество жизней после получения урона

        // Если у главного здания закончились жизни, завершаем игру или делаем что-то еще
        if (health <= 0)
        {
            // Пример: завершаем игру
            Debug.Log("Главное здание разрушено!");
            // Можно вызвать метод, отвечающий за завершение игры, или выполнить другие действия, например, показать экран поражения.
        }
    }

    public bool IsDestroyed()
    {
        return health <= 0;
    }
}
