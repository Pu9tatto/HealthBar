using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private HealthBarView _healthBarView;

    private int _minHealth = 0;

    public void ChangeHealth(float value)
    {
        _health += value;

        if(_health> _maxHealth)
            _health = _maxHealth;
        else if( _health < _minHealth)
            _health = _minHealth;

        _healthBarView?.Render(_health / _maxHealth);
    }
}
