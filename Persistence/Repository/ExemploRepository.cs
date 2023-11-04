using Domain.Model;
using Domain.MsgErro;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ExemploRepository : IExemploRepository
    {
        private readonly DataContext _context;

        public ExemploRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// [REPOSITORY] Consulta com filtro de exemplo
        /// </summary>
        public async Task<IEnumerable<Exemplo>> GET_Exemplo(int pulo, int limite, int? id, string nome, double? valor, bool? ativo)
        {
            try
            {
                IQueryable<Exemplo> query = _context.DB_Exemplo.Skip(pulo).Take(limite)
                    .Where(x => (id == null || x.ID == id) &&
                                (string.IsNullOrEmpty(nome) || x.Nome.Contains(nome)) &&
                                (valor == null || x.Valor == valor) &&
                                (ativo == null || x.Ativo == ativo));

                query = query.AsNoTracking();
                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroConsultaBancoDados);
            }
        }

        /// <summary>
        /// [REPOSITORY] Consulta de exemplo por ID
        /// </summary>
        public async Task<Exemplo> GETBY_Exemplo(int id)
        {
            try
            {
                var query = await _context.DB_Exemplo.FindAsync(id);
                return query;
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroConsultaBancoDados);
            }
        }

        /// <summary>
        /// [REPOSITORY] Consulta de exemplo personalizada com query SQL
        /// </summary>
        public async Task<IEnumerable<Exemplo>> GETSQL_Exemplo()
        {
            try
            {
                var query = _context.DB_Exemplo.FromSqlRaw("SELECT * FROM Exemplo");

                query = query.AsNoTracking();
                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroConsultaBancoDados);
            }
        }
    }
}