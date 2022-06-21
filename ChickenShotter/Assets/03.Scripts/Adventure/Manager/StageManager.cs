using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] private float _clearTime; // 클리어 시간
    [SerializeField] private float _crtTime; // 현재 시간
    [SerializeField] private int _currentStage = 1;
    public int CurrentStage { get { return _currentStage; } set { _currentStage = value; } }
    private Stage _currentStageObject = null;

    private void Start()
    {
        _currentStage = PlayerPrefs.GetInt("crtStage", 0);
        LoadStage(_currentStage);
    }

    public void LoadStage(int idx)
    {
        if (_currentStageObject != null)
        {
            Destroy(_currentStageObject.gameObject);
        }
        Stage stagePrefab = Resources.Load<Stage>($"Stage{idx}");
        _currentStageObject = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);

    }
    public float ClearTime
    {
        get { return _clearTime; }
        set { _clearTime = value; }
    }
    public float CrtTime
    {
        get { return _crtTime; }
        set { _crtTime = value; }
    }
    // Update is called once per frame
    void Update()
    {
        _crtTime += Time.deltaTime;
    }
}
