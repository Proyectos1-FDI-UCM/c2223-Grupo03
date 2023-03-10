using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : MonoBehaviour
{
    #region Referencias
    [Header("Animacion")]
    private Animator _animator;
    #endregion

    #region Metodos
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();    
    }
  
    private void OnTriggerEnter2D(Collider2D col) //Si el jugador choca con la puerta activa la animacion de abrir la puerta
    {
       if (col.CompareTag("Player"))
        {
            _animator.SetBool("EnPuerta", true);
        }
    }

    private void OnTriggerExit2D(Collider2D col) //Si el jugador deja de tocar la puerta activa la animacion de cerrar la puerta
    {
        if (col.CompareTag("Player"))
        {
            _animator.SetBool("EnPuerta", false);
        }
    }
    #endregion
}
