using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public GameObject objectToDelete; // Drag & drop l'objet à supprimer dans l'Inspector

    public void DeleteTarget()
    {
        Debug.Log("Delete target");
        if (objectToDelete != null)
        {
            Destroy(objectToDelete);
        }
    }
}
