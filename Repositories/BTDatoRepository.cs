using System;
using System.Linq;
using System.Collections.Generic;
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

        public int Create(BTDato entity)
        {
            _ctx.BTDatos.Add(entity);
            _ctx.SaveChanges();
            return entity.BTDatoID;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BTDato> GetAll(int ide)
        {
            List<BTDato> ls = _ctx.BTDatos.ToList();
            return ls;
        }

        public BTDato GetId(int id)
        {
            BTDato d = _ctx.BTDatos.Find(id);
            return d;
        }

        public int Update(BTDato entity)
        {
            throw new NotImplementedException();
        }
    }
}
