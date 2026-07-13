using UnityEngine;

public class EnergyCore : MonoBehaviour
{
    [Header("Sound Effect")]
    [Tooltip("Suara yang diputar saat Energy Core diambil")]
    public AudioClip collectSound;

    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CollectibleManager.Instance.AddCore();

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}