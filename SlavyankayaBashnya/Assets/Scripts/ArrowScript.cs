using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;

    private Transform target;

    void Start()
    {
        // Направляем стрелу в сторону моба при создании
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

    private void Update()
    {
        if (target != null)
        {
            // Двигаем стрелу вперед
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            // Если моб уничтожен до попадания стрелы
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        // Направляем стрелу в сторону моба после установки цели
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Наносим урон мобу и уничтожаем стрелу при столкновении с ним
            other.GetComponent<EnemyScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
