using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject imagePanelSettings; // Ссылка на панель настроек

    public void OpenSettingsPanel()
    {
        imagePanelSettings.SetActive(true); // Активируем панель настроек при нажатии кнопки
    }
}
