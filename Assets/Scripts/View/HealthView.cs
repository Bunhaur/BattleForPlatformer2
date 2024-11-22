using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private SmoothIndicator _smoothIndicator;

    private void Start()
    {
        Init();
    }

    private void OnEnable()
    {
        _health.Changed += _smoothIndicator.Show;
        _health.Dead += Destroy;
    }

    private void OnDisable()
    {
        _health.Changed -= _smoothIndicator.Show;
        _health.Dead -= Destroy;
    }

    private void Init()
    {
        _smoothIndicator.Show(_health.CurrentValue);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}