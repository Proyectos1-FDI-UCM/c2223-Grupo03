using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoreTransition : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _dialogText;
    [SerializeField] int _lettersPerSecond;
    [SerializeField] string _text;
    void Start()
    {
        StartCoroutine(TypeDialog(_text));
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
