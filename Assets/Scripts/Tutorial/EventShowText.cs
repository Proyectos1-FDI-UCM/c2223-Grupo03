using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventShowText : MonoBehaviour
{
    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _text;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(_text, _canvas.transform);
            Destroy(gameObject);
        }
    }
}
