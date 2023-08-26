using UnityEngine;
using UnityEngine.Serialization;

public class FloatingDamageNumber : MonoBehaviour
{
    [FormerlySerializedAs("floatingText")] public ObjectPool objectPool;
    public Transform targetPosition; // Set this in the inspector to the point where the text should float towards


    public void FloatingTextMove()
    {
        
            Vector3 textPosition = transform.position + Vector3.up;
            Vector3 targetPos = targetPosition.position;
            objectPool.ShowFloatingText(textPosition, targetPos);
        
    }
}