using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoreTransition : MonoBehaviour
{
    [SerializeField] int _lettersPerSecond;
    [SerializeField] TextMeshProUGUI _dialogText;
    GameObject[] _transitions;
    int _actualTransition = 0;
    
    void Start()
    {
        _transitions = gameObject.GetComponentsInChildren<GameObject>();
        
        StartCoroutine(TypeDialog("test"));
    }

    public IEnumerator TypeDialog(string dialog)
    {
        _dialogText.text = "";
        foreach(var letter in dialog.ToCharArray())
        {
            _dialogText.text += letter;
            yield return new WaitForSeconds(1f / _lettersPerSecond);
        }
    }
}
