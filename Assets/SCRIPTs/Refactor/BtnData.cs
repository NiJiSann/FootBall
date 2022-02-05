using UnityEngine;
using UnityEngine.UI;

public class BtnData : MonoBehaviour
{
    [SerializeField] private int _btnIndex;
    [SerializeField] private Image _btnSprite;

    public int BtnIndex
    {
        get
        {
            return _btnIndex;
        }
        set
        {
            _btnIndex = value;
        }
    }

    public void SetSprite(Sprite sprite)
    {
        _btnSprite.sprite = sprite;
    }
}
