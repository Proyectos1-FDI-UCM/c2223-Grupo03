
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    #region References
    [SerializeField] private GameObject _pildoraUI; // cuando miguel consiga juntarlo estas 3 ir�n al Ui manager, son parte de Hud
    [SerializeField] private GameObject _cajaUI;
    [SerializeField] private GameObject _despertadorUI;
    [SerializeField] private GameObject _llaveUI;
    #endregion

    #region Properties
    public bool _pildoraEquipado;
    public bool _cajaEquipado;
    public bool _despertadorEquipado;
    public bool _llaveEquipado;
    #endregion

    // Para poder acceder a los booleanos sin poder cambiar su valor, solo se puede cambiar su valor con los m�todos de abajo por seguridad
    public bool _PildoraEquipado { get { return _pildoraEquipado; }}
    public bool _CajaEquipado { get { return _cajaEquipado; }}
    public bool _DespertadorEquipado { get { return _despertadorEquipado; }}
    public bool _LlaveEquipado { get { return _llaveEquipado; }}

   
    private void Start()
    {
        EliminaObjeto(1); // 1 -> p�ldoras
        EliminaObjeto(2); // 2 -> caja
        EliminaObjeto(3); // 3 -> despertador
       // EliminaObjeto(4); // 4 -> llave
    }

    public void A�adeObjeto(int _item) // 1 -> p�ldoras, 2 -> caja, 3 -> despertador, 4 -> llave.
    {
        if (_item == 1)
        {
            _pildoraEquipado = true;
            _pildoraUI.gameObject.SetActive(true);
        }
        else if (_item == 2 || _item == 5)
        {
            _cajaEquipado = true;
            _cajaUI.gameObject.SetActive(true);
        }
        else if (_item == 3)
        {
            _despertadorEquipado = true;
            _despertadorUI.gameObject.SetActive(true);
        }
        else if (_item == 4)
        {
            Debug.Log("llave");
            _llaveEquipado = true;
            Debug.Log("" + _llaveEquipado);
            _llaveUI.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            Debug.Log("llave color");
        }
    }

    public void EliminaObjeto(int _item) // 1 -> p�ldoras, 2 -> caja, 3 -> despertador, 4 -> llave.
    {
        if (_item == 1)
        {
            _pildoraEquipado = false;
            _pildoraUI.gameObject.SetActive(false);
        }
        else if (_item == 2)
        {
            _cajaEquipado = false;
            _cajaUI.gameObject.SetActive(false);
        }
        else if (_item == 3)
        {
            _despertadorEquipado = false;
            _despertadorUI.gameObject.SetActive(false);
        }
        else if (_item == 4)
        {
            Debug.Log("wtf");
            _llaveEquipado = false;
            _llaveUI.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.25f);
        }
    }
}
