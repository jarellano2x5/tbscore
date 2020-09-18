using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tbscore.Models;
using tbscore.Interfaces;
using tbscore.Data;

namespace tbscore.Repositories
{
    public class BTDatoRepository : IBTDato
    {
        private readonly BatiaCtx _ctx;
        public BTDatoRepository(BatiaCtx context)
        {
            _ctx = context;
        }

        public async Task<int> Create(BTDato entity)
        {
            _ctx.BTDatos.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity.BTDatoID;
        }

        public async Task<int> CreateBin(BTDatoBin entity)
        {
            _ctx.BTDatoBins.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity.BTDatoID;
        }

        public async Task<bool> Delete(int id)
        {
            await Task.Delay(TimeSpan.FromMinutes(6));
            return true;
        }

        public async Task<IEnumerable<BTDato>> GetAll(int ide)
        {
            List<BTDato> ls = await _ctx.BTDatos.ToListAsync();
            return ls;
        }

        public async Task<BTDato> GetId(int id)
        {
            BTDato d = await _ctx.BTDatos.FindAsync(id);
            return d;
        }

        public async Task<BTDatoBin> GetBinId(int id)
        {
            BTDatoBin d = await _ctx.BTDatoBins.FindAsync(id);
            return d;
        }

        public async Task<int> Update(BTDato entity)
        {
            _ctx.BTDatos.Update(entity);
            await _ctx.SaveChangesAsync();
            return entity.BTDatoID;
        }
    }
}
