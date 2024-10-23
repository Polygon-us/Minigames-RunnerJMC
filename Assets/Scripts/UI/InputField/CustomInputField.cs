using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ColorInputField))]
public class CustomInputField : TMP_InputField
{
    private ColorInputField _colorInputField;
    
    public override void OnDeselect(BaseEventData eventData)
    {
#if !UNITY_EDITOR
        if (DeviceChecker.DeviceType != DeviceType.Mobile)
            base.OnDeselect(eventData);
#endif
    }

    protected override void Awake()
    {
        base.Awake();

        _colorInputField = GetComponent<ColorInputField>();

        colors = new ColorBlock
        {
            normalColor = Color.white,
            highlightedColor = Color.white * 0.9f,
            selectedColor = Color.white,
            pressedColor = Color.white * 0.7f,
            disabledColor = _colorInputField.disableInputColor,
            colorMultiplier = 1,
            fadeDuration = 0.1f
        };
    }

    public void DisableInput()
    {
        m_TextComponent.color = _colorInputField.disableTextColor;
        
        interactable = false;
    }

    public void HideCaret()
    {
        DeactivateInputField();

        SendOnFocusLost();
    }
}