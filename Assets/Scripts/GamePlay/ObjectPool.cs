using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPool : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    public int poolSize = 10;
    private Queue<GameObject> objectQueue;

    private void Start()
    {
        objectQueue = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(floatingTextPrefab);
            obj.SetActive(false);
            objectQueue.Enqueue(obj);
        }
    }

    private GameObject GetPooledObject()
    {
        if (objectQueue.Count > 0)
        {
            GameObject obj = objectQueue.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return null;
    }

    public void ShowFloatingText(Vector3 position, Vector3 targetPosition)
    {
        GameObject floatingTextObj = GetPooledObject();
        if (floatingTextObj != null)
        {
            floatingTextObj.transform.position = position;
            StartCoroutine(MoveToTarget(floatingTextObj, targetPosition));
        }
    }

    private IEnumerator MoveToTarget(GameObject obj, Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float moveDuration = 2.0f; // Adjust as needed

        Vector3 startPosition = obj.transform.position;

        while (elapsedTime < moveDuration)
        {
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ReturnToPool(obj);
    }

    private void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectQueue.Enqueue(obj);
    }
}


  






