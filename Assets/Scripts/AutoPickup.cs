using UnityEngine;

public class AutoPickup : MonoBehaviour
{
    public GameObject weaponPrefab; 
    public string handSlotName = "HandSlot"; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform hand = other.transform.Find(handSlotName);

            if (hand != null && weaponPrefab != null)
            {
                Instantiate(weaponPrefab, hand.position, hand.rotation, hand);

                Destroy(gameObject);
            }
        }
    }
}
