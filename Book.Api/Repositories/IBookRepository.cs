
using BooksApi.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BooksApi.Repositories
{
    public interface IBookRepository
    {

        Task<IEnumerable<Book>> GetAll();

        Task<Book> Get(int id);

        Task<Book> Create(Book book);

        Task Update(Book book);

        Task Delete(int id);


    }
}
