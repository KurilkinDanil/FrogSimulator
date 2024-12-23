using UnityEngine;

public class FrogEat : MonoBehaviour
{
    [SerializeField] FrogTongue _frogTongue;

    [SerializeField] private FrogStats _frogStats;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == _frogTongue.grabbledObject)
        {
            collision.gameObject.GetComponent<iWasEating>().Eat(_frogStats);
            Destroy(collision.gameObject);
            Debug.Log("„то-то съел");
        }
        else
        {
            Debug.Log("язык-то пуст");
        }
    }
}
