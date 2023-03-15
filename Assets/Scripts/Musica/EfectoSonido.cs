using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    [SerializeField] private AudioClip _ambiente;
    [SerializeField] private AudioClip _lluvia;
    // Start is called before the first frame update
    void Start()
    {
        SoundController.Instance.PlayMusic(_ambiente);
        SoundController.Instance.PlayMusic(_lluvia);    
    }

    // Update is called once per frame
    void Update()
    {
        SoundController.Instance.PlayMusic(_ambiente);
        SoundController.Instance.PlayMusic(_lluvia);
    }
}
