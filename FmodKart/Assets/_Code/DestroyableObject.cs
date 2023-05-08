using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionPrefab;
    public void DestroySelf()
    {
        ParticleSystem particles = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        particles.gameObject.transform.parent = null;
        particles.Stop();
        particles.Clear();
        particles.Play();

        Destroy(this.gameObject);
    }
}
