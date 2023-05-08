using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _missilePrefab;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_missilePrefab, transform.position, transform.rotation);
        }
    }
}
