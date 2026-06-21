using UnityEngine;

public class EnergyCore : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CollectibleManager.Instance.AddCore();

            Destroy(gameObject);
        }
    }
}