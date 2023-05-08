using UnityEngine;

public class Missile : MonoBehaviour
{

    [Header("Dependencies")]
    [SerializeField] private ParticleSystem _explosionPrefab;

    [Header("Settings")]
    [SerializeField] private float _acceleration = 10f;
    [SerializeField] private float _maxSpeed = 50f;
    [SerializeField] private float _damageRadius = 5f;

    private Vector3 _velocity;

    private void OnEnable()
    {
        this.gameObject.transform.parent = null;
    }

    private void Update()
    {
        MoveMissile();
    }

    private void MoveMissile()
    {
        if (_velocity.magnitude < _maxSpeed)
        {
            _velocity += transform.up * _acceleration * Time.deltaTime;
            _velocity = Vector3.ClampMagnitude(_velocity, _maxSpeed);
        }
        transform.position += _velocity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        DestoryObjects();
        Explode();     
    }

    private void DestoryObjects()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, _damageRadius, Vector3.forward);

        foreach (RaycastHit hit in hits)
        {
            DestroyableObject destroyableObject = hit.collider.GetComponent<DestroyableObject>();

            if (destroyableObject != null)
            {
                destroyableObject.DestroySelf();
            }
        }
    }

    private void SpawnExplosion()
    {
        ParticleSystem particles = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        particles.gameObject.transform.parent = null;
        particles.Stop();
        particles.Clear();
        particles.Play();
    }
    private void Explode()
    {
        SpawnExplosion();
        Destroy(gameObject);
    }

}
