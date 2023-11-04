using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MsgErro
{
    public static class MsgErro
    {
        public static string ErroCadastroParametros = "O registro para cadastro é inválido.";
        public static string ErroEdicaoParametros = "O registro para edição é inválido.";
        public static string ErroExcluirParametros = "O registro para exclusão é inválido.";

        public static string ErroCadastroBancoDados = "Erro ao executar cadastro no banco de dados.";
        public static string ErroConsultaBancoDados = "Erro ao executar consulta no banco de dados.";
        public static string ErroEdicaoBancoDados = "Erro ao executar edicao no banco de dados.";
        public static string ErroExcluirBancoDados = "Erro ao executar exclusão no banco de dados.";
        public static string ErroLogin = "E-mail ou Senha incorretos.";

    }
}
