using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] KeyCode skillKey;
    

    PlayerSkillState skillState;
    [SerializeField] private GameObject firePos; //발사위치
    private Transform tr; //플레이어 트랜스폼
    private SkillSound skillSound; // 스킬 사운드 스크립트
    private Image skillCoolUi; // 스킬 쿨 UI

    private float coolTime;
    public float CoolTime { get { return coolTime; } set { coolTime = value; } }
    private float maxCoolTime;

    #region skillCool
    [SerializeField] private float laserCool;
    [SerializeField] private float machinegunCool;
    [SerializeField] private float shotgunCool;
    [SerializeField] private float energeBallCool;
    [SerializeField] private float guidedMissileCool;
    #endregion

    void Start()
    {
        skillCoolUi = GameObject.Find("Canvas/SkillCool/FillAmount/Filling").GetComponent<Image>();
        tr = transform.GetChild(0).GetComponent<Transform>();
        skillSound = GetComponent<SkillSound>();
        skillState = PlayerManager.Instance.State;
        switch (PlayerManager.Instance.State)
        {
            case PlayerSkillState.Laser:
                Laser();
                break;
            case PlayerSkillState.Machinegun:
                Machinegun();
                break;
            case PlayerSkillState.Shotgun:
                Shotgun();
                break;
            case PlayerSkillState.EnergeBall:
                EnergeBall();
                break;
            case PlayerSkillState.guidedMissile:
                GuidedMissile();
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        if(coolTime <= 0)
        {
            if (skillState == PlayerSkillState.Laser)
                Laser();
            else if (skillState == PlayerSkillState.Machinegun)
                Machinegun();
            else if (skillState == PlayerSkillState.Shotgun)
                Shotgun();
            else if (skillState == PlayerSkillState.EnergeBall)
                EnergeBall();
            else if (skillState == PlayerSkillState.guidedMissile)
                GuidedMissile();
            else
                NullSkill();
        }
        coolTime -= Time.deltaTime;
        skillCoolUi.fillAmount = Mathf.Lerp(0, 1, coolTime / maxCoolTime);
    }
    private void Laser()
    {

    }
    private void Machinegun()
    {

    }
    private void EnergeBall()
    {

    }
    private void Shotgun()
    {
        if(Input.GetKeyDown(skillKey))
        {
            CoolSet(shotgunCool);
            StartCoroutine(cShotgun());
        }
    }
    IEnumerator cShotgun()
    {
        for (int j = 0; j < 2; j++)
        {
            for (float i = 0; i < 5; i++)
            {
                float angle = Random.Range(-25f, 25f);
                BulletDestroy egg = PoolManager.Instance.Pop("Bullet") as BulletDestroy;
                egg.transform.position = firePos.transform.position;
                egg.transform.rotation = Quaternion.Euler(tr.rotation.x, tr.rotation.y * 180, tr.rotation.z + angle);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void GuidedMissile()
    {

    }
    private void NullSkill()
    {

    }
    private void CoolSet(float cool)
    {
        coolTime = cool;
        maxCoolTime = cool;
    }

}
