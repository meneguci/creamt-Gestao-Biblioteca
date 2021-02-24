using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Common
{
    public enum PessoaTipo
    {
        [Description("Autor")]
        Autor = 1,
        [Description("Professional")]
        Profissional = 2,
        [Description("Aluno")]
        Aluno =3 ,
        [Description("Outros")]
        Outros = 4
    }
}
