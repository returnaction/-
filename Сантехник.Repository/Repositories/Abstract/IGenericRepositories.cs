using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.CoreLayer.BaseEntities;

namespace Сантехник.RepositoryLayer.Repositories.Abstract
{
    public interface IGenericRepositories<T> where T : class, IBaseEntity
    {
    }
}
