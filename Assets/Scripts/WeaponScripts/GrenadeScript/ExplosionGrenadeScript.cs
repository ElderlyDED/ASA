using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGrenadeScript : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosionEffect;
    [SerializeField] bool _collisionEnter = false;
    [SerializeField] float _destroyTime;
    void OnCollisionEnter(Collision collision)
    {
        if (_collisionEnter == false && collision.gameObject.GetComponent<PlayerInput>() == null)
        {
            _collisionEnter = true;
            GrenadeRotationScript _grs = gameObject.GetComponent<GrenadeRotationScript>();
            _grs.enabled = false;
            _explosionEffect.Play();
            gameObject.GetComponent<GrenadeOnDamageCollider>().OnDamageCollider();
            Rigidbody _rb = gameObject.GetComponent<Rigidbody>();
            _rb.isKinematic = true;
            _rb.useGravity = false;
            GetComponent<AudioSource>().Play();
            StartCoroutine(DestroyGrenade());
        }
        else
        {
            return;
        }
        
        IEnumerator DestroyGrenade()
        {
            yield return new WaitForSeconds(_destroyTime);
            Destroy(gameObject);
        }
    }
}
