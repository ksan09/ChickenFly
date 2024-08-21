using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    // First Layer - 力老 菊
    //[Header("Layer1")]
    //[SerializeField]
    //private Transform _backgroundLayer1;
    //[SerializeField]
    //private float _layer1MoveSpeed = 0.2f;

    // Second Layer
    [Header("Layer2")]
    [SerializeField]
    private Transform _backgroundLayer2;
    [SerializeField]
    private float _layer2MoveSpeed = 0.12f;

    // Third Layer - 力老 第
    [Header("Layer3")]
    [SerializeField]
    private Transform _backgroundLayer3;
    [SerializeField]
    private float _layer3MoveSpeed = 0.04f;

    //[Header("CloudLayer1")]
    //[SerializeField]
    //private Transform _backgroundCloudLayer1;
    //[SerializeField]
    //private float _cloudLayer1MoveSpeed = 0.3f;

    [Header("CloudLayer2")]
    [SerializeField]
    private Transform _backgroundCloudLayer2;
    [SerializeField]
    private float _cloudLayer2MoveSpeed = 0.15f;

    [Header("CloudLayer3")]
    [SerializeField]
    private Transform _backgroundCloudLayer3;
    [SerializeField]
    private float _cloudLayer3MoveSpeed = 0.1f;

    private void LateUpdate()
    {

        //MoveBackground(_backgroundLayer1, _layer1MoveSpeed, -14.6f, 21.6f);
        MoveBackground(_backgroundLayer2, _layer2MoveSpeed, -14.6f, 21.6f);
        MoveBackground(_backgroundLayer3, _layer3MoveSpeed, -14.6f, 21.6f);

        //MoveBackground(_backgroundCloudLayer1, _cloudLayer1MoveSpeed, -48f, 48f);
        MoveBackground(_backgroundCloudLayer2, _cloudLayer2MoveSpeed, -48f, 48f);
        MoveBackground(_backgroundCloudLayer3, _cloudLayer3MoveSpeed, -48f, 48f);

    }

    private void MoveBackground(Transform background, float speed, float checkValue, float moveValue)
    {

        background.position -= new Vector3(speed * Time.deltaTime, 0f);
        if(background.position.x <= checkValue)
        {
            background.position += new Vector3(moveValue, 0f);
        }

    }







}
