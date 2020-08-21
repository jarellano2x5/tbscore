using System;
using System.Threading.Tasks;
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

        public async Task<int> Create(BTDato bt)
        {
            return await _bat.Create(bt);
        }

        public async Task<int> CreateBin(BTDatoBin bt)
        {
            return await _bat.CreateBin(bt);
        }

        public async Task<IEnumerable<BTDato>> GetAll()
        {
            return await _bat.GetAll(0);
        }

        public async Task<BTDato> Get(int id)
        {
            return await _bat.GetId(id);
        }

        public async Task<bool> Delete(int id)
        {
            return await _bat.Delete(id);
        }

    }
}
