using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : MonoBehaviour
{

    #region Variables
    private bool _puertaAbierta;
    #endregion
    #region Referencias
    [Header("Animacion")]
    private Animator animator;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(_puertaAbierta) { }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       if (col.tag == "player")
        {
            animator.SetTrigger("Tocar");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "player")
        {
            animator.SetTrigger("Tocar");
        }
    }
}
