using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float detectionRadius = 5f;
    public GameObject arrowPrefab;

    private float lastAttackTime = 0f;

    private void Update()
    {
        // Поиск ближайшего моба
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider col in hitColliders)
        {
            if (col.CompareTag("Enemy"))
            {
                Attack(col.gameObject);
                break;
            }
        }
    }

    private void Attack(GameObject target)
    {
        if (Time.time - lastAttackTime > 1f / attackSpeed)
        {
            // Создание стрелы и направление на моба
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.GetComponent<ArrowScript>().SetTarget(target.transform);
            lastAttackTime = Time.time;
        }
    }
}
