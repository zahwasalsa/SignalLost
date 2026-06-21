using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(CollectibleManager.Instance.IsAllCollected())
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}