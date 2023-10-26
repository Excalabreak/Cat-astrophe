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

    private void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }
    }
}
