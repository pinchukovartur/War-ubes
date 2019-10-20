using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : Singleton<LifeCounter>
{
    [SerializeField, Tooltip("Count player life"), Range(1, 1000)]
    private int _lifeCount = 100;

    [SerializeField, Tooltip("Ui count text")]
    private Text _countText;

    private void Awake()
    {
        _countText.text = _lifeCount.ToString();
    }

    public void RemoveLife()
    {
        _lifeCount--;
        _countText.text = _lifeCount.ToString();
    }
}
