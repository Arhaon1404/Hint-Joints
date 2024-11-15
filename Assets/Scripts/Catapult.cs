using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private SpawnPoint _spawnAmmoPoint;
    [SerializeField] private Ammo _prefab;
    [SerializeField] private float _firePower;

    private Vector3 _spawnPoint;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _spawnPoint = _spawnAmmoPoint.transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _spawnPoint = _spawnAmmoPoint.transform.position;
            Instantiate(_prefab, _spawnPoint, transform.rotation);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rigidbody.WakeUp();
            _springJoint.spring = _firePower;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rigidbody.WakeUp();
            _springJoint.spring = 0;
        }
    }
}
