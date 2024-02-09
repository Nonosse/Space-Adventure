using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() is PlayerBehaviour player)
        {
            player.Damage(damage);
        }
        else if (collision.gameObject.GetComponent<ShipBehaviour>() is ShipBehaviour ship) 
        {
            ship.Damage(damage);
            Destroy(this.gameObject);
            GameManager.Instance.UpdateScore(ship.shipData.score);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
