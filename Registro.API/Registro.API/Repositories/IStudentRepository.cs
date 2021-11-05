using System;
using Registro.API.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registro.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
    }
}
