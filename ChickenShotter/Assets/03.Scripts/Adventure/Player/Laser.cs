using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float time;
    private bool bigOrSmall;
    private Collider2D hit;
    

    private void Update()
    {
        if (bigOrSmall)
            time += Time.deltaTime;
        else
            time -= Time.deltaTime;
        transform.localScale = new Vector3(30, Mathf.Lerp(0.1f, 0.3f, time / 0.2f), 1);

        #region °¨Áö
        hit = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y), new Vector2(30, 0.3f), 0);
        if (hit != null)
        {
            if (hit.CompareTag("Enemy") && hit.name == "BossDragon")
            {
                Debug.Log("check1");
                Boss enemy = hit.GetComponent<Boss>();
                float cnt = PlayerManager.Instance.PlayerStrength;
                enemy.DamagedLaser(cnt / 5);
            }
            else if (hit.CompareTag("Enemy"))
            {
                Debug.Log("check2");
                Enemy enemy = hit.GetComponent<Enemy>();
                float cnt = PlayerManager.Instance.PlayerStrength;
                enemy.BulletDamage(cnt / 5);
            }
        }
        
        #endregion
        
        if (time > 0.1f)
        {
            time = 0.1f;
            bigOrSmall = false;
        }
        if (time < 0)
        {
            time = 0;
            bigOrSmall = true;
        }
    }
}
