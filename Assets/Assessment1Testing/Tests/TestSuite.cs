using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{

    private GameObject game;
    
    [UnityTest]
    public IEnumerator AsteroidsMoves()
    {
        game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        
        Asteroid asteroid = game.GetComponentInChildren<Asteroid>();
        Vector3 initialPos = asteroid.transform.position;
        yield return new WaitForSeconds(0.1f);
        Assert.Greater((asteroid.transform.position - initialPos).magnitude, 0);
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator BulletCreated()
    {
        game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));

        Player player = game.GetComponentInChildren<Player>();
        player.FireBullet();
        yield return new WaitForSeconds(0.1f);

        int bulletCount = GameObject.FindObjectsOfType<Bullet>().Length;
        Assert.Greater(bulletCount, 0);
    }

    [UnityTest]
    public IEnumerator AsteroidDies()
    {
        game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));

        Asteroid asteroid = game.GetComponentInChildren<Asteroid>();
        asteroid.Die();
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(asteroid == null);
    }
    
    [UnityTest]
    public IEnumerator BulletDies()
    {
        game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));

        Player player = game.GetComponentInChildren<Player>();
        Bullet bullet = player.FireBullet();
        bullet.Die();
        yield return new WaitForSeconds(0.1f);
        
        int bulletCount = GameObject.FindObjectsOfType<Bullet>().Length;
        Assert.LessOrEqual(bulletCount, 0);
    }
    
    [UnityTest]
    public IEnumerator AsteroidSplit()
    {
        game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        int asteroidCount = GameObject.FindObjectsOfType<Asteroid>().Length;
        Asteroid asteroid = game.GetComponentInChildren<Asteroid>();
        asteroid.Die();
        yield return new WaitForSeconds(0.1f);
        int newAsteroidCount = GameObject.FindObjectsOfType<Asteroid>().Length;
        Assert.GreaterOrEqual(newAsteroidCount,asteroidCount);
    }

}
