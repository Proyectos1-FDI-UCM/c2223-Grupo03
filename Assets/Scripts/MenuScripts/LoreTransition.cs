using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoreTransition : MonoBehaviour
{
    [SerializeField] int _lettersPerSecond;
    [SerializeField] int _imageAnimTime;
    [SerializeField] TextMeshProUGUI _dialogText;
    private Image[] _transitions;
    [SerializeField] GameObject _imageContainer;
    [SerializeField] string[] _dialogs;
    [SerializeField] AudioSource _audioSource;


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
            Color imageColor = _transitions[i].color;
            // Mostrar animación de la imagen correspondiente
            _transitions[i].gameObject.SetActive(true);

            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / _imageAnimTime)
            {
                imageColor.a = Mathf.Lerp(0, 1, t);
                _transitions[i].color = imageColor;
                yield return null;
            }
            imageColor.a = 1;

            _dialogText.text = "";
            foreach (var letter in dialogs[i].ToCharArray())
            {
                _dialogText.text += letter;
                _audioSource.Play();
                yield return new WaitForSeconds(1.3f / _lettersPerSecond);
            }

            // Esperar un tiempo antes de continuar
            yield return new WaitForSeconds(2f);

            // Animación Ocultar la imagen

            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / _imageAnimTime) 
            {
                imageColor.a = Mathf.Lerp(1, 0, t);
                _transitions[i].color = imageColor;
                yield return null;
            }
            imageColor.a = 0;
            _transitions[i].color = imageColor;
            new WaitForSeconds(2f);
            _transitions[i].gameObject.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
