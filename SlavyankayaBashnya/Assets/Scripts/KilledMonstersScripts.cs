using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KilledMonstersScripts : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // ссылка на текст UI для отображения счетчика убитых монстров
    public int killedMonstersCount = 0; // количество убитых монстров

    // Метод для получения количества убитых монстров
    public int GetKilledMonstersCount()
    {
        return killedMonstersCount;
    }

    void Update()
    {
        // Проверяем, если таймер сражения окончился и начался отдых
        if (countdownText.text == "Battle Time: 0")
        {
            // Обновляем текст UI для отображения количества убитых монстров
            countdownText.text = "Monsters Killed: " + killedMonstersCount;
        }
    }

    // Метод для увеличения количества убитых монстров
    public void IncrementKilledMonstersCount()
    {
        killedMonstersCount++;
    }
}
