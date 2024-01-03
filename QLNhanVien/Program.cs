using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanVien
{
    public class Employee
    {
        public int EmpId { get; private set; }
        public string EmpName { get; private set; }
        public string EmpPosition { get; private set; }
        public decimal EmpSalary { get; private set; }
        public string EmploymentType { get; private set; }
        public int SeniorityYears { get; private set; }
        public int AcademicDegree { get; private set; }
        public string Department { get; private set; }

        public Employee(int empId, string empName, string empPosition, decimal empSalary, string employmentType, int seniorityYears = 0, int academicDegree = 0, string department = "")
        {
            EmpId = empId;
            EmpName = empName;
            EmpPosition = empPosition;
            EmpSalary = empSalary;
            EmploymentType = employmentType;
            SeniorityYears = seniorityYears;
            AcademicDegree = academicDegree;
            Department = department;
        }
               
        public decimal CalculateOvertimePay(double hoursOvertime, bool isHoliday)
        {
            decimal baseOvertimeRate = 1.5m;
            decimal holidayOvertimeRate = 2.0m;
            decimal overtimeBonus = 10;

            decimal overtimeRate = isHoliday ? holidayOvertimeRate : baseOvertimeRate;
            return EmpSalary * overtimeRate * Convert.ToDecimal(hoursOvertime) + overtimeBonus;
        }

        public decimal CalculateAllowance()
        {
            // Logic for calculating allowance based on employee type, department, or other factors
            return 100; // Placeholder value
        }

        public decimal CalculateInsurance()
        {
            // Logic for calculating insurance based on salary or other factors
            return 50; // Placeholder value
        }

        public decimal CalculateTax()
        {
            // Logic for calculating tax based on salary, deductions, or other factors
            return 200; // Placeholder value
        }
    }

    public class EmployeeManagementSystem
    {
        private readonly List<Employee> employees;

        public EmployeeManagementSystem()
        {
            employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee GetEmployeeById(int empId)
        {
            return employees.FirstOrDefault(emp => emp.EmpId == empId);
        }

        public decimal CalculateMonthlySalary(int empId)
        {
            var employee = GetEmployeeById(empId);
            if (employee != null)
            {
                // Placeholder logic for calculating monthly salary
                return employee.EmpSalary / 12;
            }
            else
            {
                Console.WriteLine("Employee not found.");
                return 0;
            }
        }

        public decimal CalculatePartTimeSalary(int empId)
        {
            var employee = GetEmployeeById(empId);
            if (employee != null && employee.EmploymentType == "Part Time")
            {
                // Placeholder logic for calculating part-time salary
                return employee.EmpSalary;
            }
            else
            {
                Console.WriteLine("Employee not found or not a part-time employee.");
                return 0;
            }
        }

        public decimal CalculateHourlySalary(int empId)
        {
            var employee = GetEmployeeById(empId);
            if (employee != null && employee.EmploymentType == "Full Time")
            {
                // Placeholder logic for calculating hourly salary
                return employee.EmpSalary / (4 * 5 * 12); // Assuming 4 weeks per month, 5 working days per week, 12 months per year
            }
            else
            {
                Console.WriteLine("Employee not found or not a full-time employee.");
                return 0;
            }
        }

        public decimal CalculateOvertimePay(int empId, double hoursOvertime, bool isHoliday)
        {
            var employee = GetEmployeeById(empId);
            if (employee != null)
            {
                return employee.CalculateOvertimePay(hoursOvertime, isHoliday);
            }
            else
            {
                Console.WriteLine("Employee not found.");
                return 0;
            }
        }

        public decimal CalculateAllowance(int empId)
        {
            var employee = GetEmployeeById(empId);
            if (employee != null)
            {
                return employee.CalculateAllowance();
            }
            else
            {
                Console.WriteLine("Employee not found.");
                return 0;
            }
        }

        public decimal CalculateInsurance(int empId)
        {
            var employee = GetEmployeeById(empId);
            if (employee != null)
            {
                return employee.CalculateInsurance();
            }
            else
            {
                Console.WriteLine("Employee not found.");
                return 0;
            }
        }

        public decimal CalculateTax(int empId)
        {
            var employee = GetEmployeeById(empId);
            if (employee != null)
            {
                return employee.CalculateTax();
            }
            else
            {
                Console.WriteLine("Employee not found.");
                return 0;
            }
        }
        class Program
        {
            static void Main()
            {
                // Example usage...
                var ems = new EmployeeManagementSystem();

                var emp1 = new Employee(1, "John Doe", "Developer", 5000, "Full Time", seniorityYears: 3, academicDegree: 1, department: "IT");
                var emp2 = new Employee(2, "Jane Smith", "Designer", 3000, "Part Time");

                ems.AddEmployee(emp1);
                ems.AddEmployee(emp2);

                // Calculate monthly salary for an employee
                decimal monthlySalary = ems.CalculateMonthlySalary(1);
                Console.WriteLine($"Monthly salary for John Doe: {monthlySalary}");
                Console.ReadLine();

                // Calculate part-time salary for an employee
                decimal partTimeSalary = ems.CalculatePartTimeSalary(2);
                Console.WriteLine($"Part-time salary for Jane Smith: {partTimeSalary}");
                Console.ReadLine();

                // Calculate hourly salary for an employee
                decimal hourlySalary = ems.CalculateHourlySalary(1);
                Console.WriteLine($"Hourly salary for John Doe: {hourlySalary}");
                Console.ReadLine();

                // Calculate overtime pay for an employee
                double hoursOvertime = 10;  // Example overtime hours
                bool isHoliday = true;  // Example holiday condition
                decimal overtimePay = ems.CalculateOvertimePay(1, hoursOvertime, isHoliday);
                Console.WriteLine($"Overtime pay for John Doe: {overtimePay}");
                Console.ReadLine();

                // Calculate allowance for an employee
                decimal allowance = ems.CalculateAllowance(1);
                Console.WriteLine($"Allowance for John Doe: {allowance}");
                Console.ReadLine();

                // Calculate insurance for an employee
                decimal insurance = ems.CalculateInsurance(1);
                Console.WriteLine($"Insurance for John Doe: {insurance}");
                Console.ReadLine();

                // Calculate tax for an employee
                decimal tax = ems.CalculateTax(1);
                Console.WriteLine($"Tax for John Doe: {tax}");
                Console.ReadLine();
            }
        }
    }
}
