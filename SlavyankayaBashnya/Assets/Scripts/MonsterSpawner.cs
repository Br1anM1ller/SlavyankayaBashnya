using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MonsterSpawner : MonoBehaviour
{
    public float waveCooldown = 5f; // Время между волнами
    public GameObject monsterPrefab; // Префаб монстра
    public Transform spawnPoint; // Точка спавна монстров
    private bool waveActive = false; // Флаг, указывающий, идет ли сейчас волна
    private int monstersInWave = 1; // Количество монстров в текущей волне

    void Start()
    {
        // Запускаем корутину для отсчета времени перед началом первой волны
        StartCoroutine(StartWaveCooldown());
    }

    IEnumerator StartWaveCooldown()
    {
        while (true)
        {
            // Ждем указанное время перед началом волны
            yield return new WaitForSeconds(waveCooldown);

            // Если волна уже активна, пропускаем этот цикл
            if (waveActive)
                continue;

            // Начинаем новую волну с текущим количеством монстров
            StartCoroutine(SpawnWave(monstersInWave));

            // Увеличиваем количество монстров в следующей волне
            monstersInWave++;
        }
    }

    IEnumerator SpawnWave(int numMonsters)
    {
        waveActive = true; // Устанавливаем флаг активности волны

        // Спавним монстров
        for (int i = 0; i < numMonsters; i++)
        {
            Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(1f); // Задержка между спавном каждого монстра
        }

        // Ждем, пока все монстры не будут уничтожены
        while (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            yield return null;
        }

        // Когда монстры уничтожены, сбрасываем флаг и начинаем отсчет времени до следующей волны
        waveActive = false;
    }
}
