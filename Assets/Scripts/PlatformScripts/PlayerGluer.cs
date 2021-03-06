﻿using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerGluer : MonoBehaviour
{
    string _playerTag = "Player";
    GameObject _player;

    // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(_playerTag))
        {
            _player = collision.gameObject;
            _player.transform.SetParent(this.transform);
        }
    }

    // OnCollisionExit2D is called when this collider2D/rigidbody2D has stopped touching another rigidbody2D/collider2D (2D physics only)
    private void OnCollisionExit2D(Collision2D collision)
    {
        ReleasePlayerIfAny();
    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        ReleasePlayerIfAny();
    }

    void ReleasePlayerIfAny()
    {
        if (_player != null)
        {
            _player.transform.SetParent(null);
            _player = null;
        }
    }
}