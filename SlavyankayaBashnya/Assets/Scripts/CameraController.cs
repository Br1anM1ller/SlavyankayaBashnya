using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform target; // Целевая точка, вокруг которой будет поворачиваться камера
    public float rotationSpeed = 1f; // Скорость вращения камеры

    public void RotateCameraLeft()
    {
        RotateCamera(-1f);
    }

    public void RotateCameraRight()
    {
        RotateCamera(1f);
    }

    void RotateCamera(float direction)
    {
        // Поворачиваем камеру вокруг целевой точки
        transform.RotateAround(target.position, Vector3.up, direction * rotationSpeed * Time.deltaTime);
    }
}
