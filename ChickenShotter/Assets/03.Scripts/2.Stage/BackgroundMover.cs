using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    // First Layer - 力老 菊
    [Header("Layer1")]
    [SerializeField]
    private Transform _backgroundLayer1;
    [SerializeField]
    private float _layer1MoveSpeed = 0.2f;

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

    private void LateUpdate()
    {

        _backgroundLayer1.position += new Vector3(_layer1MoveSpeed * Time.deltaTime, 0f);
        _backgroundLayer2.position += new Vector3(_layer2MoveSpeed * Time.deltaTime, 0f);
        _backgroundLayer3.position += new Vector3(_layer3MoveSpeed * Time.deltaTime, 0f);

    }







}
