using UnityEngine;
using System.Collections;

public class IAManager : MonoBehaviour
{

    public GameObject[] iasGameObject;
    private float timeToInstance = 5;
    private float limitLeft;
    private float limitRight;
    float z = 0;

    void Start()
    {
        StartCoroutine(InstanceIA());
    }

    void Update()
    {
        this.limitLeft = GameObject.FindGameObjectWithTag("LeftLimit").transform.position.x;
        this.limitRight = GameObject.FindGameObjectWithTag("RightLimit").transform.position.x;
    }

    IEnumerator InstanceIA()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.timeToInstance);
            if (Random.Range(0f, 3f) > 1.5f && this.limitLeft > -6.7f)
            {
                Instantiate(iasGameObject[Random.Range(0, this.iasGameObject.Length)],
                        new Vector3(Random.Range(-7f, this.limitLeft), -1.55f, z), Quaternion.identity);
            }

            else
            {
                if(this.limitRight < 20)
                Instantiate(iasGameObject[Random.Range(0, this.iasGameObject.Length)],
                            new Vector3(Random.Range(this.limitRight, 19.75f), -1.55f, z), Quaternion.identity);
            }
            z += 1;
            this.timeToInstance -= 0.05f;

        }
    }
}
