using UnityEngine;
using System;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class CollisionHandler : MonoBehaviour
{

    [FormerlySerializedAs("ObjectPool")] public FloatingDamageNumber floatingDamageNumber;
    private DateTime lastCollisionTime;
    private TimeSpan cooldownDuration = TimeSpan.FromSeconds(2);

    private void Update()
    {
        
    }

    public void HandleCollision()
    {
        DateTime currentTime = DateTime.Now;

        if (currentTime - lastCollisionTime >= cooldownDuration)
        {
            Debug.Log("Collision detected!");
            floatingDamageNumber.FloatingTextMove();

            lastCollisionTime = currentTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ABDSD");
        HandleCollision();
    }
}
