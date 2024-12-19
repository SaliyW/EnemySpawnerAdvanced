using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            transform.localScale += collision.gameObject.GetComponent<Enemy>().TargetEnlarger;
        }
    }
}
