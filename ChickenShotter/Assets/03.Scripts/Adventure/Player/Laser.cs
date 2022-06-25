using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float time;
    private bool bigOrSmall;
    private Collider2D[] hit;
    [SerializeField]
    private SkillSound laserSound;

    private void Update()
    {
        if (bigOrSmall)
            time += Time.deltaTime;
        else
            time -= Time.deltaTime;
        transform.localScale = new Vector3(30, Mathf.Lerp(0.1f, 0.3f, time / 0.2f), 1);

        #region °¨Áö
        hit = Physics2D.OverlapBoxAll(transform.position, new Vector2(30, 0.3f), 0);

       
        if (hit != null && time > 0.1f || hit != null && time < 0)
        {
            foreach(Collider2D c in hit)
            {
                if (c.CompareTag("Enemy") && c.name == "BossDragon" || c.CompareTag("Enemy") && c.name == "BossDragon2" || c.CompareTag("Enemy") && c.name == "BossDragon3")
                {
                    Boss enemy = c.GetComponent<Boss>();
                    enemy.DamagedLaser((float)(PlayerManager.Instance.PlayerStrength * 1.25f));
                }
                else if (c.CompareTag("Enemy") && c.name == "HiddenBoss")
                {
                    HiddenBoss enemy = c.GetComponent<HiddenBoss>();
                    enemy.DamagedLaser((float)(PlayerManager.Instance.PlayerStrength) * 3f);
                }
                else if (c.CompareTag("Enemy"))
                {
                    Enemy enemy = c.GetComponent<Enemy>();
                    float cnt = PlayerManager.Instance.PlayerStrength;
                    enemy.BulletDamage(cnt / 5);
                }
            }
            
        }
        
        #endregion
        
        if (time > 0.1f)
        {
            time = 0.1f;
            if (bigOrSmall)
                laserSound.LaserSound();
            bigOrSmall = false;
            
        }
        if (time < 0)
        {
            time = 0;
            bigOrSmall = true;
        }
    }
}
