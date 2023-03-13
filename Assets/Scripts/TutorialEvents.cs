using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvents : MonoBehaviour
{
    [SerializeField] private GameObject _corazonRoto;

    private void HeartBeatStart()
    {
        Instantiate(_corazonRoto, transform);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
