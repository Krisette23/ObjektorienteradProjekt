using BookU_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookU_ClassLibrary.Internals
{ 
    public interface IUserRepository: IRepository<User>
    {
        //Vet ej vad vi behöver för något här just nu
    }
}
