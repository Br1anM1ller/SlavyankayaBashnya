using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimerScripts : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Ссылка на компонент TextMeshProUGUI
    public float timeRemaining = 5f; // Время на отсчет

    void Start()
    {
        UpdateTimerText();
        StartCoroutine(StartWaveCooldown());
    }

    void UpdateTimerText()
    {
        // Обновляем текст с отсчетом времени
        timerText.text = Mathf.RoundToInt(timeRemaining).ToString();
    }

    IEnumerator StartWaveCooldown()
    {
        // Ждем, пока есть активные враги
        while (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            yield return null;
        }

        // Когда нет активных врагов, начинаем отсчет времени перед следующей волной

        // Пока есть время перед следующей волной, обновляем текст и ждем одну секунду
        while (timeRemaining > 0)
        {
            UpdateTimerText();
            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;
        }

        // Когда время вышло, сбрасываем таймер и устанавливаем текст в "5"
        timeRemaining = 5f;
        UpdateTimerText();

        // Запускаем новый отсчет времени перед следующей волной
        StartCoroutine(StartWaveCooldown());
    }
}
