using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGZone : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = GetComponentInParent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.transform.CompareTag("Enemy"))
        {
            var enemy = collision.transform.parent.GetComponent<Enemy>();
            enemy.TakeDMG(player.PlayerStats.DMG);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.transform.CompareTag("Enemy"))
        {
            var enemy = collision.transform.parent.GetComponent<Enemy>();
            enemy.TakeDMG(player.PlayerStats.DMG);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.transform.CompareTag("Enemy"))
        {
            var enemy = collision.transform.parent.GetComponent<Enemy>();
            enemy.TakeDMG(player.PlayerStats.DMG);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
    }
    private void Update()
    {

    }
}
