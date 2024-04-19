using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteirosMaui.Abstractions
{
    public interface IApiConnection<T>
    {
        HttpClient HttpClient { get; set; }
        string ExtraUrl { get; set; }
        string Url { get; set; }

        Task<bool> SaveItem(T item);
        Task<T> GetItem(int id);
        Task<List<T>> GetItems();
        Task<bool> DeleteItem(T item);
    }
}
