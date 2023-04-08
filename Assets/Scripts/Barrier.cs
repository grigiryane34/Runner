using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject _bricksEffectPrefab;
    [SerializeField] private Transform spawnFxPoint;

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        if (playerModifier) {
            playerModifier.HitBarrier();
            Destroy(gameObject);
            Instantiate(_bricksEffectPrefab, spawnFxPoint.position, transform.rotation);
        }
    }

}
