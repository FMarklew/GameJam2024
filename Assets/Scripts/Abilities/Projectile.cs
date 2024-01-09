using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;

    protected int _damage;

	public LayerMask damageLayers;

	public LayerMask destroyLayers;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Init(int damage, Vector3 pos, Quaternion rot)
	{
        _damage = damage;
		transform.position = pos;
		transform.rotation = rot;
		rb.velocity = Vector3.zero;
	}

	public void FireProjectile(Vector2 targetVel)
	{
		if(rb == null)
		{
			rb = GetComponent<Rigidbody2D>();
		}
		gameObject.SetActive(true);
        rb.AddForce(targetVel);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(damageLayers == (damageLayers | (1 << collision.gameObject.layer))){
			CauseDamage(collision.gameObject);
		} else if(destroyLayers == (destroyLayers | (1 << collision.gameObject.layer)))
		{
			gameObject.SetActive(false);
		}
	}
	protected virtual void CauseDamage(GameObject go)
	{

	}
}
