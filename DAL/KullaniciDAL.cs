﻿using Entities;
using System;
using System.Linq;

namespace DAL
{
    public class KullaniciDAL
    {
        public bool KullaniciKontrolü(string email, string password)
        {
            using (var db = new FaturaYonetimiDbModel())
            {
                try
                {
                    if (db.Kullanici.Any(x => x.Email == email && x.Password == password))
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
    }
}
