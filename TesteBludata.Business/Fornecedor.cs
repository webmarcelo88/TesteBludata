using System;
using System.Collections.Generic;
using TesteBludata.DAO.Fornecedor;
using TesteBludata.Model;

namespace TesteBludata.Business
{
    public class Fornecedor
    {
        private FornecedorDAO m_DAO;

        public Fornecedor()
        {
            m_DAO = new FornecedorDAO();
        }

        /// <summary>
        /// Busca todos os fornecedores
        /// </summary>
        /// <returns>Lista de fornecedores</returns>
        public List<FornecedorModel> Consultar()
        {
            return m_DAO.Consultar();
        }

        /// <summary>
        /// Busca o fornecedor pelo filtro
        /// </summary>
        /// <param name="pFiltro">Filtro informado na pesquisa</param>
        /// <returns>Lista de fornecedores</returns>
        public List<FornecedorModel> ConsultarPeloFiltro(string pFiltro)
        {
            return m_DAO.ConsultarPeloFiltro(pFiltro);
        }

        /// <summary>
        /// Busca o fornecedor pelo ID
        /// </summary>
        /// <param name="pID">ID do fornecedor</param>
        /// <returns>Model do fornecedor</returns>
        public FornecedorModel ConsultarPeloID(long pID)
        {
            return m_DAO.ConsultarPeloID(pID);
        }

        /// <summary>
        /// Inclui o fornecedor
        /// </summary>
        /// <param name="pModelo">Model do fornecedor</param>
        /// <returns>ID do fornecedor</returns>
        public long Incluir(FornecedorModel pModelo)
        {
            ValidarInclusao(pModelo);
            return m_DAO.Incluir(pModelo);
        }

        /// <summary>
        /// Altera o fornecedor
        /// </summary>
        /// <param name="pModelo">Model do fornecedor</param>
        /// <param name="pID">ID do fornecedor</param>
        public void Alterar(FornecedorModel pModelo, long pID)
        {
            ValidarAlteracao(pModelo);
            m_DAO.Alterar(pModelo, pID);
        }

        /// <summary>
        /// Exclui o fornecedor 
        /// </summary>
        /// <param name="pModelo">Model do fornecedor</param>
        public void Excluir(FornecedorModel pModelo)
        {
            m_DAO.Excluir(pModelo);
        }

        /// <summary>
        /// Efetua as regras de negocio da entidade
        /// </summary>
        /// <param name="pModelo">Model do fornecedor</param>
        private void ValidarInclusao(FornecedorModel pModelo)
        {
            ValidarInformacoesPessoaFisica(pModelo);
            ValidarMenorIdade(pModelo);
        }

        private void ValidarAlteracao(FornecedorModel pModelo)
        {
            ValidarInformacoesPessoaFisica(pModelo);
            ValidarMenorIdade(pModelo);
        }

        private void ValidarInformacoesPessoaFisica(FornecedorModel pModelo)
        {
            if (pModelo.Tipo == (long)Model.Enum.TipoPessoa.PessoaFisica)
            {
                if (string.IsNullOrEmpty(pModelo.RG) || pModelo.DataNascimento == DateTime.MinValue)
                    throw new BusinessException("RG e Data de nascimento devem ser informados!");
            }
        }

        private void ValidarMenorIdade(FornecedorModel pModelo)
        {
            var empresa = new Empresa();
            var modelEmpresa = empresa.ConsultarPeloID(pModelo.Empresa);

            if (modelEmpresa.Estado != long.MinValue)
            {
                const string SIGLA_PARANA = "PR";
                const int MAIOR_IDADE = 18;

                var estado = new Estado();
                var modelEstado = estado.ConsultarPeloID(modelEmpresa.Estado);

                if (modelEstado.Sigla == SIGLA_PARANA)
                {
                    var idade = GetIdade(pModelo.DataNascimento);
                    if (idade < MAIOR_IDADE)
                    {
                        throw new BusinessException("Cadastro permitido apenas para maiores de idade!");
                    }
                }
            }
        }

        private int GetIdade(DateTime DataNascimento)
        {
            int result = DateTime.Now.Year - DataNascimento.Year;
            if (DateTime.Now.Month < DataNascimento.Month || (DateTime.Now.Month == DataNascimento.Month && DateTime.Now.Day < DataNascimento.Day))
                result--;
            return result;
        }
    }
}
