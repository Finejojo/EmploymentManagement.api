using EmploymentManagement.api.Models.Domain;
using EmploymentManagement.api.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentManagement.api.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        string AddEmployee(EmployeeDtos employeeDtos);
        Task<string> CreateFoodClass(FoodClassDto foodClassDto);
        Task<String> UpdateFoodClass(string foodClassId, FoodClassDto updatedFoodClassDto);

        string DeleteEmployee();
        List<Employee> GetAll(); //pagination
        void Update();
        Employee GetById(int id);
    }
}
