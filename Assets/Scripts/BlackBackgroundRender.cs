using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlackBackgroundRender : MonoBehaviour
{
    #region Properties
    SpriteRenderer _spriteRenderer;
    Material _material;
    bool _activoA; // animación A activa (se vuelve opaco)
    bool _activoB; // animación B activa (se vuelve transparente)
    float _contador = 1; // tiempo que ha trancurrido
    #endregion
    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _material = _spriteRenderer.material;
    }

    private void OnTriggerEnter2D(Collider2D collision) // si entra
    {
        if (collision.tag == "Player" || collision.tag == "PlayerInCloset") // si es el jugador
        {
            _activoB = true;
            _activoA = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // si sale
    {
        if (collision.tag == "Player" || collision.tag == "PlayerInCloset") // si es el jugador
        {
            _activoA = true;
            _activoB = false;
        }
    }

    private void Update()
    {
        if (_activoA) // si está activo, el cronómetro y la animación activos
        {
            _contador += Time.deltaTime;
            Color color = _material.color;
            color = new Color(0f, 0f, 0f, _contador);
            _material.color = color;

            if (_contador >= 1) //condición finalización animación A
            {
                _activoA = false;
            }
        }
        else if (_activoB) // si está activo, el cronómetro y la animación activos
        {
            _contador -= Time.deltaTime;
            Color color = _material.color;
            color = new Color(0f, 0f, 0f, _contador);
            _material.color = color;

            if (_contador <= 0) //condición finalización animación B
            {
                _activoB = false;
            }
        }
    }
}
