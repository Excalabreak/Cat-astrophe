using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExistOrb : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotation;
    [SerializeField]
    private float speed;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.didIt);
            SceneManager.LoadScene(3);
        }
    }
}
