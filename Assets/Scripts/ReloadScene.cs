using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    //public Timer timer;
    private void OnTriggerEnter(Collider other)
    {
        /*
        If the tag of the object that collides with whatever object this script is on is "Player",
        the scene is reset, letting the player start over
        */
        if(other.CompareTag("Player"))
        {
            Debug.Log("Scene reloaded!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //timer.ResetTimer();
        }
    }
}
