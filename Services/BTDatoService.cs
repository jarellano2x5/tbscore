using System;
using System.Collections.Generic;
using tbscore.Interfaces;
using tbscore.Models;

namespace tbscore.Services
{
    public class BTDatoService
    {
        private readonly IBTDato _bat;
        public BTDatoService(IBTDato dato)
        {
            _bat = dato;
        }

        public int Create(BTDato bt)
        {
            return _bat.Create(bt);
        }

        public IEnumerable<BTDato> GetAll()
        {
            return _bat.GetAll(0);
        }

        public BTDato Get(int id)
        {
            return _bat.GetId(id);
        }

    }
}
