using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _durationChange;
    [SerializeField] private Player _player;

    float _runningTime = 0;
    float _normalizedValue;
    private IEnumerator _currentCoroutine;

    private void OnEnable()
    {
        _player.EventHealthChanging += OnHealthChange;
    }

    private void OnDisable()
    {
        _player.EventHealthChanging -= OnHealthChange;
    }

    private void OnHealthChange(float newValue)
    {
        StartNewCoroutine(ChangeValue(newValue));
    }

    private IEnumerator ChangeValue(float newValue)
    {
        while (_healthBar.value != newValue)
        {
            _runningTime += Time.deltaTime;
            _normalizedValue = _runningTime / _durationChange;

            _healthBar.value = Mathf.MoveTowards(_healthBar.value, newValue, _normalizedValue);

            yield return null;
        }
    }

    private void StartNewCoroutine(IEnumerator coroutine)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _runningTime = 0;
        _currentCoroutine = coroutine;
        StartCoroutine(coroutine);
    }
}
