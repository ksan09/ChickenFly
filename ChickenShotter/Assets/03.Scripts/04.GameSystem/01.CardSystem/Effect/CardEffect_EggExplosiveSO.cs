using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSkillEffect_EggExplosiveSO", menuName = "SO/Card/CardEffect/EggExplosive")]
public class CardEffect_EggExplosiveSO : CardEffectSO
{

    LayerMask _enemyLayer;

    public override void UseCardEffect(CardInfoSO cardInfoSO)
    {

        if(PlayerManager.Instance.GetCurrentCardCount(cardInfoSO) == 0)
        {

            _enemyLayer = LayerMask.GetMask("Enemy");
            PlayerManager.Instance.OnPlayerAttackEvent += HandlePlayerAttack;

        }
        else
        {

            PlayerManager.Instance.CardSkillData.explosiveRadius += 1f;
            PlayerManager.Instance.CardSkillData.explosiveDamagePer += 0.1f;

        }

        

    }


    public override void RemoveCardEffect(CardInfoSO cardInfoSO)
    {

        if (PlayerManager.Instance.GetCurrentCardCount(cardInfoSO) == 1)
        {

            PlayerManager.Instance.OnPlayerAttackEvent -= HandlePlayerAttack;

        }
        else
        {

            PlayerManager.Instance.CardSkillData.explosiveRadius -= 1f;
            PlayerManager.Instance.CardSkillData.explosiveDamagePer -= 0.1f;

        }
        

    }

    private void HandlePlayerAttack(Transform hitObj)
    {

        PoolManager poolManager = PoolManager.Instance;
        PlayerManager playerManager = PlayerManager.Instance;

        float scale = playerManager.CardSkillData.explosiveRadius;
        float damage = playerManager.GetPlayerStat().GetPlayerStatData().Strength * playerManager.CardSkillData.explosiveDamagePer;

        PoolingAnimation pAnim = poolManager.Pop("BombParticle", hitObj.position, Quaternion.identity) as PoolingAnimation;
        if(pAnim != null)
        {

            pAnim.transform.localScale = Vector3.one * scale;
            pAnim.PlayAnimation();

        }

        PoolingParticle pParticle = poolManager.Pop("BombWreckParticle", hitObj.position, Quaternion.identity) as PoolingParticle;
        if(pParticle != null)
        {

            pParticle.transform.localScale = Vector3.one * scale / 2;
            pParticle.PlayParticle();

        }

        Collider2D[] cols = Physics2D.OverlapCircleAll(hitObj.position, scale, _enemyLayer);
        for(int i = 0; i < cols.Length; i++)
        {

            if(cols[i].TryGetComponent<HealthObject>(out HealthObject healthObject))
            {

                healthObject.OnHit(damage);

            }

        }

    }

}
