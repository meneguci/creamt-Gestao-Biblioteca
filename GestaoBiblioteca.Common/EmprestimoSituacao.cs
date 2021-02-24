using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Common
{
    public enum EmprestimoSituacao
    {
        [Description("Emprestado")]
        Emprestado = 1,
        [Description("Atrasado")]
        Atrasado = 2,
        [Description("Devolvido")]
        Devolvido = 3
    }   
}
