using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 2f; // Скорость моба
    public int damage = 1; // Урон моба
    public int maxHealth = 10; // Максимальное количество жизней моба
    public float attackSpeed = 1f; // Скорость атаки моба (атаки в секундах)
    public float attackDistance = 1.5f; // Дистанция, на которой моб начинает атаку

    private int currentHealth; // Текущее количество жизней моба
    private Transform target; // Цель моба (начинает с направленной на стену)
    private float lastAttackTime = 0f; // Время последней атаки
    private bool isAttackingWall = true; // Флаг, указывающий, атакует ли моб стену

    void Start()
    {
        currentHealth = maxHealth;
        target = FindClosestWall(); // На старте ищем ближайшую стену
    }

    void Update()
    {
        if (target == null)
            return;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Если расстояние до цели меньше или равно заданной дистанции атаки, моб начинает атаку
        if (distanceToTarget <= attackDistance)
        {
            if (Time.time - lastAttackTime > 1f / attackSpeed)
            {
                AttackTarget();
                lastAttackTime = Time.time; // Обновляем время последней атаки
            }
        }
        else
        {
            // Иначе двигаем моба в сторону цели
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Поворачиваем моба к цели по оси Y
            Vector3 direction = (target.position - transform.position).normalized;
            direction.y = 0; // Обнуляем направление по оси Y, чтобы сохранить только поворот по горизонтали
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lookRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
        }
    }

    void AttackTarget()
    {
        if (isAttackingWall)
        {
            if (target.CompareTag("Wall"))
            {
                // Если цель - стена, то наносим ей урон
                target.GetComponent<WallScript>().TakeDamage(damage);
            }
            else if (target.CompareTag("MainBuilding"))
            {
                // Если цель - главное здание, выводим сообщение о поражении
                Debug.Log("Главное здание разрушено! Игра окончена!");
            }
        }
        else
        {
            if (target.CompareTag("MainBuilding"))
            {
                // Если цель - главное здание, то наносим ему урон
                target.GetComponent<MainBuildingScript>().TakeDamage(damage);
            }
        }
    }

    // Метод для установки новой цели мобу
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Метод, вызываемый при разрушении стены
    public void PathIsClear()
    {
        // Устанавливаем новую цель - главное здание
        target = GameObject.FindGameObjectWithTag("MainBuilding").transform;
        isAttackingWall = false; // Устанавливаем флаг, что моб атакует главное здание
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Уничтожаем моба, если у него не осталось жизней
        }
    }

    Transform FindClosestWall()
    {
        // Ищем ближайшую стену
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        Transform closestWall = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject wall in walls)
        {
            float distance = Vector3.Distance(transform.position, wall.transform.position);
            if (distance < closestDistance)
            {
                closestWall = wall.transform;
                closestDistance = distance;
            }
        }
        return closestWall;
    }

    // Остальные методы остаются неизменными
}
