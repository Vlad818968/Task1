using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Crook>(out Crook crook))
        {
            _entered.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Crook>(out Crook crook))
        {
           _exit.Invoke();
        }
    }

}
