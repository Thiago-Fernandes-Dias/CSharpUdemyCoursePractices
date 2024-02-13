List<Employee> employees =
[
    new("Jake Smith", "Space Navigation", 25000),
    new("Anna Blake", "Space Navigation", 29000),
    new("Barbara Oak", "Xenobiology", 21500 ),
    new("Damien Parker", "Xenobiology", 22000),
    new("Nisha Patel", "Machanics", 21000),
    new("Gustavo Sanchez", "Machanics", 20000),
];
var result = CalculateAverageSalaryPerDepartment(employees);
foreach (var kvp in result)
    Console.WriteLine($"{kvp.Key} - {kvp.Value}");

Dictionary<string, decimal> CalculateAverageSalaryPerDepartment(List<Employee> employees)
{
    Dictionary<string, int> employeeQtyPerDep = [];
    Dictionary<string, decimal> result = [];
    foreach (var employee in employees)
    {
        if (!employeeQtyPerDep.ContainsKey(employee.Department))
            employeeQtyPerDep[employee.Department] = 0;
        employeeQtyPerDep[employee.Department] += 1;
        if (!result.ContainsKey(employee.Department))
            result[employee.Department] = 0.0m;
        result[employee.Department] = (result[employee.Department] + employee.Salary) / employeeQtyPerDep[employee.Department];
    }
    return result;
}

class Employee(string name, string department, decimal salary)
{
    public readonly string Name = name;
    public readonly string Department = department;
    public readonly decimal Salary = salary;
}
