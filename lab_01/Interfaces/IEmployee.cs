using lab_1.Enums;

namespace lab_1.Interfaces;

public interface IEmployee : IEntity
{
    EmployeePosition Position { get; }
    DateTime HireDate { get; }
    double Salary { get; }
    string? GetInventoryInfo();
}