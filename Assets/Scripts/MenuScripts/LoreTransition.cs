using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoreTransition : MonoBehaviour
{
    [SerializeField] int _lettersPerSecond;
    [SerializeField] TextMeshProUGUI _dialogText;
    private Image[] _transitions;
    [SerializeField] GameObject _imageContainer;
    [SerializeField] string[] _dialogs;

    void Start()
    {
        _transitions = _imageContainer.GetComponentsInChildren<Image>(true);
        Debug.Log(_transitions.Length);

        StartCoroutine(TypeDialog(_dialogs));
    }

    public IEnumerator TypeDialog(string[] dialogs)
    {
        for (int i = 0; i < _transitions.Length; i++)
        {
            // Mostrar la imagen correspondiente
            _transitions[i].gameObject.SetActive(true);

            _dialogText.text = "";
            foreach (var letter in dialogs[i].ToCharArray())
            {
                _dialogText.text += letter;
                yield return new WaitForSeconds(1f / _lettersPerSecond);
            }

            // Esperar un tiempo antes de continuar
            yield return new WaitForSeconds(2f);

            // Ocultar la imagen
            _transitions[i].gameObject.SetActive(false);
        }
    }
}
