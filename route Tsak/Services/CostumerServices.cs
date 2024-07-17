using route_Tsak.Dto;
using route_Tsak.Models;
using route_Tsak.Repo;
using route_Tsak.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace route_Tsak.Services
{
    public class CustomerService : IcostumerServices
    {
        Task IcostumerServices.AddCustomerAsync(Costumerdto customerDto)
        {
            throw new NotImplementedException();
        }

        Task IcostumerServices.DeleteCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Costumerdto>> IcostumerServices.GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        Task<Costumerdto> IcostumerServices.GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IcostumerServices.UpdateCustomerAsync(Costumerdto customerDto)
        {
            throw new NotImplementedException();
        }
    }
}