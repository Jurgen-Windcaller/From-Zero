using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactRadius = 0.5f;

    private Transform player;

    private bool interactThisFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerDist(player);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }

    private void CheckPlayerDist(Transform playerTrans)
    {
        float distance = Vector2.Distance(transform.position, playerTrans.position);

        if (distance <= interactRadius)
        {
            if (!interactThisFrame)
            {
                OnInteract();
                interactThisFrame = true;
            }
        }
        else
        {
            interactThisFrame = false;
        }
    }

    public virtual void OnInteract()
    {
        // Overwritable function
        // Debug.Log("Interacting from Interactable Script.");
    }
}
