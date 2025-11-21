using System;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Health healthS;
    private int amount=1;
    private void Awake()
    {
         GameObject.Find("Player").TryGetComponent<Health>(out healthS);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision !=null && collision.CompareTag("Player"))
        {
            healthS.TakeDamage(amount);
            Destroy(gameObject);
        }
    }
}
