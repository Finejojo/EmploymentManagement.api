using EmploymentManagement.api.Models.Domain;
using EmploymentManagement.api.Models.Dtos;
using EmploymentManagement.api.Repositories.Interfaces;
using EmploymentManagement.api.sub_folders.Context_folder;
using Microsoft.EntityFrameworkCore;

namespace EmploymentManagement.api.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _applicationContext;

        public EmployeeRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public string AddEmployee(EmployeeDtos employeeDtos)
        {
            var addNewEmployee = new Employee
            {
                FirstName = employeeDtos.FirstName,
                LastName = employeeDtos.LastName,
                EmailAddress = employeeDtos.EmailAddress,
                PhoneNumber = employeeDtos.PhoneNumber,
                IdNumber = employeeDtos.IdNumber,
                Department = employeeDtos.Department,
            };
            var addToDb = _applicationContext.Employees.Add(addNewEmployee);
            var Savechanges = _applicationContext.SaveChanges();

            if (Savechanges > 0)
                return "Operation successful";

            return "Operation Failed";
        }

        public string DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }


        public async Task<string> CreateFoodClass(FoodClassDto foodClassDto)
        {
            try
            {
                var foodClassEntity = new FoodClass
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = foodClassDto.Name,
                    Description = foodClassDto.Description,
                    Details = foodClassDto.Details,
                };

                _applicationContext.FoodClasses.Add(foodClassEntity);
                await _applicationContext.SaveChangesAsync();

                return "FoodClass Created Successfully";
            }
            catch (Exception ex)
            {
                return "Failed To Create Foodclass";
            }
        }


        public async Task<String> UpdateFoodClass(string foodClassId, FoodClassDto updatedFoodClassDto)
        {
            try
            {
                var foodClassEntity = await _applicationContext.FoodClasses.FindAsync(foodClassId);
                if (foodClassEntity == null)
                {
                    return "Food with ID does not exist";
                }
                foodClassEntity.Name = updatedFoodClassDto.Name;
                foodClassEntity.Description = updatedFoodClassDto.Description;
                foodClassEntity.Details = updatedFoodClassDto.Details;



                await _applicationContext.SaveChangesAsync();
                var updatedFoodClassDtoResponse = new FoodClassDto
                {
                    Name = foodClassEntity.Name,
                    Description = foodClassEntity.Description,
                    Details = foodClassEntity.Details,
                };
                return "Food class updated successfully.";
            }
            catch (Exception ex)
            {
                return "Failed to update food class.";
            }
        }
    }
}
