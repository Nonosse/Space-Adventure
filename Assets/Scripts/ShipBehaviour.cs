using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public ShipData shipData;
    public SpriteRenderer shipRenderer;

    private Vector3 _direction = Vector2.down;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        shipRenderer.sprite = shipData.defaultSprite;
    }

    private void OnValidate()
    {
        shipRenderer.sprite = shipData.defaultSprite;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this._direction * this.shipData.speed * Time.deltaTime;

        if (Time.time - _timer < shipData.timeBetweenFire)
        {
            EnnemyFire();
            _timer = Time.time;
        }
    }

    public void Damage(int amount)
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>() is PlayerBehaviour player)
        {
            player.Die();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    public void EnnemyFire()
    {
        new Vector3(this.transform.position.x, this.transform.position.y + shipData.startProjectile, this.transform.position.z);
    }
}
