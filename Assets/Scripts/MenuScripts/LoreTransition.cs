using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
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
    private int _actualTransition = 0; // imagen en la que se encuentra
    private bool skipeado = false;
    [SerializeField] GameObject _skipButtons;
    [SerializeField] GameObject _skipAllButton;

    void Start()
    {
        _skipButtons.SetActive(false);
        _transitions = _imageContainer.GetComponentsInChildren<Image>(true);
        Debug.Log(_transitions.Length);
        StartCoroutine(TypeDialog(_dialogs));
    }
    public IEnumerator TypeDialog(string[] dialogs)
    {
        for (int i = 0; i < _transitions.Length; i++)
        {
            _actualTransition = i;
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
            skipeado = false;
            int k = 0;
            foreach (var letter in dialogs[i].ToCharArray())
            {
                if (skipeado) // revisamos si ha skipeado
                {
                    break;
                }
                if (EventSystem.current.currentSelectedGameObject == null) // revisamos el problema del mando de ps4 que no halla deseleccionado el boton en pc
                {
                    EventSystem.current.SetSelectedGameObject(_skipAllButton);
                } 
                _dialogText.text += letter;
                k++;
                if (k == 2)
                {
                    k = 0;
                    _audioSource.Play();
                }
                yield return new WaitForSeconds(0.8f / _lettersPerSecond);
            }

            // Esperar un tiempo antes de continuar
            skipeado= false;
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

    public void Skipear()
    {
        if (!skipeado)
        {
            _dialogText.text = _dialogs[_actualTransition].ToString();
            skipeado = true;
        }
    }
    public void SkipAll()
    {
        _skipButtons.SetActive(true);
    }

    public void Confirm()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Cancel()
    {
        _skipButtons.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_skipAllButton);
    }
}
