using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleUI : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public bool isOn;

    private void Update()
    {
        HandleTheUI();
    }

    public void ToggleUIBool()
    {
        if (isOn)
            isOn = false;
        else if (!isOn)
            isOn = true;
    }
    public void HandleTheUI()
    {
        if (isOn)
        {
            canvas.SetActive(true);
        }
        if (!isOn)
        {

            canvas.SetActive(false);

        }
    }
}
