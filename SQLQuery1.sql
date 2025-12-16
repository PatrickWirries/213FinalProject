DELETE FROM [User];
DELETE FROM [Appointment];
DELETE FROM [Service];
DELETE FROM [ServicePerformingEmployeeService];
DBCC CHECKIDENT('User', RESEED, 0);
DBCC CHECKIDENT('Appointment', RESEED, 0);
DBCC CHECKIDENT('Service', RESEED, 0);
DBCC CHECKIDENT('ServicePerformingEmployeeService', RESEED, 0);