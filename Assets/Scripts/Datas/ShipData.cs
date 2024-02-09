using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Ship")]
public class ShipData : ScriptableObject
{
    public Sprite defaultSprite;
    public float speed;
    public float maxHP;
    public BulletPrefab bulletPrefab;
    public float startProjectile;
    public int score;
    public float timeBetweenFire;
}
