using ZadanieRekrutacyjne.Models;
using ZadanieRekrutacyjne.Repositories;
using static ZadanieRekrutacyjne.Models.Employee;

// 1.
Console.WriteLine("Zadanie 1");

var employees = EmployeeRepository.GetAllEmployees();

Employee.EmployeeStructure = InitializeEmployeesStructure(employees);

var row1 = GetSuperiorRowOfEmployee(2, 1); // row1 = 1
var row2 = GetSuperiorRowOfEmployee(4, 3); // row2 = null
var row3 = GetSuperiorRowOfEmployee(4, 1); // row3 = 2

DisplayInfo(2, 1);
DisplayInfo(4, 3);
DisplayInfo(4, 1);

// 2.

/*
  
 a)

 SELECT DISTINCT e.Name
 FROM Employee e
 JOIN Vacations v
 ON e.Id = v.EmployeeId
 JOIN Team t
 ON t.Id = e.TeamId
 WHERE t.Name LIKE '.NET'
 AND YEAR(v.DateSince) = 2019;

 b)

 SELECT 
	e.Name,
	CAST
	(
		ISNULL
		(
			SUM
			(
				CASE
					WHEN v.IsPartialVacation = 0 THEN
						DATEDIFF
						(
							DAY,
							v.DateSince,
							CASE
								WHEN v.DateUntil < CAST(GETDATE() AS DATE) THEN v.DateUntil
								WHEN v.DateSince > CAST(GETDATE() AS DATE) THEN v.DateSince
								ELSE CAST(GETDATE() AS DATE)
							END
						) + 1
					ELSE
						v.NumberOfHours / 8
				END
			), 0
		) AS DECIMAL(10,3)
	) AS UsedVacationDays
 FROM Employee e
 LEFT JOIN Vacations v
 ON e.Id = v.EmployeeId
 WHERE YEAR(v.DateSince) = YEAR(CONVERT(date, GETDATE(), 102))
 OR v.DateSince IS NULL
 GROUP BY e.Id, e.Name

 c)

 SELECT DISTINCT t.Name
 FROM Employee e
 LEFT JOIN Vacations v
 ON e.Id = v.EmployeeId
 JOIN Team t
 ON t.Id = e.TeamId
 JOIN VacationPackage vp
 ON vp.Id = e.VacationPackageId
 WHERE v.EmployeeId IS NULL
 AND vp.Year = 2019;

 */

// 3.

Console.WriteLine("");
Console.WriteLine("Zadanie 3");

var employees3 = EmployeeRepository.GetAllEmployees3();
var vacations = VacationRepository.GetAllVacations();
var vacationPackages = VacationRepository.GetAllVacationPackages();

foreach (var employee in employees3)
{
	VacationPackage vacationPackage = vacationPackages.SingleOrDefault(vp => vp.Id == employee.VacationPackageId)
		?? throw new ArgumentNullException("No vacation package for given employee.");

	List<Vacation> employeeVacations = [.. vacations.Where(v => v.EmployeeId == employee.Id)];

    double freeDaysLeft = Employee3.CountFreeDaysForEmployee(employee, employeeVacations, vacationPackage);

	employee.DisplayInfo3(freeDaysLeft);

	// 4.

	bool canRequest = Employee3.IfEmployeeCanRequestVacation(employee, employeeVacations, vacationPackage);

	Console.WriteLine($"Pracownik o id {employee.Id} {(canRequest ? "" : "nie ")} wystąpić o wniosek urlopowy.");
}

// 5. Testy w katalogu Tests/UnitTests

// 6.

/*
 
 a) Eager loading vs lazy loading

	Lazy loading powoduje, że przy każdym odwołaniu do właściwości nawigacyjnej wysyłane jest nowe zapytanie SQL.
	Stosując Include() możemy wysłać jedno zapytanie zamiast kilku osobnych.
 
 b) Projekcja - zamiast pobierania całych encji można pobrać tylko potrzebne kolumny.

 c) Przechowywanie danych w pamięci podręcznej aplikacji lub zewnętrznej (np. Redis) - jeżeli takie rozwiązanie jest zasadne, np. kiedy dane rzadko się zmieniają.
	Dane pobierane są raz (na ustalony okres) i następne odwołania korzystają już z danych umieszczonych w cache'u.

 d) Filtrowanie po stronie bazy danych zamiast w pamięci poprzez stosowanie Where() przed ToList().

 */