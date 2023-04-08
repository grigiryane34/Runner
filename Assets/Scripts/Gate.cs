using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    [SerializeField] int _value;
    [SerializeField] ChangeType _deformationType;
    [SerializeField] GateAppearaence _gateAppearaence;

    private void OnValidate()
    {
        _gateAppearaence.UpdateVisual(_value);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        if (playerModifier)
        {
            if (_deformationType == ChangeType.Width)
            {
                playerModifier.AddWidth(_value);
            }
            else if (_deformationType == ChangeType.Height)
            {
                playerModifier.AddHeight(_value);
            }
            Destroy(gameObject);
        }

    }

}
