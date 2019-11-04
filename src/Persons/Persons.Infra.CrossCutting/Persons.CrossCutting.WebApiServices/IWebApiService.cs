using System;
using System.Threading.Tasks;

namespace Persons.CrossCutting.WebApiServices
{
    public interface IWebApiService
    {
        Uri UriBase { get; set; }

        Task<T> GetAsync<T>(string action);

        Task<T> GetAsync<T>(string action, object data);

        Task<T> PostAsync<T>(string action, object data);

        Task<T> PutAsync<T>(string action, T data);

        Task<T> DeleteAsync<T>(string action);
    }
}
