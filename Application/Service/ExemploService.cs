using Application.Filter;
using Application.IService;
using Application.ViewModel;
using AutoMapper;
using Domain.Model;
using Domain.MsgErro;
using Microsoft.EntityFrameworkCore;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ExemploService : IExemploService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IExemploRepository _exemploRepository;
        private readonly IMapper _mapper;

        public ExemploService(IGeralRepository geralRepository,
                              IExemploRepository exemploRepository,
                              IMapper mapper) {
            _geralRepository = geralRepository;
            _exemploRepository = exemploRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// [SERVICE] Cadastro exemplo
        /// </summary>
        /// <param name="exemplo">Registro a ser cadastrado</param>
        /// <returns>Registro cadastrado</returns>
        public async Task<ExemploViewModel> Create(ExemploViewModel exemplo)
        {
            if(exemplo.CadastroModelInValido()) throw new Exception(MsgErro.ErroCadastroParametros);
            
            try
            {
                Exemplo exemplodb = _mapper.Map<Exemplo>(exemplo);
                exemplodb.DataCriacao = DateTime.Now;
                exemplodb.ID = 0;

                _geralRepository.Add(exemplodb);
                var retorno = await _geralRepository.SaveChangesAsyncs();
                if(!retorno) throw new Exception(MsgErro.ErroCadastroBancoDados);
                return _mapper.Map<ExemploViewModel>(exemplodb);
            }
            catch (Exception e)
            {
                throw new Exception(MsgErro.ErroCadastroBancoDados);
            }
        }

        /// <summary>
        /// [SERVICE] Desabilitar registro
        /// </summary>
        /// <param name="id">ID do registro a ser desabilitado</param>
        /// <returns>Registro desabilitado no processo</returns>
        public async Task<ExemploViewModel> Disable(int id)
        {
            try
            {
                var retorno = await _exemploRepository.GETBY_Exemplo(id);
                if(retorno == null) throw new Exception(MsgErro.ErroExcluirBancoDados);
                retorno.Ativo = false;
                retorno.DataExclusao = DateTime.Now;

                _geralRepository.Update(retorno);
                var retornoSC = await _geralRepository.SaveChangesAsyncs();

                if (!retornoSC) throw new Exception(MsgErro.ErroExcluirBancoDados);
                return _mapper.Map<ExemploViewModel>(retorno);
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroExcluirBancoDados);
            }
        }

        /// <summary>
        /// [SERVICE] Atualizar registro
        /// </summary>
        /// <param name="exemplo">Objeto a ser atualizado</param>
        /// <returns>Objeto atualizado</returns>
        public async Task<ExemploViewModel> Update(ExemploViewModel exemplo)
        {
            if (exemplo.EditarModelInvalido()) throw new Exception(MsgErro.ErroEdicaoParametros);
            try
            {
                //Mapeamento
                Exemplo exemploEdt = _mapper.Map<Exemplo>(exemplo);

                //Consulta o registro no banco (antes da edição)
                Exemplo exemploConsulta = await _exemploRepository.GETBY_Exemplo(exemplo.ID);
                if(exemploConsulta == null) throw new Exception(MsgErro.ErroCadastroBancoDados);

                //Atualizar datas
                exemploConsulta.Ativo = exemploEdt.Ativo;
                exemploConsulta.Nome = exemploEdt.Nome;
                exemploConsulta.DataAtualizacao = DateTime.Now;

                //Atualiza os registros no banco
                _geralRepository.Update(exemploConsulta);
                var retorno = await _geralRepository.SaveChangesAsyncs();

                //Verificação da operação e retorno
                if (!retorno) throw new Exception(MsgErro.ErroCadastroBancoDados);
                return _mapper.Map<ExemploViewModel>(exemploConsulta);
            }
            catch (Exception)
            {
                throw new Exception(MsgErro.ErroEdicaoBancoDados);
            }
        }

        /// <summary>
        /// [SERVICE] Consultar exemplo 
        /// </summary>
        /// <param name="pulo">Quantos registros vão ser pulados</param>
        /// <param name="limite">Limite de exibição por tela</param>
        /// <param name="filtro">Filtro dos dados</param>
        /// <returns>Lista de registros</returns>
        public async Task<IEnumerable<ExemploViewModel>> GET_Exemplo(int pulo, int limite, ExemploFiltro filtro)
        {
            try
            {
                var list_exemplo = await _exemploRepository.GET_Exemplo(pulo, limite, filtro.ID, filtro.Nome, filtro.Valor, filtro.Ativo);
                if (list_exemplo == null) return null;
                
                return _mapper.Map<ExemploViewModel[]>(list_exemplo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// [SERVICE] Consulta de exemplo personalizada no SQL
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ExemploViewModel>> GETSQL_Exemplo()
        {
            try
            {
                var list_exemplo = await _exemploRepository.GETSQL_Exemplo();
                if (list_exemplo == null) return null;

                return _mapper.Map<ExemploViewModel[]>(list_exemplo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
