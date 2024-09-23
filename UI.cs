using UnityEngine;
using System.Collections.Generic;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UI : MonoBehaviour
{
    [SerializeField] private Base _base;
    
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _base.ResourceAdded += UpdateText;

        _text = GetComponent<TextMeshProUGUI>();
        UpdateText((List<Resource>)_base.Resources);
    }

    public void UpdateText(List<Resource> resources)
    {
        int coalAmount = 0, ironAmount = 0, goldAmount = 0;

        foreach (Resource resource in resources)
        {
            if (resource is Coal)
                ++coalAmount;
            else if (resource is Gold)
                ++goldAmount;
            else if (resource is Iron)
                ++ironAmount;
        }

        _text.text = $"Coal - {coalAmount}\nGold - {goldAmount}\nIron - {ironAmount}";
    }
}