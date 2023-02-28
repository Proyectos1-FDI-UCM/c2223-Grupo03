using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    #region References
    [SerializeField] private GameObject _pildoraUI; // cuando miguel consiga juntarlo estas 3 irán al Ui manager, son parte de Hud
    [SerializeField] private GameObject _cajaUI;
    [SerializeField] private GameObject _despertadorUI;
    [SerializeField] private GameObject _llaveUI;
    #endregion

    #region Properties
    private bool _pildoraEquipado;
    private bool _cajaEquipado;
    private bool _despertadorEquipado;
    private bool _llaveEquipado;
    #endregion

    // Para poder acceder a los booleanos sin poder cambiar su valor, solo se puede cambiar su valor con los métodos de abajo por seguridad
    public bool _PildoraEquipado { get { return _pildoraEquipado; }}
    public bool _CajaEquipado { get { return _cajaEquipado; }}
    public bool _DespertadorEquipado { get { return _despertadorEquipado; }}
    public bool _LlaveEquipado { get { return _llaveEquipado; }}

    private void Start()
    {
        EliminaObjeto(1); // 1 -> píldoras
        EliminaObjeto(2); // 2 -> caja
        EliminaObjeto(3); // 3 -> despertador
        EliminaObjeto(4); // 4 -> llave
    }

    public void AñadeObjeto(int _item) // 1 -> píldoras, 2 -> caja, 3 -> despertador, 4 -> llave.
    {
        if (_item == 1)
        {
            _pildoraEquipado = true;
            _pildoraUI.gameObject.SetActive(true);
        }
        else if (_item == 2)
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
            _llaveEquipado = true;
            _llaveUI.gameObject.SetActive(true);
        }
    }

    public void EliminaObjeto(int _item) // 1 -> píldoras, 2 -> caja, 3 -> despertador, 4 -> llave.
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
            _llaveEquipado = false;
            _llaveUI.gameObject.SetActive(false);
        }
    }
}
