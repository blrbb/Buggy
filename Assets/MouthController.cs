using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    [SerializeField] int numberOfBites = 3;
    [SerializeField] float chewSpeed = .3f;
    [SerializeField] int deaths = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I got balls in my mouth");
        StartCoroutine(openAndCloseMouth());
        StartCoroutine(Respawn(other));

        void closeMouth()
        {
            Debug.Log("Nom");
            gameObject.transform.localScale = new Vector3(1, .05f, 1);
        }

        void openMouth()
        {
            Debug.Log("Om");
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        IEnumerator openAndCloseMouth()
        {
            Debug.Log("OMNOMNOMNOM....");
            for (int i = 0; i < numberOfBites; i++)
            {
                closeMouth();
                yield return new WaitForSeconds(chewSpeed);
                openMouth();
                yield return new WaitForSeconds(chewSpeed);
            }

        }

        IEnumerator Respawn(Collider2D other)
        {
            deaths++;

            var randomSpot = new Vector3(Random.Range(-7f, 7f), Random.Range(-5f, 5f), 1);
            var newFly = Instantiate(other.gameObject, randomSpot, new Quaternion());
            var spriteRenderer = newFly.gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (var item in spriteRenderer)
            {
                item.enabled = false;
            }
            Destroy(other.gameObject);
            yield return new WaitForSeconds(1);
            foreach (var item in spriteRenderer)
            {
                item.enabled = true;
            }

        }
    }
}
