using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Common
{
    public enum LivroSituacao
    {
        [Description("Disponível")]
        Disponivel =1,
        [Description("Emprestado")]
        Emprestado =2,
        [Description("Extraviado")]
        Extraviado =3,
        [Description("Em Manutenção")]
        EmManutencao =4
    }
}
