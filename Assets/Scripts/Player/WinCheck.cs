using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinCheck : MonoBehaviour
{
    public static UnityEvent IsWon = new();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            IsWon.Invoke();
        }
    }
}
