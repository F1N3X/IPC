using UnityEngine;
using System.Collections;

public class EnableAndMoveObject : MonoBehaviour
{
    public GameObject object1; // Objet à déplacer au lieu d'être activé
    public GameObject object2; // Objet qui doit monter en Y
    public float targetYObject1 = 1.930098f; // Nouvelle position Y pour object1
    public float targetYObject2 = 13.5f; // Position Y cible pour object2
    public float moveDuration = 1f; // Durée du déplacement

    private void OnTriggerEnter(Collider other)
    {
        if (object1 != null)
        {
            StartCoroutine(MoveObject(object1, targetYObject1, moveDuration));
        }

        if (object2 != null)
        {
            StartCoroutine(MoveObject(object2, targetYObject2, moveDuration));
        }
    }

    IEnumerator MoveObject(GameObject obj, float targetY, float duration)
    {
        Vector3 startPos = obj.transform.position;
        Vector3 endPos = new Vector3(startPos.x, targetY, startPos.z);
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            obj.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = endPos; // Assure qu'il atteint la position finale
    }
}
