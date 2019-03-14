using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    public float radius = 3f; //how close the player has to be to interact

    public Transform interactionTransform;

    bool isFocus = false;   
    Transform player;       

    bool hasInteracted = false; 

    void Update()
    {
        if (isFocus)    // If currently being focused
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);

            

            if (!hasInteracted && distance <= radius) // If we haven't already interacted & the player is close enough
            {
                // Interact with the object
                hasInteracted = true;
                Interact();
            }
        }
    }

    // Called when the object starts being focused
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;
    }

    // Called when the object is no longer focused
    public void OnDefocused()
    {
        isFocus = false;
        hasInteracted = false;
        player = null;
    }

    // This method is meant to be overwritten
    public virtual void Interact()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
