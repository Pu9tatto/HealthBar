using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private int _maxHealth = 100;

    public event UnityAction<float> EventHealthChanging;

    private int _minHealth = 0;
    private float PercentHealth => (float)_health / _maxHealth;

    public void TakeDamage(int value)
    {
        _health -= value;

        if( _health < _minHealth)
            _health = _minHealth;

        EventHealthChanging(PercentHealth);
    }

    public void Heal(int value)
    {
        _health += value;

        if (_health > _maxHealth)
            _health = _maxHealth;

        EventHealthChanging(PercentHealth);
    }

}
