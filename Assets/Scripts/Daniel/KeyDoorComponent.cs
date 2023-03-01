using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorComponent : MonoBehaviour
{
    #region Referencias
    private Animator _animator;
    #endregion

    #region Referencias
    private bool _puertaAbierta = false;
    #endregion

    #region Metodos
    // Start is called before the first frame update
    #endregion

    Inventory _inventory;
    void Start()
    {
        _inventory = GameManager.Instance.GetComponent<Inventory>();
        _animator = GetComponent<Animator>();    
    }
  
    private void OnTriggerEnter2D(Collider2D col) //Si el jugador choca con la puerta activa y tiene la llave -> la animacion de abrir la puerta
    {
        if (!_puertaAbierta)
        {
            Debug.Log("La puerta no está abierta");
            if (col.CompareTag("Player") && _inventory._LlaveEquipado)
            {
                Debug.Log("Pero tiene la llave");
                _puertaAbierta = true;
                _inventory.EliminaObjeto(4);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                //reproducir sonido de candado abriendose
            }
        }
        else
        {
            Debug.Log("La puerta está abierta");
            if (col.CompareTag("Player"))
            {
                _animator.SetTrigger("Tocar");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col) //Si el jugador deja de tocar la puerta activa la animacion de cerrar la puerta
    {
        if (col.CompareTag("Player") && _puertaAbierta)
        {
            _animator.SetTrigger("Tocar");
        }
    }
}
