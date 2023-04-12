using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ClosetComponent : MonoBehaviour
{

    #region Paramet    
    [SerializeField] private float _interactDistance;
    private bool _isHiding = false;
    public bool IsHiding
    {
        get
        {
            return _isHiding;
        }
    }
    private Vector2 _playerPos;
    private Vector2 _closetPos;
    private GameObject _player;
    [SerializeField] private Sprite _closetSprite;
    [SerializeField] private Sprite _closetShine;
    private float _timeCont;

    private AudioSource _closetAudio;
    private float _audioVolume;

    [SerializeField] private float _Xoffset;
    [SerializeField] private float _Yoffset;
    #endregion

    #region Methods

    //Comptueba si el jugador esta dentro del rango para entrar en el armario
    private bool CanHide()
    {
        _playerPos = _player.transform.position;
        _closetPos = transform.position;
        if (Vector2.Distance(_playerPos, _closetPos) <= _interactDistance)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _closetShine;
            return true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _closetSprite;
            return false;
        }

    }

    //Esconde al jugador
    private void HidePlayer()
    {
        _player.SetActive(false);
        _player.transform.position = (Vector2)transform.position + new Vector2(_Xoffset, _Yoffset);
        GameManager.PlayerStates.EnterCloset();
        _isHiding = true;
        _closetAudio.Play();
        Camera.main.GetComponent<CameraFollow>().ChangeCameraPosition(transform, 0.2f);
    }

    //Muestra al jugador
    public void ShowPlayer()
    {
        _player.SetActive(true);
        GameManager.PlayerStates.ExitCloset();
        _isHiding = false;
        _closetAudio.Play();
        Camera.main.GetComponent<CameraFollow>().RestartPlayerFocus();
        Invoke("RestoreSmooth", 0.2f);
    }
    private void RestoreSmooth()
    {
        Camera.main.GetComponent<CameraFollow>().RestoreSmoothness();
    }

    private void UpdateSound()
    {
        _closetAudio.volume = _audioVolume * GameManager.Instance.getSFX;
    }

    private void Start()
    {
        _player = GameManager.Player;
        _closetAudio = GetComponent<AudioSource>();
        _audioVolume = _closetAudio.volume;
    }
    // Update is called once per frame
    void Update()
    {
        if (CanHide() && (Input.GetKeyDown(KeyCode.E) || Input.GetButton("AspaPs4")) && !GameManager.PlayerStates.IsBox && !GameManager.PlayerStates.Tired && _timeCont >= 0.2)
        {
            _timeCont = 0;
            UpdateSound();
            if (!_isHiding)
            {
                HidePlayer();
            }
            else
            {
                ShowPlayer();
            }
        }
    }
    #endregion
}
