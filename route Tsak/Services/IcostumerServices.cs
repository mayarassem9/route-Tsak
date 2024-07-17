using route_Tsak.Dto;
using route_Tsak.Models;

namespace route_Tsak.Services
{
    public interface IcostumerServices
    {
        Task<IEnumerable<Costumerdto>> GetAllCustomersAsync();
        Task<Costumerdto> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Costumerdto customerDto);
        Task UpdateCustomerAsync(Costumerdto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}
