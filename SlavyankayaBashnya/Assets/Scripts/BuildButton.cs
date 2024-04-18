using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    public TowerPlacement towerPlacement; // Ссылка на скрипт TowerPlacement

    void Start()
    {
        // Получаем ссылку на скрипт TowerPlacement
        towerPlacement = FindObjectOfType<TowerPlacement>();
    }

    public void BuildTower()
    {
        // Вызываем метод SetBuildingPermission() со значением true, чтобы разрешить строительство
        towerPlacement.SetBuildingPermission(true);
    }
}
