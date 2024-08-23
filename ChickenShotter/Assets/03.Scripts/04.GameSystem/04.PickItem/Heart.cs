using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PickItem
{

    protected override void PickItemEffect(Transform playerTrm)
    {

        PlayerManager.Instance.GetPlayerHealth().AddHealth(
            PlayerManager.Instance.GetPlayerStat().GetPlayerStatData().HealValue);

    }

}
