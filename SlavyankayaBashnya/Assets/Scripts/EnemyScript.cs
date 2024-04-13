using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f; // Скорость движения моба
    public int attackDamage = 1; // Урон, который наносит моб
    public float attackSpeed = 2f; // Скорость атаки моба (в секундах)
    public int maxHealth = 10; // Максимальное количество жизней моба

    private int currentHealth; // Текущее количество жизней моба
    private Transform target; // Цель, к которой движется моб (стена)
    private bool roadOpen = false; // Флаг, показывающий, открыта ли дорога

    public Transform mainBuilding;

    private void Start()
    {
        currentHealth = maxHealth; // Устанавливаем начальное количество жизней
        // Находим стену как цель для движения
        target = GameObject.FindGameObjectWithTag("Wall").transform;
        // Подписываемся на событие разрушения стены
        WallScript.OnWallDestroyed += OpenRoad;
    }

    private void OnDestroy()
    {
        // Отписываемся от события перед уничтожением объекта
        WallScript.OnWallDestroyed -= OpenRoad;
    }

    private void OpenRoad()
    {
        // Устанавливаем флаг в true, когда стена разрушена
        roadOpen = true;
    }

    private void Update()
    {
        if (roadOpen)
        {
            // Если дорога открыта, мобы идут атаковать главное здание
            MoveTowards(mainBuilding.position);
        }
        else
        {
            // В противном случае, мобы двигаются в сторону стены
            MoveTowards(target.position);
        }
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        // Логика движения моба к цели
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Уменьшаем количество жизней после получения урона

        // Если у моба закончились жизни, уничтожаем его
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Получаем компонент WallScript из объекта стены
            WallScript wall = collision.gameObject.GetComponent<WallScript>();

            // Проверяем, что компонент WallScript присутствует
            if (wall != null)
            {
                // Уничтожаем стену
                wall.DestroyWall();
            }
        }
    }
}
