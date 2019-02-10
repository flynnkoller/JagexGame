using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f; //how close the player has to be to interact

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
