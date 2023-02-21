using UnityEngine;

public class BoxComponent : MonoBehaviour
{
    // Set this to the box object prefab
    [SerializeField] private GameObject boxPrefab;
    #region References
    private GameObject _player;
    private GameObject _box;
    private bool isBox;
    #endregion

    private void Start()
    {
       _player = gameObject;
        isBox = false;
    }

    private void Update()
    {
        // If the player presses the "K" key, toggle between the player object and the box object
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (isBox)
            {
                // Destroy the box object and enable the player object
                Destroy(_box);
                _player.SetActive(true);
                isBox = false;
            }
            else 
            {
                // Disable the player object and create the box object
                _player.SetActive(false);
                _box = Instantiate(boxPrefab, _player.transform.position, Quaternion.identity);
                isBox = true;
            }
        }
    }
}