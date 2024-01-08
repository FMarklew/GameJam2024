using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_playerMask == (_playerMask | (1 << collision.gameObject.layer)))
        {
            GameManager.Instance.StartNextLevel();
        }
    }
}
