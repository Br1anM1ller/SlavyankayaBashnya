using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public Transform target; // Целевая точка, вокруг которой будет поворачиваться камера
    public float rotationStep = 5f; // Шаг вращения камеры

    public void RotateCameraLeft()
    {
        RotateCamera(-rotationStep);
    }

    public void RotateCameraRight()
    {
        RotateCamera(rotationStep);
    }

    void RotateCamera(float angle)
    {
        // Поворачиваем камеру вокруг целевой точки
        transform.RotateAround(target.position, Vector3.up, angle);
    }
}
