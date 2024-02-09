using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public ShipData shipData;

    private Rigidbody2D _rb;
    private float _currentHP;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = shipData.defaultSprite;
        _rb = GetComponent<Rigidbody2D>();
        _currentHP = shipData.maxHP;
    }

    private void OnValidate()
    {
        spriteRenderer.sprite = shipData.defaultSprite;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _rb.velocity = (_mousePosition - this.transform.position).normalized * shipData.speed;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 _launchBullet = new Vector3(this.transform.position.x, this.transform.position.y + shipData.startProjectile, this.transform.position.z);
        Instantiate(this.shipData.bulletPrefab, _launchBullet, Quaternion.identity);
    }

    public void Damage(int amount)
    {
        _currentHP -= amount;

        if (_currentHP <= 0)
        {
            GameManager.Instance.Lose();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    public float GetHPRatio()
    {
        return _currentHP / (float)shipData.maxHP;
    }
}
