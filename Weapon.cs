using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap_Task
{
    public class Weapon
    {
        private int _bulletCapacity;
        private int _bulletCount;
        public int BulletCapacity { get => _bulletCapacity; set {



                if (value <= 0)
                {
                    throw new NotAvailableException("Capacity don't be less than 0");
                }
                else
                {
                    _bulletCapacity = value;
                }


            } }
        public int BulletCount { get => _bulletCount; set {

                if (value < 0)
                {
                    throw new NotAvailableException("Count don't be less than 0");
                }
                else
                {
                    _bulletCount = value;
                }


            } }

        public FireMode FireMode { get; set; }

        public Weapon(int bulletCapacity, int bulletCount, FireMode fireMode)
        {
            if (bulletCapacity < bulletCount)
            {
                throw new NotAvailableException("BulletCount must be less or equal BulletCapacity");
            }

            BulletCapacity = bulletCapacity;
            BulletCount = bulletCount;
            FireMode = fireMode;
        }

        public void Shoot()
        {

            if (BulletCount > 0) {
                BulletCount--;
            }
            else
            {
                throw new NotAvailableException("No bullets left to shoot.");
            }


        }

        public override string ToString()
        {
            return $"{BulletCapacity} - {BulletCount} - {FireMode}";
        }

        public void Fire() {


            if (FireMode == FireMode.Burst)
            {
                if (BulletCount >= 3)
                {
                    BulletCount -= 3;
                }
                else {
                    throw new NotAvailableException("Not enough bullets for Burst mode.");

                }
            }
            else if (FireMode == FireMode.Auto)
            {
                BulletCount = 0;
            }

            else if (FireMode == FireMode.Single)
            {
                Shoot();
            }
        }
        public int GetRemainBulletCount()
        {
            return BulletCapacity - BulletCount;

        }
        public void Reload()
        {

            BulletCount = BulletCapacity;

        }
        public void ChangeFireMode(FireMode fireMode)
        {
                FireMode = fireMode;
          
        }


       
        }
    }
