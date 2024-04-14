using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public KilledMonstersScripts gameManager; // Ссылка на GameManager для отслеживания убитых монстров
    public Transform[] spawnPoints; // массив точек спауна монстров
    public GameObject[] monsterPrefabs; // массив префабов монстров

    private int currentMonstersToKill = 1; // количество монстров, которых нужно убить в текущей волне
    private int totalMonstersToKill = 0; // общее количество монстров, которых нужно убить

    void Start()
    {
        SpawnMonsters(); // начинаем спавнить монстров
    }

    void SpawnMonsters()
    {
        // Увеличиваем количество монстров, которых нужно убить
        currentMonstersToKill = Mathf.Max(1, currentMonstersToKill); // чтобы не было отрицательных значений
        totalMonstersToKill += currentMonstersToKill;

        // Спауним монстров в зависимости от количества монстров в текущей волне
        for (int i = 0; i < currentMonstersToKill; i++)
        {
            // Выбираем случайную точку спауна и случайного монстра
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            int monsterIndex = Random.Range(0, monsterPrefabs.Length);

            // Спауним монстра
            Instantiate(monsterPrefabs[monsterIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);
        }
    }

    // Метод вызывается, когда монстр убит
    public void OnMonsterKilled()
    {
        // Уведомляем GameManager об убийстве монстра
        gameManager.IncrementKilledMonstersCount();

        // Проверяем, если все монстры в текущей волне убиты
        if (gameManager.GetKilledMonstersCount() >= totalMonstersToKill)
        {
            // Начинаем спавнить следующую волну монстров
            currentMonstersToKill++;
            SpawnMonsters();
        }
    }
}
