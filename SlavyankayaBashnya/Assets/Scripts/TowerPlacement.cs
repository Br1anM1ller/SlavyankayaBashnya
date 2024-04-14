using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerBuildPanel; // Ссылка на объект с панелью построек
    private TowerBuildPanel buildPanelScript; // Ссылка на скрипт панели построек

    void Start()
    {
        // Получаем ссылку на скрипт панели построек
        buildPanelScript = this.GetComponent<TowerBuildPanel>();
    }

    void Update()
    {
        // Проверяем, нажата ли кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем выбранный префаб башни из скрипта панели построек
            GameObject selectedTowerPrefab = buildPanelScript.GetSelectedTowerPrefab();

            // Проверяем, что выбранная башня не пустая
            if (selectedTowerPrefab != null)
            {
                // Определяем точку на земле, где находится указатель мыши
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    // Создаем новый экземпляр выбранной башни на точке столкновения луча с землей
                    Instantiate(selectedTowerPrefab, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
