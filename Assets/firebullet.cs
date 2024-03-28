using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firebullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("�e�̑���")]
    private float speed = 50f;

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ���𔻒�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �e�𔭎˂���ꏊ���擾
            Vector3 bulletPosition = firingPoint.transform.position;
            // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������BBullet�̌�����Muzzle�̃��[�J���l�Ɠ����ɂ���i3�ڂ̈����j
            GameObject newBullet = Instantiate(bullet, bulletPosition, this.gameObject.transform.rotation);
            // �o���������e��up(Y������)���擾�iMuzzle�̃��[�J��Y�������̂��Ɓj
            Vector3 direction = newBullet.transform.forward;
            // �e�̔��˕�����newBall��Y����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
            newBullet.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
            // �o���������e�̖��O��"bullet"�ɕύX
            newBullet.name = bullet.name;
            // �o���������e��0.8�b��ɏ���
            Destroy(newBullet, 0.8f);
        }
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
   
}
