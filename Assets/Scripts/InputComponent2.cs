using UnityEngine;

public class InputComponent2 : MonoBehaviour
{
    #region References
    //[SerializeField]
    private GameObject _closet;
    #endregion
    #region Parameters
    [SerializeField] private GameObject _boxPrefab;
    private GameObject _player;
    private GameObject _box;
    private bool _isBox;
    #endregion

    #region Methods
    private void Start()
    {
        _player = GameManager.Player;
        _isBox = false;
        _closet = GameObject.Find("Closet");
    }

    private void Update()
    {
        // If the player presses the "K" key, change between the player and the box 
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (_isBox)
            {
                // Destroy the box and enable the player 
                Destroy(_box);
                _closet.GetComponent<ClosetComponent>().enabled = true;
                _player.SetActive(true);
                _isBox = false;
            }
            else
            {
                // Disable the player and instantiate the box 
                _player.SetActive(false);
                _box = Instantiate(_boxPrefab, _player.transform.position, Quaternion.identity);
                _closet.GetComponent<ClosetComponent>().enabled = false;
                _isBox = true;
            }
        }
    }
    #endregion
}