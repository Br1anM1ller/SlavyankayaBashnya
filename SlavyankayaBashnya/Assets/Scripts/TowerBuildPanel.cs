using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuildPanel : MonoBehaviour
{
    public GameObject buildPanel; // Ссылка на панель с постройками
    public Button[] towerButtons; // Массив кнопок для выбора башен
    public GameObject[] towerPrefabs; // Массив префабов башен

    private GameObject selectedTowerPrefab; // Префаб выбранной башни

    void Start()
    {
        // Подписываем каждую кнопку на событие нажатия
        for (int i = 0; i < towerButtons.Length; i++)
        {
            int index = i; // Сохраняем значение i для использования в замыкании
            towerButtons[i].onClick.AddListener(() => SelectTower(index));
        }
    }

    // Метод для выбора башни
    public void SelectTower(int index)
    {
        // Устанавливаем выбранный префаб
        selectedTowerPrefab = towerPrefabs[index];
    }

    // Метод для открытия или закрытия панели с постройками
    public void ToggleBuildPanel()
    {
        // Проверяем, активна ли панель в данный момент
        if (buildPanel.activeSelf)
        {
            // Если активна, то скрываем панель
            buildPanel.SetActive(false);
        }
        else
        {
            // Если не активна, то отображаем панель
            buildPanel.SetActive(true);
        }
    }

    // Метод для получения выбранного префаба
    public GameObject GetSelectedTowerPrefab()
    {
        return selectedTowerPrefab;
    }
}
