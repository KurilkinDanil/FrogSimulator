using UnityEngine;

public class FrogTongue : MonoBehaviour
{
    FrogAttack _frogAttack;

    public GameObject grabbledObject;

    private void Start()
    {
        _frogAttack = GetComponentInParent<FrogAttack>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out ITouchedTongue touchedObject))
        {
            touchedObject.TouchHandler(this);

            grabbledObject = other.gameObject;

            //�������� ��������� ������� � ITouched ���� ��� �����. � ����� ���� ������� � �������. � ��� � ����� ������� ������������ ������� ��� ��������.
            _frogAttack.StopAttack();
        }
    }
}
