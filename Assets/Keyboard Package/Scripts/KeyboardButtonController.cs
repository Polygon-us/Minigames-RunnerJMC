using UnityEngine;
using TMPro;

public class KeyboardButtonController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI containerText;

    private KeyboardController _controller;

    private void Awake()
    {
        _controller = GetComponentInParent<KeyboardController>();
    }
    
    public void AddLetter()
    {
        _controller.AddLetter(containerText.text);
    }

    public void DeleteLetter()
    {
        _controller.DeleteLetter();
    }

    public void SubmitWord()
    {
        _controller.SubmitWord();
    }
}