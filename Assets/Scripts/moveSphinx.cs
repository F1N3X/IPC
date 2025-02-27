using UnityEngine;
using System.Collections;

public class MoveSphinx : MonoBehaviour
{
    public GameObject targetObject; // L'objet à déplacer
    public float targetY = 5f; // Position Y cible (modifiable dans l'Inspector)
    public float moveDuration = 1f; // Durée du déplacement

    // Cette fonction peut être appelée pour déplacer l'objet vers targetY
    public void MoveObject()
    {
        if (targetObject != null)
        {
            StartCoroutine(MoveCoroutine(targetObject, targetY, moveDuration));
        }
    }

    // Coroutine pour déplacer l'objet vers la position Y cible
    IEnumerator MoveCoroutine(GameObject obj, float targetY, float duration)
    {
        Vector3 startPos = obj.transform.position;
        Vector3 endPos = new Vector3(startPos.x, targetY, startPos.z); // Change uniquement la position Y
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            obj.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Attends la prochaine frame
        }

        obj.transform.position = endPos; // Assure que l'objet arrive exactement à la position finale
    }
}
