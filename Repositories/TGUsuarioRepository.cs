using System;
using System.Linq;
using System.Collections.Generic;
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

        public int Create(TGUsuario entity)
        {
            _ctx.TGUsuarios.Add(entity);
            _ctx.SaveChanges();
            return entity.TGUsuarioID;
        }

        public bool Delete(int id)
        {
            TGUsuario u = _ctx.TGUsuarios.Find(id);
            if (u == null)
            {
                return false;
            }
            _ctx.TGUsuarios.Remove(u);
            _ctx.SaveChanges();
            return true;
        }

        public IEnumerable<TGUsuario> GetAll(int ide)
        {
            List<TGUsuario> ls = _ctx.TGUsuarios.ToList();
            return ls;
        }

        public TGUsuario GetId(int id)
        {
            TGUsuario u = _ctx.TGUsuarios.Find(id);
            return u;
        }

        public int Update(TGUsuario entity)
        {
            _ctx.TGUsuarios.Update(entity);
            _ctx.SaveChanges();
            return entity.TGUsuarioID;
        }

        public TGUsuario Login(string usu, string pwd)
        {
            TGUsuario u = _ctx.TGUsuarios.FirstOrDefault(ui => ui.Usuario == usu && ui.Contrasena == pwd);
            if (u != null)
            {
                u.Contrasena = "";
            }
            return u;
        }
    }
}
