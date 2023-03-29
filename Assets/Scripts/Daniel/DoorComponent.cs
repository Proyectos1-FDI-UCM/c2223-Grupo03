using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorComponent : MonoBehaviour
{
    #region Referencias
    [Header("Animacion")]
    private Animator _animator;
    private AudioSource _source;
    private float _audioVolume;
    #endregion

    #region Metodos
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
        _audioVolume = _source.volume;
    }

    private void UpdateSound()
    {
        _source.volume = _audioVolume * GameManager.Instance.getSFX;
    }

    private void OnTriggerEnter2D(Collider2D col) //Si el jugador choca con la puerta activa la animacion de abrir la puerta
    {
       if (col.CompareTag("Player"))
        {
            UpdateSound();
            _animator.SetBool("EnPuerta", true);
            _source.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D col) //Si el jugador deja de tocar la puerta activa la animacion de cerrar la puerta
    {
        if (col.CompareTag("Player"))
        {
            UpdateSound();
            _animator.SetBool("EnPuerta", false);
        }
    }
    #endregion
}
