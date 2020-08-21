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
    public class TGUsuarioRepository : ITGUsuario
    {
        private readonly BatiaCtx _ctx;
        public TGUsuarioRepository(BatiaCtx context)
        {
            _ctx = context;
        }

        public async Task<int> Create(TGUsuario entity)
        {
            _ctx.TGUsuarios.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity.TGUsuarioID;
        }

        public async Task<bool> Delete(int id)
        {
            TGUsuario u = await _ctx.TGUsuarios.FindAsync(id);
            if (u == null)
            {
                return false;
            }
            _ctx.TGUsuarios.Remove(u);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TGUsuario>> GetAll(int ide)
        {
            List<TGUsuario> ls = await _ctx.TGUsuarios.ToListAsync();
            return ls;
        }

        public async Task<TGUsuario> GetId(int id)
        {
            TGUsuario u = await _ctx.TGUsuarios.FindAsync(id);
            return u;
        }

        public async Task<int> Update(TGUsuario entity)
        {
            _ctx.TGUsuarios.Update(entity);
            await _ctx.SaveChangesAsync();
            return entity.TGUsuarioID;
        }

        public async Task<TGUsuario> Login(string usu, string pwd)
        {
            TGUsuario u = await _ctx.TGUsuarios.FirstOrDefaultAsync(ui => ui.Usuario == usu && ui.Contrasena == pwd);
            if (u != null)
            {
                u.Contrasena = "";
            }
            return u;
        }
    }
}
