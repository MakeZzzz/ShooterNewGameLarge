using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;


public class Weapon : MonoBehaviour
{
   public UnityEvent<float> ShootEvent;

   [field: SerializeField]
   public float BulletsCount { get; private set; }
   
   public AudioClip GunShotClip;
   public AudioSource source;
   public Vector2 audioPitch = new Vector2(.9f, 1.1f);
   
   public GameObject muzzlePrefab;
   public GameObject muzzlePosition;
   
   [SerializeField]private BulletsBehavior _bullet;
   [SerializeField] private float _bulletVelocity;

   private void Start()
   {
       if(source != null) source.clip = GunShotClip;
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         Shoot();
      }
   }

   private void Shoot()
   {
      if (BulletsCount <= 0)
      {
         return;
      }

      FireWeapon();
      var bullet = Instantiate(_bullet, transform.position, transform.rotation);
      bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletVelocity;
      BulletsCount -=1;
      ShootEvent.Invoke(BulletsCount);
   }
   
   [UsedImplicitly]
    public void FireWeapon()
        {
            // Вспышка из дула
            var flash = Instantiate(muzzlePrefab, muzzlePosition.transform);
            // Обработка аудио
            if (source != null)
            {
                /* Иногда источник не прикреплен к оружию для удобства создания экземпляров на скорострельном оружии, таком как пулеметы,
                 так что каждый выстрел получает свой собственный источник звука, но иногда можно использовать только 1 источник. Мы не хотим создавать экземпляр
                 родительского gameobject, иначе программа застрянет в цикле, поэтому мы проверяем, является ли источник дочерним объектом */
                if(source.transform.IsChildOf(transform))
                {
                    source.Play();
                }
                else
                {
                    // Создать экземпляр сборного файла для аудио, удалить через несколько секунд.
                    AudioSource newAS = Instantiate(source);
                    if ((newAS = Instantiate(source)) != null && newAS.outputAudioMixerGroup != null && newAS.outputAudioMixerGroup.audioMixer != null)
                    {
                        // Изменение высоты звука, чтобы придать вариативность повторяющимся кадрам
                        newAS.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", Random.Range(audioPitch.x, audioPitch.y));
                        newAS.pitch = Random.Range(audioPitch.x, audioPitch.y);

                        // Воспроизвидение звука выстрела
                        newAS.PlayOneShot(GunShotClip);
                        
                        Destroy(newAS.gameObject, 1);
                    }
                }
            }

        }
   
}
