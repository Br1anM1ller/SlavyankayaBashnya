using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerBuildPanel; // Ссылка на объект с панелью построек
    private TowerBuildPanel buildPanelScript; // Ссылка на скрипт панели построек
    private bool canBuild = true; // Переменная, определяющая, можно ли строить башню в данный момент

    void Start()
    {
        // Получаем ссылку на скрипт панели построек
        buildPanelScript = this.GetComponent<TowerBuildPanel>();
    }

    void Update()
    {
        // Проверяем, нажата ли кнопка мыши и разрешено ли строительство
        if (Input.GetMouseButtonDown(0) && canBuild)
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
                    // Переместить башню над поверхностью земли, учитывая высоту башни
                    Vector3 towerPosition = hit.point + new Vector3(0, selectedTowerPrefab.GetComponent<Renderer>().bounds.extents.y, 0);

                    // Создаем новый экземпляр выбранной башни на точке над поверхностью земли
                    Instantiate(selectedTowerPrefab, towerPosition, Quaternion.identity);

                    // Устанавливаем флаг разрешения строительства в false
                    canBuild = false;
                }
            }
        }
    }

    // Метод для включения возможности строительства
    public void EnableBuilding()
    {
        canBuild = true;
    }

    public void SetBuildingPermission(bool permission)
    {
        canBuild = permission;
    }
}
