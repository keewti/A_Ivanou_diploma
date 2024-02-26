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
        if (collision.transform.CompareTag("Enemy"))
        {
            var enemy = collision.transform.GetComponent<Enemy>();
            enemy.TakeDMG(player.PlayerStats.DMG);
        }
    }
}
