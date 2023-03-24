using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light2DAnim : MonoBehaviour
{
    Light2D _light2DCom;
    bool _sentido = true;
    int _iteraciones = 0;
    void Start()
    {
        _light2DCom = gameObject.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_light2DCom != null)
        {
            if (_iteraciones >= 200)
            {
                _sentido = !_sentido;
                _iteraciones = 0;
            }
            if (_sentido)
            {
                _light2DCom.intensity += 0.005f;
            }
            else
            {
                _light2DCom.intensity -= 0.005f;
            }
            _iteraciones++;
        }
    }
}
