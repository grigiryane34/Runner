using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ChangeType { 
    Width,
    Height
}

public class GateAppearaence : MonoBehaviour
{

    [SerializeField] private Renderer _renderer;
    [SerializeField] TextMeshPro _text;

    [SerializeField] Color _colorPositive;
    [SerializeField] Color _colorNegative;



    public void UpdateVisual(int value)
    {
        string prefix = "";

        if (value > 0)
        {
            prefix = "+";
            SetColor(_colorPositive);
        } else if (value == 0) {
            SetColor(Color.grey);
        } else
        {
            SetColor(_colorNegative);
        }

        _text.text = prefix + value.ToString();
    }

    private void SetColor(Color color) {
        _renderer.sharedMaterial.SetColor("_BaseColor", color);

    }

}
