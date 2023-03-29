using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxAnimation : MonoBehaviour
{
    private Vector3 _alturaFinal;
    private Vector3 _alturaInicial;
    private float _speed = 4.0f;
    private float _time;
    private float _distance;
    private GameObject _player;
    [SerializeField] private GameObject _box;
    void Start()
    {
        _player = GameManager.Player;
    }

    public void AnimacionCaja()
    {
        Debug.Log("cae");
        _alturaFinal = transform.position + new Vector3(0, -2, 0);
        _alturaInicial = transform.position;
        _time = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(_alturaInicial, _alturaFinal, _time);
    }
}
