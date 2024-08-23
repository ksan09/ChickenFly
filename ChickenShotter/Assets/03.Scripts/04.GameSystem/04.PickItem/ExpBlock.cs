using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBlock : PickItem
{

    private SpriteRenderer _sprite;
    private float _expValue = 1f;

    protected override void Awake()
    {
        
        base.Awake();

        _sprite = GetComponent<SpriteRenderer>();

    }

    public void SetExpBlockValue(float expValue)
    {

        _expValue = expValue;

        _sprite.color = Color.green;
        if (expValue >= 5f)
            _sprite.color = Color.yellow;
        else if (expValue >= 10f)
            _sprite.color = Color.magenta;

    }

    protected override void PickItemEffect(Transform playerTrm)
    {
        
        if(playerTrm.TryGetComponent(out PlayerLevel playerLevel))
        {

            playerLevel.AddExp(_expValue);

        }

    }

}
