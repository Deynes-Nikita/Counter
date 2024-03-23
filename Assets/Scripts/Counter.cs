using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delayInSeconds = 0.5f;
    [SerializeField] private float _stepIncreaseValue = 1.0f;

    private float _currentNumber = 0.0f;
    private WaitForSecondsRealtime _waitForSecondsRealtime;
    private Coroutine _increaseValueCoroutine;

    private void Start()
    {
        _waitForSecondsRealtime = new WaitForSecondsRealtime(_delayInSeconds);
    }

    private void OnMouseDown()
    {
        if (_increaseValueCoroutine == null)
        {
            _increaseValueCoroutine = StartCoroutine(IncreaseValue());
        }
        else
        {
            StopCoroutine(_increaseValueCoroutine);
            _increaseValueCoroutine = null;
        }
    }

    private IEnumerator IncreaseValue()
    {
        bool isIncreaseValueOn = true;

        while (isIncreaseValueOn)
        {
            _currentNumber += _stepIncreaseValue;
            _text.text = _currentNumber.ToString();

            yield return _waitForSecondsRealtime;
        }
    }
}
