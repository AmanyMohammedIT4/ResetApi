using ResetApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResetApi.Services
{
    public interface IDeveloperService
    {
        Task<IEnumerable<Developer>> GetAllDevelopers();
        Task<Developer> GetDeveloperById(int Id);
        Task<Developer> GetDeveloperByEmail(string Email);
        void AddDeveloper(Developer developer);
        void UpdateDeveloper(Developer developer);
        void DeleteDeveloper(int Id);
    }
}
