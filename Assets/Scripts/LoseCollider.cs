using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        //load the game over scene by using the name of the scene
        SceneManager.LoadScene("Game Over");
    }
}
