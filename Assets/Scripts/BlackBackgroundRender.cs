using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlackBackgroundRender : MonoBehaviour
{
    #region Properties
    SpriteRenderer _spriteRenderer;
    Material _material;
    bool _activoA; // animaci�n A activa (se vuelve opaco)
    bool _activoB; // animaci�n B activa (se vuelve transparente)
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
        if (_activoA) // si est� activo, el cron�metro y la animaci�n activos
        {
            _contador += Time.deltaTime;
            Color color = _material.color;
            color = new Color(0f, 0f, 0f, _contador);
            _material.color = color;

            if (_contador >= 1) //condici�n finalizaci�n animaci�n A
            {
                _activoA = false;
            }
        }
        else if (_activoB) // si est� activo, el cron�metro y la animaci�n activos
        {
            _contador -= Time.deltaTime;
            Color color = _material.color;
            color = new Color(0f, 0f, 0f, _contador);
            _material.color = color;

            if (_contador <= 0) //condici�n finalizaci�n animaci�n B
            {
                _activoB = false;
            }
        }
    }
}
