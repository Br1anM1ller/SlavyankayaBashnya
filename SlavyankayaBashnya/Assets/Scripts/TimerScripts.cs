using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScripts : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Ссылка на текстовое поле для отображения времени
    public KilledMonstersScripts gameManager; // Ссылка на KilledMonstersScripts для отслеживания убитых монстров

    private float restTime = 5f; // Время отдыха
    private int monstersToKill = 1; // Количество монстров, которых нужно убить
    private bool isResting = true; // Флаг, определяющий, идет ли отдых

    void Update()
    {
        // Если идет отдых, обновляем текстовое поле с временем отдыха
        if (isResting)
        {
            timerText.text = "Rest Time: " + Mathf.RoundToInt(restTime).ToString();
            restTime -= Time.deltaTime;

            // Если время отдыха истекло, переходим к бою
            if (restTime <= 0)
            {
                isResting = false;
                restTime = 0;
            }
        }
        // Если идет бой, обновляем текстовое поле с количеством оставшихся убить монстров
        else
        {
            // Получаем количество убитых монстров из GameManager
            int killedMonsters = gameManager.killedMonstersCount;

            // Вычисляем количество оставшихся убить монстров
            int remainingMonsters = monstersToKill - killedMonsters;

            // Обновляем текстовое поле
            timerText.text = "Monsters to Kill: " + remainingMonsters;

            // Если осталось убить всех монстров, переходим к отдыху
            if (remainingMonsters <= 0)
            {
                isResting = true;
                monstersToKill++; // Увеличиваем количество монстров для следующей волны
            }
        }
    }
}
